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
    public class GalleryMigration : MigrationBase, IItemMigration
    {
        public GalleryMigration(
                                ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ISitecore8Repository sitecore8Repository,
                                ILogger<GalleryMigration> logger,
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
            this.HasHierarchicalItemStructure = true;
        }

        /// <summary>
        /// Retrieve all and migrate all Gallery items under the Data folder for this page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            itemUpdateCounter = new ItemUpdateCounter();

            string templateId = _sitecore8Website.WebsiteTemplateIds.GalleryContainer;
            string subfolderNameForThisItemType = _sitecore8Website.PageItemSubFolders.Galleries;

            string pageItemsSubFolderForThisType = GetPageItemsSubFolderPathForItemType(pageItem, subfolderNameForThisItemType);

            var galleryContainers = await _sitecore8Repository.GetItemChildrenByPath<GalleryContainer>(pageItemsSubFolderForThisType, templateId);

            // Additional checks (depending on config settings) to see if items of this type are located in any other folders under Page Items

            var itemsAreInExpectedLocation = (galleryContainers?.Count > 0);

            if (DoCheckForAlternativeFolders(itemsAreInExpectedLocation))
            {
                string currentItemDescription = "Gallery Container";

                var sitecoreItemList = await CheckForAlternativeFolders<GalleryContainer>(pageItem, pageItemsSubFolderForThisType, subfolderNameForThisItemType,
                                                                                                            templateId, currentItemDescription, itemsAreInExpectedLocation);

                if (!itemsAreInExpectedLocation && sitecoreItemList.SitecoreItems?.Count > 0 && !String.IsNullOrEmpty(sitecoreItemList.FolderName) && !String.IsNullOrEmpty(sitecoreItemList.FolderPath))
                {
                    galleryContainers = sitecoreItemList.SitecoreItems;
                    pageItemsSubFolderForThisType = sitecoreItemList.FolderPath;
                    subfolderNameForThisItemType = sitecoreItemList.FolderName;
                }
            }

            // Migration

            if (galleryContainers?.Count > 0)
            {
                migrationLogger.LogDebug($"Migrating Page Data Gallery Items from path: '{pageItemsSubFolderForThisType}'");

                string targetPath = GetSitecore9TargetPath(pageItemsSubFolderForThisType, subfolderNameForThisItemType);

                await InsertGalleryContainerAndItems(galleryContainers, targetPath);
            }

            return itemUpdateCounter;
        }
        
        /// <summary>
        /// Retrieve Gallery Container items under shared items folder. For each item, copy into sitecore 9 and retrieve child items from Sitecore 8, then insert into sitecore 9
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.Galleries))
            {
                migrationLogger.LogDebug($"Migrating Shared Gallery Items");

                List<GalleryContainer> sitecore8GalleryContainers =
                    await _sitecore8Repository.GetItemChildrenByPath<GalleryContainer>(_sitecore8Website.SharedItemFolderPaths.Galleries, _sitecore8Website.WebsiteTemplateIds.GalleryContainer);

                if (sitecore8GalleryContainers?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8GalleryContainers.Count} Shared Gallery Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.Galleries}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.Galleries}");
                    await InsertGalleryContainerAndItems(sitecore8GalleryContainers, _sitecore9Website.SharedItemPaths.Galleries);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertGalleryContainerAndItems(List<GalleryContainer> sitecore8Galleries, string insertionPath)
        {
            if (sitecore8Galleries?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8Galleries.Count;

                SxaGalleryImageService sxaGalleryImage = (SxaGalleryImageService)GetSxaService(typeof(SxaGalleryImageService));
                SxaGalleryService sxaGalleryService = (SxaGalleryService)GetSxaService(typeof(SxaGalleryService));

                foreach (GalleryContainer galleryContainer in sitecore8Galleries)
                {
                    try
                    {
                        if (await sxaGalleryService.Create(galleryContainer, insertionPath))
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
                        migrationLogger.LogFailedInsert(typeof(GalleryContainer), insertionPath, galleryContainer?.ItemName, failedInsertException);
                    }

                    string galleryContainerItemPath = insertionPath + $"/{galleryContainer.ItemName}";

                    if (galleryContainer.HasChildren)
                    {
                        galleryContainer.GalleryItems = await _sitecore8Repository.GetChildrenById<GalleryItem>(galleryContainer.ItemID, _sitecore8Website.WebsiteTemplateIds.GalleryItem);

                        if (galleryContainer.GalleryItems?.Count > 0)
                        {
                            itemUpdateCounter.ChildItemsFoundInSitecore8 += galleryContainer.GalleryItems.Count;

                            foreach (GalleryItem galleryItem in galleryContainer.GalleryItems)
                            {
                                try
                                {
                                    if (await sxaGalleryImage.Create(galleryItem, galleryContainerItemPath))
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
                                    migrationLogger.LogFailedInsert(typeof(GalleryItem), galleryContainerItemPath, galleryItem?.ItemName, ex);
                                }
                                catch (LinkException ex)
                                {
                                    itemUpdateCounter.ChildItemsFailedToInsert++;
                                    migrationLogger.LogFailedInsert(typeof(GalleryItem), galleryContainerItemPath, galleryItem?.ItemName, ex);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
