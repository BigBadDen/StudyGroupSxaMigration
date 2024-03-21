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
    public class ContentBoxMigration : MigrationBase, IItemMigration
    {
        public ContentBoxMigration(
                            ISitecore8Client sitecore8Client,
                            ISitecore9Client sitecore9Client,
                            ISitecore8Repository sitecore8Repository,
                            ILogger<ContentBoxMigration> logger,
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
                            applicationSettings )
        {
            this.HasHierarchicalItemStructure = false;
        }

        /// <summary>
        /// Retrieve all and migrate all Content Box under the Data folder for this page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            itemUpdateCounter = new ItemUpdateCounter();

            string templateId = _sitecore8Website.WebsiteTemplateIds.ContentBox;
            string subfolderNameForThisItemType = _sitecore8Website.PageItemSubFolders.ContentBoxes;

            string pageItemsSubFolderForThisType = GetPageItemsSubFolderPathForItemType(pageItem, subfolderNameForThisItemType);

            var dataItems = await _sitecore8Repository.GetItemChildrenByPath<ContentBox>(pageItemsSubFolderForThisType, templateId);

            // Additional checks (depending on config settings) to see if items of this type are located in any other folders under Page Items

            var itemsAreInExpectedLocation = (dataItems?.Count > 0);

            if (DoCheckForAlternativeFolders(itemsAreInExpectedLocation))
            {
                string currentItemDescription = "Content Box";

                var sitecoreItemList = await CheckForAlternativeFolders<ContentBox>(pageItem, pageItemsSubFolderForThisType, subfolderNameForThisItemType,
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
                string targetPath = GetSitecore9TargetPath(pageItemsSubFolderForThisType, subfolderNameForThisItemType);

                if (_applicationSettings.CreateSubFoldersIfMissing)
                {
                    SxaFolderService sxaFolderService = (SxaFolderService)GetSxaService(typeof(SxaFolderService));
                    await sxaFolderService.Create(Sitecore9Folders.PageDataSubFolders.Texts, targetPath);
                }

                targetPath = $"{targetPath}/{Sitecore9Folders.PageDataSubFolders.Texts}";

                migrationLogger.LogDebug($"Migrating Page Data Content Box Items from path: '{pageItemsSubFolderForThisType}'");

                if (dataItems.Count > 0)
                {
                    await InsertContentBoxes(dataItems, targetPath);
                }
            }
            return itemUpdateCounter;
        }

        /// <summary>
        /// Retrieve Content box items from Sitecore 8, then insert into sitecore 9 as SXA Texts
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.ContentBoxes))
            {
                migrationLogger.LogDebug($"Migrating Shared Content Box Items");

                List<ContentBox> sitecore8ContentBoxes = await _sitecore8Repository.GetItemChildrenByPath<ContentBox>(_sitecore8Website.SharedItemFolderPaths.ContentBoxes, _sitecore8Website.WebsiteTemplateIds.ContentBox);

                if (sitecore8ContentBoxes?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8ContentBoxes.Count} Shared Content Box Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.ContentBoxes}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.Texts}");
                    await InsertContentBoxes(sitecore8ContentBoxes, _sitecore9Website.SharedItemPaths.Texts);
                }
            }
            return itemUpdateCounter;
        }

        /// <summary>
        /// InsertContentBoxes
        /// </summary>
        /// <param name="sitecore8ContentBoxes"></param>
        /// <param name="insertionPath"></param>
        /// <returns>itemUpdateCounter - this is only for when the method is called directly for miscellaneous shared items</returns>
        public async Task<ItemUpdateCounter> InsertContentBoxes(List<ContentBox> sitecore8ContentBoxes, string insertionPath)
        {
            if (sitecore8ContentBoxes?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8ContentBoxes.Count;

                SxaContentBoxService sxaContentBoxService = (SxaContentBoxService)GetSxaService(typeof(SxaContentBoxService));

                foreach (ContentBox contentBox in sitecore8ContentBoxes)
                {
                    try
                    {
                        if (await sxaContentBoxService.Create(contentBox, _sitecore9Website.RootPath, _sitecore8Website.RootPath, insertionPath))
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
                        migrationLogger.LogFailedInsert(typeof(ContentBox), insertionPath, contentBox?.ItemName, failedInsertException);
                    }
                    catch (LinkException ex)
                    {
                        itemUpdateCounter.ItemsFailedToInsert++;
                        migrationLogger.LogFailedInsert(typeof(ContentBox), insertionPath, contentBox?.ItemName, ex);
                    }
                }
            }
            return itemUpdateCounter;
        }
    }
}
