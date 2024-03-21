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
    public class AccordionMigration : MigrationBase, IItemMigration
    {
        public AccordionMigration(
                                ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ISitecore8Repository sitecore8Repository,
                                ILogger<AccordionMigration> logger,
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
        /// Retrieve all and migrate all Accordions under the Data folder for this page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            itemUpdateCounter = new ItemUpdateCounter();

            string templateId = _sitecore8Website.WebsiteTemplateIds.AccordionContainer;
            string subfolderNameForThisItemType = _sitecore8Website.PageItemSubFolders.Accordions;

            string pageItemsSubFolderForThisType = GetPageItemsSubFolderPathForItemType(pageItem, subfolderNameForThisItemType);

            var accordionContainers = await _sitecore8Repository.GetItemChildrenByPath<AccordionContainer>(pageItemsSubFolderForThisType, templateId);

            // Additional checks (depending on config settings) to see if items of this type are located in any other folders under Page Items

            var itemsAreInExpectedLocation = (accordionContainers?.Count > 0);

            if (DoCheckForAlternativeFolders(itemsAreInExpectedLocation))
            {
                string currentItemDescription = "Accordion Container";

                var sitecoreItemList = await CheckForAlternativeFolders<AccordionContainer>(pageItem, pageItemsSubFolderForThisType, subfolderNameForThisItemType,
                                                                                                                templateId, currentItemDescription, itemsAreInExpectedLocation);

                if (!itemsAreInExpectedLocation && sitecoreItemList.SitecoreItems?.Count > 0 && !String.IsNullOrEmpty(sitecoreItemList.FolderName) && !String.IsNullOrEmpty(sitecoreItemList.FolderPath))
                {
                    accordionContainers = sitecoreItemList.SitecoreItems;
                    pageItemsSubFolderForThisType = sitecoreItemList.FolderPath;
                    subfolderNameForThisItemType = sitecoreItemList.FolderName;
                }
            }

            // Migration

            if (accordionContainers?.Count > 0)
            {
                migrationLogger.LogDebug($"Migrating Page Data AccordionItem Items from path: '{pageItemsSubFolderForThisType}'");

                string targetPath = GetSitecore9TargetPath(pageItemsSubFolderForThisType, subfolderNameForThisItemType);

                await InsertAccordionContainerAndItems(accordionContainers, targetPath);
            }

            return itemUpdateCounter;
        }

        /// <summary>
        /// Retrieve Accordions Groups under shared items folder. For each button group, copy into sitecore 9 and retrieve child CTA items from Sitecore 8, then insert into sitecore 9
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.Accordions))
            {
                migrationLogger.LogDebug($"Migrating Shared Accordion Items");

                List<AccordionContainer> sitecore8AccordionContainers = await _sitecore8Repository.GetItemChildrenByPath<AccordionContainer>(_sitecore8Website.SharedItemFolderPaths.Accordions, _sitecore8Website.WebsiteTemplateIds.AccordionContainer);

                if (sitecore8AccordionContainers?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8AccordionContainers.Count} Shared Accordion Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.Accordions}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.Accordions}");
                    await InsertAccordionContainerAndItems(sitecore8AccordionContainers, _sitecore9Website.SharedItemPaths.Accordions);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertAccordionContainerAndItems(List<AccordionContainer> sitecore8Accordions, string insertionPath)
        {
            if (sitecore8Accordions?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8Accordions.Count;

                SxaAccordionService sxaAccordionItemService = (SxaAccordionService)GetSxaService(typeof(SxaAccordionService));
                SxaAccordionContainerService sxaAccordionContainerService = (SxaAccordionContainerService)GetSxaService(typeof(SxaAccordionContainerService));

                foreach (AccordionContainer accordionContainer in sitecore8Accordions)
                {
                    try
                    {
                        if (await sxaAccordionContainerService.Create(accordionContainer, insertionPath))
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
                        migrationLogger.LogFailedInsert(typeof(AccordionContainer), insertionPath, accordionContainer?.ItemName, failedInsertException);
                    }

                    string accordionContainerItemPath = insertionPath + $"/{accordionContainer.ItemName}";

                    if (accordionContainer.HasChildren)
                    {
                        accordionContainer.AccordionItems = await _sitecore8Repository.GetChildrenById<AccordionItem>(accordionContainer.ItemID, _sitecore8Website.WebsiteTemplateIds.AccordionItem);

                        if (accordionContainer.AccordionItems?.Count > 0)
                        {
                            itemUpdateCounter.ChildItemsFoundInSitecore8 += accordionContainer.AccordionItems.Count;

                            foreach (AccordionItem accordionItem in accordionContainer.AccordionItems)
                            {
                                try
                                {
                                    if (await sxaAccordionItemService.Create(accordionItem, _sitecore9Website.RootPath, _sitecore8Website.RootPath, accordionContainerItemPath))
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
                                    migrationLogger.LogFailedInsert(typeof(AccordionItem), accordionContainerItemPath, accordionItem?.ItemName, ex);
                                }
                                catch (LinkException ex)
                                {
                                    itemUpdateCounter.ChildItemsFailedToInsert++;
                                    migrationLogger.LogFailedInsert(typeof(AccordionItem), accordionContainerItemPath, accordionItem?.ItemName, ex);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
