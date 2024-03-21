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
    public class TestimonialMigration : MigrationBase, IItemMigration
    {
        public TestimonialMigration(
                            ISitecore8Client sitecore8Client,
                            ISitecore9Client sitecore9Client,
                            ISitecore8Repository sitecore8Repository,
                            ILogger<TestimonialMigration> logger,
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
        /// Retrieve all and migrate all Testimonials under the Data folder for this page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            itemUpdateCounter = new ItemUpdateCounter();

            string templateId = _sitecore8Website.WebsiteTemplateIds.Testimonial;
            string subfolderNameForThisItemType = _sitecore8Website.PageItemSubFolders.Testimonials;

            string pageItemsSubFolderForThisType = GetPageItemsSubFolderPathForItemType(pageItem, subfolderNameForThisItemType);

            var dataItems = await _sitecore8Repository.GetItemChildrenByPath<Testimonial>(pageItemsSubFolderForThisType, templateId);

            // Additional checks (depending on config settings) to see if items of this type are located in any other folders under Page Items

            var itemsAreInExpectedLocation = (dataItems?.Count > 0);

            if (DoCheckForAlternativeFolders(itemsAreInExpectedLocation))
            {
                string currentItemDescription = "Testimonial";

                var sitecoreItemList = await CheckForAlternativeFolders<Testimonial>(pageItem, pageItemsSubFolderForThisType, subfolderNameForThisItemType,
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

                migrationLogger.LogDebug($"Migrating Page Data Testimonial Items from path: '{pageItemsSubFolderForThisType}'");

                if (dataItems.Count > 0)
                {
                    await InsertTestimonials(dataItems, targetPath);
                }
            }
            return itemUpdateCounter;
        }

        /// <summary>
        /// Retrieve Testimonial items from Sitecore 8, then insert into sitecore 9 as SgSxaTestimonial
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.Testimonials))
            {
                migrationLogger.LogDebug($"Migrating Shared Testimonial Items");

                List<Testimonial> sitecore8Testimonials = await _sitecore8Repository.GetItemChildrenByPath<Testimonial>(_sitecore8Website.SharedItemFolderPaths.Testimonials, _sitecore8Website.WebsiteTemplateIds.Testimonial);

                if (sitecore8Testimonials?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8Testimonials.Count} Shared Testimonial Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.Testimonials}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.Testimonials}");
                    await InsertTestimonials(sitecore8Testimonials, _sitecore9Website.SharedItemPaths.Testimonials);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertTestimonials(List<Testimonial> sitecore8Testimonials, string insertionPath)
        {
            if (sitecore8Testimonials?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8Testimonials.Count;

                SxaTestimonialService sxaTestimonialService = (SxaTestimonialService)GetSxaService(typeof(SxaTestimonialService));

                foreach (Testimonial testimonial in sitecore8Testimonials)
                {
                    try
                    {
                        if (await sxaTestimonialService.Create(testimonial, _sitecore9Website.RootPath, _sitecore8Website.RootPath, insertionPath))
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
                        migrationLogger.LogFailedInsert(typeof(Testimonial), insertionPath, testimonial?.ItemName, failedInsertException);
                    }
                    catch (LinkException ex)
                    {
                        itemUpdateCounter.ItemsFailedToInsert++;
                        migrationLogger.LogFailedInsert(typeof(Testimonial), insertionPath, testimonial?.ItemName, ex);
                    }
                }
            }
        }
    }
}
