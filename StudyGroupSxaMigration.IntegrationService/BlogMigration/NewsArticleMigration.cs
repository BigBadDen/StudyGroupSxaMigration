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
    class NewsArticleMigration : MigrationBase, IBlogMigration
    {
        public NewsArticleMigration(
                        ISitecore8Client sitecore8Client,
                        ISitecore9Client sitecore9Client,
                        ISitecore8Repository sitecore8Repository,
                        ILogger<NewsArticleMigration> logger,
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

        /// <summary>
        /// TODO - make sure the returned bool is being handled!!
        /// </summary>
        /// <param name="newsPageItemId"></param>
        /// <returns></returns>
        public async Task<bool> UpdateItemFields(string newsPageItemId, List<SitecoreItem> blogItems = null)
        {
            string newSitecore9ItemPath = String.Empty;
            NewsArticlePage newsItem = null;

            try
            {
                newsItem = await _sitecore8Repository.GetItemById<NewsArticlePage>(newsPageItemId);
                if (newsItem == null)
                {
                    migrationLogger.LogError($"Unable to retrieve news article page using id:'{newsPageItemId}'");
                    return false;
                }

                //newSitecore9ItemPath = $"{_sitecore9Website.BlogHomePath}/{newsItem.ItemName}";
                newSitecore9ItemPath = newsItem.ItemPath.Replace(_sitecore8Website.RootPath, $"{_sitecore9Website.RootPath}/");

                SxaBlogEntryService sxaBlogEntryService = (SxaBlogEntryService)GetSxaService(typeof(SxaBlogEntryService));
                return await sxaBlogEntryService.UpdateFields(newsItem, _sitecore9Website.RootPath, _sitecore8Website.RootPath, newSitecore9ItemPath);
            }
            catch (FailedUpdateException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(NewsArticlePage), newSitecore9ItemPath, newsItem?.ItemName, ex);
                return false;
            }
            catch (LinkException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(NewsArticlePage), newSitecore9ItemPath, newsItem?.ItemName, ex);
                return false;
            }
            catch (UpdateTargetNotFoundException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(NewsArticlePage), newSitecore9ItemPath, newsItem?.ItemName, ex);
                return false;
            }
        }
    }
}
