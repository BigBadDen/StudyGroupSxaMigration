using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.IntegrationService.Migration;
using StudyGroupSxaMigration.ItemServices.Services;
using StudyGroupSxaMigration.Logging.Exceptions;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreConstants;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.IntegrationService.ItemMigration
{
    public class WidgetMigration : MigrationBase, IItemMigration
    {
        public WidgetMigration(
                            ISitecore8Client sitecore8Client,
                            ISitecore9Client sitecore9Client,
                            ISitecore8Repository sitecore8Repository,
                            ILogger<WidgetMigration> logger,
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
        /// Retrieve all and migrate all Widgets under the Data folder for this page
        /// NB. WE HAVE SEVERAL DIFFERENT WIDGET FOLDER TEMPLATES FOR EACH WEBSITE, SO WE CAN'T SEARCH BY TEMPLATE ID. Instead, we just search under the expected folder name
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (_sitecore8Website.WebsiteTemplateIds?.Widgets == null || _sitecore8Website.WebsiteTemplateIds?.Widgets.Count == 0)
            {
                return itemUpdateCounter;
            }

            var widgetTemplateIds = _sitecore8Website.WebsiteTemplateIds?.Widgets;

            string subfolderNameForThisItemType = _sitecore8Website.PageItemSubFolders.Widgets;

            string pageItemsSubFolderForThisType = GetPageItemsSubFolderPathForItemType(pageItem, subfolderNameForThisItemType);

            var dataItems = await _sitecore8Repository.GetItemChildrenByPath<Widget>(pageItemsSubFolderForThisType, widgetTemplateIds);

            // Additional checks (depending on config settings) to see if items of this type are located in any other folders under Page Items

            var itemsAreInExpectedLocation = (dataItems?.Count > 0);

            if (DoCheckForAlternativeFolders(itemsAreInExpectedLocation))
            {
                string currentItemDescription = "Widget";

                var sitecoreItemList = await CheckForAlternativeFolders<Widget>(pageItem, pageItemsSubFolderForThisType, subfolderNameForThisItemType,
                                                                                                            widgetTemplateIds, currentItemDescription, itemsAreInExpectedLocation);

                if (!itemsAreInExpectedLocation && sitecoreItemList.SitecoreItems?.Count > 0 && !String.IsNullOrEmpty(sitecoreItemList.FolderName) && !String.IsNullOrEmpty(sitecoreItemList.FolderPath))
                {
                    dataItems = sitecoreItemList.SitecoreItems;
                    pageItemsSubFolderForThisType = sitecoreItemList.FolderPath;
                    subfolderNameForThisItemType = sitecoreItemList.FolderName;
                }
            }

            // Migration

            if (dataItems?.Count > 0)
            {
                string targetPath = GetSitecore9TargetPath(pageItemsSubFolderForThisType, subfolderNameForThisItemType);

                if (_applicationSettings.CreateSubFoldersIfMissing)
                {
                    SxaFolderService sxaFolderService = (SxaFolderService)GetSxaService(typeof(SxaFolderService));
                    await sxaFolderService.Create(Sitecore9Folders.PageDataSubFolders.Widgets, targetPath);
                }

                targetPath = $"{targetPath}/{Sitecore9Folders.PageDataSubFolders.Widgets}";

                migrationLogger.LogDebug($"Migrating Page Data Widget Items from path: '{pageItemsSubFolderForThisType}'");

                if (dataItems.Count > 0)
                {
                    await InsertWidgets(dataItems, targetPath);
                }
            }
            return itemUpdateCounter;
        }

        /// <summary>
        /// Retrieve Widgets items from Sitecore 8, then insert into sitecore 9 as SXA Widgets
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.Widgets))
            {
                migrationLogger.LogDebug($"Migrating Shared Widget Items");

                List<Widget> sitecore8Widgets = await _sitecore8Repository.GetItemChildrenByPath<Widget>(_sitecore8Website.SharedItemFolderPaths.Widgets, _sitecore8Website.WebsiteTemplateIds.Widgets);

                if (sitecore8Widgets?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8Widgets.Count} Shared Widget Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.Widgets}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.Widgets}");
                    await InsertWidgets(sitecore8Widgets, _sitecore9Website.SharedItemPaths.Widgets);
                }
            }
            return itemUpdateCounter;
        }

        /// <summary>
        /// Insert widgets
        /// </summary>
        /// <param name="sitecore8Widgets"></param>
        /// <param name="insertionPath"></param>
        /// <returns>itemUpdateCounter - this is only for when the method is called directly for miscellaneous shared items</returns>
        public async Task<ItemUpdateCounter> InsertWidgets(List<Widget> sitecore8Widgets, string insertionPath)
        {
            if (sitecore8Widgets?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8Widgets.Count;

                SxaWidgetService sxaWidgetService = (SxaWidgetService)GetSxaService(typeof(SxaWidgetService));

                foreach (Widget widget in sitecore8Widgets)
                {
                    try
                    {
                        if (await sxaWidgetService.Create(widget, _sitecore9Website.RootPath, _sitecore8Website.RootPath, insertionPath))
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
                        migrationLogger.LogFailedInsert(typeof(Widget), insertionPath, widget?.ItemName, failedInsertException);
                    }
                    catch (LinkException ex)
                    {
                        itemUpdateCounter.ItemsFailedToInsert++;
                        migrationLogger.LogFailedInsert(typeof(Widget), insertionPath, widget?.ItemName, ex);
                    }
                }
            }
            return itemUpdateCounter;
        }
    }
}
