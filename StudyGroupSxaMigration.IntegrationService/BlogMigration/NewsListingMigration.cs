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
using System.Text;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.IntegrationService.BlogMigration
{
    class NewsListingMigration : MigrationBase, IBlogMigration
    {
        public NewsListingMigration(
                        ISitecore8Client sitecore8Client,
                        ISitecore9Client sitecore9Client,
                        ISitecore8Repository sitecore8Repository,
                        ILogger<NewsListingMigration> logger,
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
        }

        public async Task<bool> UpdateItemFields(string newsListingPageItemId, List<SitecoreItem> blogItems = null)
        {
            string newSitecore9ItemPath = String.Empty;
            NewsListingPage newsListingPageItem = null;

            try
            {
                newsListingPageItem = await _sitecore8Repository.GetItemById<NewsListingPage>(newsListingPageItemId);
                if (newsListingPageItem == null)
                {
                    migrationLogger.LogError($"Unable to retrieve news listing page using id:'{newsListingPageItemId}'");
                    return false;
                }

                newSitecore9ItemPath = newsListingPageItem.ItemPath.Replace(_sitecore8Website.RootPath, $"{_sitecore9Website.RootPath}/");

                SxaBlogHomeService sxaBlogHomeService = (SxaBlogHomeService)GetSxaService(typeof(SxaBlogHomeService));
                return await sxaBlogHomeService.UpdateFields(newsListingPageItem, newSitecore9ItemPath);
            }
            catch (FailedUpdateException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(NewsListingPage), newSitecore9ItemPath, newsListingPageItem?.ItemName, ex);
                return false;
            }
            catch (LinkException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(NewsListingPage), newSitecore9ItemPath, newsListingPageItem?.ItemName, ex);
                return false;
            }
            catch (UpdateTargetNotFoundException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(NewsListingPage), newSitecore9ItemPath, newsListingPageItem?.ItemName, ex);
                return false;
            }
        }
    }
}
