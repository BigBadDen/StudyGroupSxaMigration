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

namespace StudyGroupSxaMigration.IntegrationService.ContentPageMigration
{
    public class ContentPageItemMigration : MigrationBase, IItemMigration
    {
        public ContentPageItemMigration(
                              ISitecore8Client sitecore8Client,
                              ISitecore9Client sitecore9Client,
                              ISitecore8Repository sitecore8Repository,
                              ILogger<ContentPageItemMigration> logger,
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
        /// Update the page content as required (i.e. meta tags)
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> UpdateItemFields(SitecoreItem sitecoreItem)
        {
            itemUpdateCounter = new ItemUpdateCounter();
            string newSitecore9ItemPath = String.Empty;

            try
            {
                // work out the expected path of the item in sitecore 9

                ContentPageItem sitecore8ContentPage = await _sitecore8Repository.GetItemById<ContentPageItem>(sitecoreItem?.ItemID);
                if (sitecore8ContentPage == null)
                {
                    migrationLogger.LogError($"Page update skipped!! Unable to retrieve sitecore 8 contentPageItem using id:'{sitecoreItem?.ItemID}'");
                    itemUpdateCounter.PagesSkipped++;
                }

                SxaContentPageService sxaContentPageService = (SxaContentPageService)GetSxaService(typeof(SxaContentPageService));

                newSitecore9ItemPath = sitecoreItem?.ItemPath.Replace(_sitecore8Website.HomePagePath, _sitecore9Website.HomePagePath);

                // retrieve sitecore 9 item

                SitecoreItem itemInSitecore9 = await _sitecore9Client.GetItemByPath<SitecoreItem>(newSitecore9ItemPath);

                if (itemInSitecore9 == null)
                {
                    itemUpdateCounter.PagesNotFoundInSitecore9++;
                    throw new UpdateTargetNotFoundException("Unable to update content because page item cannot be retrieved from Sitecore 9", newSitecore9ItemPath);
                }

                // update fields

                if (await sxaContentPageService.UpdateFields(sitecore8ContentPage, newSitecore9ItemPath, itemInSitecore9))
                {
                    itemUpdateCounter.PagesUpdated++;
                }
                else
                {
                    itemUpdateCounter.PagesFailedToUpdate++;
                }
            }
            catch (FailedUpdateException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(ContentPageItem), newSitecore9ItemPath, sitecoreItem?.ItemName, ex);
                itemUpdateCounter.PagesFailedToUpdate++;
            }
            catch (LinkException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(ContentPageItem), newSitecore9ItemPath, sitecoreItem?.ItemName, ex);
                itemUpdateCounter.PagesFailedToUpdate++;
            }
            catch (UpdateTargetNotFoundException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(ContentPageItem), newSitecore9ItemPath, sitecoreItem?.ItemName, ex);
                itemUpdateCounter.PagesFailedToUpdate++;
            }

            return itemUpdateCounter;
        }

        public Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            // n/a - required by interface
            throw new NotImplementedException();
        }

        public Task<ItemUpdateCounter> MigrateSharedItems()
        {
            // n/a - required by interface
            throw new NotImplementedException();
        }
    }
}
