using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.IntegrationService.Migration;
using StudyGroupSxaMigration.ItemServices.Services;
using StudyGroupSxaMigration.Logging.Exceptions;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreConstants;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.IntegrationService.ItemMigration
{
    public class ButtonGroupMigration : MigrationBase, IItemMigration
    {
        public ButtonGroupMigration(
                                ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ISitecore8Repository sitecore8Repository,
                                ILogger<ButtonGroupMigration> logger,
                                IEnumerable<ISxaService> sxaServices,
                                ISitecore8WebsiteConfiguration sitecore8Website,
                                Sitecore9Website sitecore9Website,
                                ApplicationSettings applicationSettings
                                )
                            : base (
                                  sitecore8Client,
                                  sitecore9Client,
                                  sitecore8Repository,
                                  logger,
                                  sxaServices,
                                  sitecore8Website,
                                  sitecore9Website,
                                  applicationSettings)
        {
            this.HasHierarchicalItemStructure = true;
        }

        /// <summary>
        /// Retrieve all and migrate all Button Group under the Data folder for this page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            itemUpdateCounter = new ItemUpdateCounter();

            string templateId = _sitecore8Website.WebsiteTemplateIds.ButtonGroupContainer;
            string subfolderNameForThisItemType = _sitecore8Website.PageItemSubFolders.ButtonGroups;

            string pageItemsSubFolderForThisType = GetPageItemsSubFolderPathForItemType(pageItem, subfolderNameForThisItemType);

            var dataItems = await _sitecore8Repository.GetItemChildrenByPath<ButtonGroup>(pageItemsSubFolderForThisType, templateId);

            // Additional checks (depending on config settings) to see if items of this type are located in any other folders under Page Items

            var itemsAreInExpectedLocation = (dataItems?.Count > 0);

            if (DoCheckForAlternativeFolders(itemsAreInExpectedLocation))
            {
                string currentItemDescription = "Button Group";

                var sitecoreItemList = await CheckForAlternativeFolders<ButtonGroup>(pageItem, pageItemsSubFolderForThisType, subfolderNameForThisItemType,
                                                                                                            templateId, currentItemDescription, itemsAreInExpectedLocation);

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
                migrationLogger.LogDebug($"Migrating Page Data Button Group Items from path: '{pageItemsSubFolderForThisType}'");

                string targetPath = GetSitecore9TargetPath(pageItemsSubFolderForThisType, subfolderNameForThisItemType);

                await InsertButtonGroupAndCTAs(dataItems, targetPath);
            }
            return itemUpdateCounter;
        }

        /// <summary>
        /// Retrieve Button Groups under shared items folder. For each button group, copy into sitecore 9 and retrieve child CTA items from Sitecore 8, then insert into sitecore 9
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.ButtonGroups))
            {
                migrationLogger.LogDebug($"Migrating Shared Button Group Items");

                List <ButtonGroup> sitecore8ButtonGroups = await _sitecore8Repository.GetItemChildrenByPath<ButtonGroup>(_sitecore8Website.SharedItemFolderPaths.ButtonGroups, _sitecore8Website.WebsiteTemplateIds.ButtonGroupContainer);

                if (sitecore8ButtonGroups?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8ButtonGroups.Count} Shared Button Group Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.ButtonGroups}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.ButtonGroups}");
                    await InsertButtonGroupAndCTAs(sitecore8ButtonGroups, _sitecore9Website.SharedItemPaths.ButtonGroups);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertButtonGroupAndCTAs(List<ButtonGroup> sitecore8ButtonGroups, string insertionPath)
        {
            if (sitecore8ButtonGroups?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 = sitecore8ButtonGroups.Count;

                SxaLinkService sxaLinkService = (SxaLinkService)GetSxaService(typeof(SxaLinkService));
                SgSxaButtonGroupService sgSxaButtonGroupService = (SgSxaButtonGroupService)GetSxaService(typeof(SgSxaButtonGroupService));

                foreach (ButtonGroup buttonGroup in sitecore8ButtonGroups)
                {
                    try
                    {
                        if (await sgSxaButtonGroupService.Create(buttonGroup, insertionPath))
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
                        migrationLogger.LogFailedInsert(typeof(ButtonGroup), insertionPath, buttonGroup?.ItemName, failedInsertException);
                    }

                    string buttonGroupItemPath = insertionPath + $"/{buttonGroup.ItemName}";

                    if (buttonGroup.HasChildren)
                    {
                        buttonGroup.CTAButtons = await _sitecore8Repository.GetChildrenById<CallToAction>(buttonGroup.ItemID, _sitecore8Website.WebsiteTemplateIds.CTA);

                        if (buttonGroup.CTAButtons?.Count > 0)
                        {
                            itemUpdateCounter.ChildItemsFoundInSitecore8 = buttonGroup.CTAButtons.Count;

                            foreach (CallToAction callToAction in buttonGroup.CTAButtons)
                            {
                                try
                                {
                                    if (await sxaLinkService.Create(callToAction, _sitecore9Website.RootPath, _sitecore8Website.RootPath, buttonGroupItemPath))
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
                                    migrationLogger.LogFailedInsert(typeof(CallToAction), buttonGroupItemPath, callToAction?.ItemName, ex);
                                }
                                catch (LinkException ex)
                                {
                                    itemUpdateCounter.ChildItemsFailedToInsert++;
                                    migrationLogger.LogFailedInsert(typeof(CallToAction), buttonGroupItemPath, callToAction?.ItemName, ex);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
