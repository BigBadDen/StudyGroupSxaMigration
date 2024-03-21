using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.IntegrationService.Migration;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreConstants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using StudyGroupSxaMigration.Logging;
using StudyGroupSxaMigration.Logging.Exceptions;
using Microsoft.Extensions.Configuration;
using StudyGroupSxaMigration.ItemServices.Services;
using StudyGroupSxaMigration.AppSettings;

namespace StudyGroupSxaMigration.IntegrationService.ItemMigration
{
    public class TabMigration : MigrationBase, IItemMigration
    {
        public TabMigration(
                                ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ISitecore8Repository sitecore8Repository,
                                ILogger<TabMigration> logger,
                                IEnumerable<ISxaService> sxaServices,
                                ISitecore8WebsiteConfiguration sitecore8Website,
                                Sitecore9Website sitecore9Website,
                                ApplicationSettings applicationSettings
                                )
                            : base(
                                  sitecore8Client,
                                  sitecore9Client,
                                  sitecore8Repository,
                                  logger,
                                  sxaServices,
                                  sitecore8Website,
                                  sitecore9Website,
                                  applicationSettings)
        {
            this.HasHierarchicalItemStructure = false;
        }

        /// <summary>
        /// Retrieve all and migrate all Tabs under the Data folder for this page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            itemUpdateCounter = new ItemUpdateCounter();

            string templateId = _sitecore8Website.WebsiteTemplateIds.TabContainer;
            string subfolderNameForThisItemType = _sitecore8Website.PageItemSubFolders.Tabs;

            string pageItemsSubFolderForThisType = GetPageItemsSubFolderPathForItemType(pageItem, subfolderNameForThisItemType);

            var tabContainers = await _sitecore8Repository.GetItemChildrenByPath<TabContainer>(pageItemsSubFolderForThisType, templateId);

            // Additional checks (depending on config settings) to see if items of this type are located in any other folders under Page Items

            var itemsAreInExpectedLocation = (tabContainers?.Count > 0);

            if (DoCheckForAlternativeFolders(itemsAreInExpectedLocation))
            {
                string currentItemDescription = "Tab Container";

                var sitecoreItemList = await CheckForAlternativeFolders<TabContainer>(pageItem, pageItemsSubFolderForThisType, subfolderNameForThisItemType,
                                                                                                            templateId, currentItemDescription, itemsAreInExpectedLocation);

                if (!itemsAreInExpectedLocation && sitecoreItemList.SitecoreItems?.Count > 0 && !String.IsNullOrEmpty(sitecoreItemList.FolderName) && !String.IsNullOrEmpty(sitecoreItemList.FolderPath))
                {
                    tabContainers = sitecoreItemList.SitecoreItems;
                    pageItemsSubFolderForThisType = sitecoreItemList.FolderPath;
                    subfolderNameForThisItemType = sitecoreItemList.FolderName;
                }
            }

            // Migration

            if (tabContainers?.Count > 0)
            {
                migrationLogger.LogDebug($"Migrating Page Data TabItem Items from path: '{pageItemsSubFolderForThisType}'");

                string targetPath = GetSitecore9TargetPath(pageItemsSubFolderForThisType, subfolderNameForThisItemType);

                await InsertTabContainerAndItems(tabContainers, targetPath);
            }
            return itemUpdateCounter;
        }

        /// <summary>
        /// Retrieve Tab Groups under shared items folder. For each button group, copy into sitecore 9 and retrieve child items from Sitecore 8, then insert into sitecore 9
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.Tabs))
            {
                migrationLogger.LogDebug($"Migrating Shared Tabs Items");

                List<TabContainer> sitecore8TabContainers = await _sitecore8Repository.GetItemChildrenByPath<TabContainer>(_sitecore8Website.SharedItemFolderPaths.Tabs, _sitecore8Website.WebsiteTemplateIds.TabContainer);

                if (sitecore8TabContainers?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8TabContainers.Count} Shared Tab Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.Tabs}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.Tabs}");
                    await InsertTabContainerAndItems(sitecore8TabContainers, _sitecore9Website.SharedItemPaths.Tabs);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertTabContainerAndItems(List<TabContainer> sitecore8Tabs, string insertionPath)
        {
            if (sitecore8Tabs?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8Tabs.Count;

                SxaTabService sxaTabItemService = (SxaTabService)GetSxaService(typeof(SxaTabService));
                SxaTabContainerService sxaTabContainerService = (SxaTabContainerService)GetSxaService(typeof(SxaTabContainerService));

                foreach (TabContainer tabContainer in sitecore8Tabs)
                {
                    try
                    {
                        if (await sxaTabContainerService.Create(tabContainer, insertionPath))
                        {
                            itemUpdateCounter.ItemsMigrated++;
                        }
                        else
                        {
                            itemUpdateCounter.ItemsSkipped++;
                        }
                    }
                    catch (FailedInsertException failedInsertException)
                    {
                        itemUpdateCounter.ItemsFailedToInsert++;
                        migrationLogger.LogFailedInsert(typeof(TabContainer), insertionPath, tabContainer?.ItemName, failedInsertException);
                    }

                    string tabContainerItemPath = insertionPath + $"/{tabContainer.ItemName}";

                    if (tabContainer.HasChildren)
                    {
                        tabContainer.Tabs = await _sitecore8Repository.GetChildrenById<Tab>(tabContainer.ItemID, _sitecore8Website.WebsiteTemplateIds.Tab);

                        if (tabContainer.Tabs?.Count > 0)
                        {
                            itemUpdateCounter.ChildItemsFoundInSitecore8 += tabContainer.Tabs.Count;

                            foreach (Tab tabItem in tabContainer.Tabs)
                            {
                                try
                                {
                                    if (await sxaTabItemService.Create(tabItem, _sitecore9Website.RootPath, _sitecore8Website.RootPath, tabContainerItemPath))
                                    {
                                        itemUpdateCounter.ChildItemsMigrated++;
                                    }
                                    else
                                    {
                                        itemUpdateCounter.ChildItemsSkipped++;
                                    }
                                }
                                catch (FailedInsertException ex)
                                {
                                    itemUpdateCounter.ChildItemsFailedToInsert++;
                                    migrationLogger.LogFailedInsert(typeof(Tab), tabContainerItemPath, tabItem?.ItemName, ex);
                                }
                                catch (LinkException ex)
                                {
                                    itemUpdateCounter.ChildItemsFailedToInsert++;
                                    migrationLogger.LogFailedInsert(typeof(Tab), tabContainerItemPath, tabItem?.ItemName, ex);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
