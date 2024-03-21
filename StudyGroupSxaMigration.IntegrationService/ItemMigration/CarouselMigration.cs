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
    public class CarouselMigration : MigrationBase, IItemMigration
    {
        public CarouselMigration(
                            ISitecore8Client sitecore8Client,
                            ISitecore9Client sitecore9Client,
                            ISitecore8Repository sitecore8Repository,
                            ILogger<CarouselMigration> logger,
                            IEnumerable<ISxaService> sxaServices,
                            ISitecore8WebsiteConfiguration sitecore8Website,
                            Sitecore9Website sitecore9Website,
                            ApplicationSettings applicationSettings)
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
        /// Retrieve all Carousel items under the Data folder for this page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            itemUpdateCounter = new ItemUpdateCounter();

            string templateId = _sitecore8Website.WebsiteTemplateIds.CarouselContainer;
            string subfolderNameForThisItemType = _sitecore8Website.PageItemSubFolders.Carousels;

            string pageItemsSubFolderForThisType = GetPageItemsSubFolderPathForItemType(pageItem, subfolderNameForThisItemType);

            var dataItems = await _sitecore8Repository.GetItemChildrenByPath<Carousel>(pageItemsSubFolderForThisType, templateId);

            // Additional checks (depending on config settings) to see if items of this type are located in any other folders under Page Items

            var itemsAreInExpectedLocation = (dataItems?.Count > 0);

            if (DoCheckForAlternativeFolders(itemsAreInExpectedLocation))
            {
                string currentItemDescription = "Carousel Container";

                var sitecoreItemList = await CheckForAlternativeFolders<Carousel>(pageItem, pageItemsSubFolderForThisType, subfolderNameForThisItemType,
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
                migrationLogger.LogDebug($"Migrating Page Carousel Items from path: '{pageItemsSubFolderForThisType}'");

                string targetPath = GetSitecore9TargetPath(pageItemsSubFolderForThisType, subfolderNameForThisItemType);

                await InsertCarouselAndSlides(dataItems, targetPath);
            }
            return itemUpdateCounter;
        }

        /// <summary>
        /// Retrieve Carousel and slide items from Sitecore 8, then insert into sitecore 9
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.Carousels))
            {
                migrationLogger.LogDebug($"Migrating Shared Carousel Items");

                List<Carousel> sitecore8Carousels = await _sitecore8Repository.GetItemChildrenByPath<Carousel>(_sitecore8Website.SharedItemFolderPaths.Carousels, _sitecore8Website.WebsiteTemplateIds.CarouselContainer);

                if (sitecore8Carousels?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8Carousels.Count} Shared Carousel Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.Carousels}' to sitcore 9 folder: '{_sitecore9Website?.SharedItemPaths.Carousels}");
                    await InsertCarouselAndSlides(sitecore8Carousels, _sitecore9Website?.SharedItemPaths.Carousels);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertCarouselAndSlides(List<Carousel> sitecore8Carousels, string insertionPath)
        {
            if (sitecore8Carousels?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 = sitecore8Carousels.Count;

                SxaCarouselService sxaCarouselService = (SxaCarouselService)GetSxaService(typeof(SxaCarouselService));
                SxaCarouselSlideService sxaCarouselSlideService = (SxaCarouselSlideService)GetSxaService(typeof(SxaCarouselSlideService));

                foreach (Carousel carousel in sitecore8Carousels)
                {
                    try
                    {
                        if (await sxaCarouselService.Create(carousel, insertionPath))
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
                        migrationLogger.LogFailedInsert(typeof(Carousel), insertionPath, carousel?.ItemName, failedInsertException);
                    }
                    catch (LinkException ex)
                    {
                        itemUpdateCounter.ItemsFailedToInsert++;
                        migrationLogger.LogFailedInsert(typeof(Carousel), insertionPath, carousel?.ItemName, ex);
                    }

                    string carouselItemPath = insertionPath + $"/{carousel.ItemName}";

                    if (carousel.HasChildren)
                    {
                        carousel.CarouselSlides = await _sitecore8Repository.GetChildrenById<CarouselSlide>(carousel.ItemID, _sitecore8Website.WebsiteTemplateIds.CarouselSlide);

                        if (carousel.CarouselSlides?.Count > 0)
                        {
                            itemUpdateCounter.ChildItemsFoundInSitecore8 = carousel.CarouselSlides.Count;

                            foreach (CarouselSlide slide in carousel?.CarouselSlides)
                            {
                                try
                                {
                                    if (await sxaCarouselSlideService.Create(slide, carouselItemPath, _sitecore9Website.RootPath, _sitecore8Website.RootPath))
                                    {
                                        itemUpdateCounter.ChildItemsMigrated++;
                                    }
                                    else
                                    {
                                        itemUpdateCounter.ChildItemsSkipped++;
                                    }
                                }
                                catch (FailedInsertException failedInsertException)
                                {
                                    itemUpdateCounter.ChildItemsFailedToInsert ++;
                                    migrationLogger.LogFailedInsert(typeof(CarouselSlide), carouselItemPath, slide?.ItemName, failedInsertException);
                                }
                                catch (LinkException ex)
                                {
                                    itemUpdateCounter.ChildItemsFailedToInsert++;
                                    migrationLogger.LogFailedInsert(typeof(CarouselSlide), carouselItemPath, slide?.ItemName, ex);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
