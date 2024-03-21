using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.IntegrationService.ItemMigration;
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
    public class WeBlogHomePageMigration : MigrationBase, IBlogMigration
    {
        public WeBlogHomePageMigration(
                          ISitecore8Client sitecore8Client,
                          ISitecore9Client sitecore9Client,
                          ISitecore8Repository sitecore8Repository,
                          ILogger<WeBlogHomePageMigration> logger,
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
        /// Work out insertion path then call the sxaBlogHomeService to validate and perform field update
        /// </summary>
        /// <param name="blogPageItemId"></param>
        /// <returns></returns>
        public async Task<bool> UpdateItemFields(string blogPageItemId, List<SitecoreItem> blogItems = null)
        {
            string newSitecore9ItemPath = String.Empty;
            BlogHome blogHomeItem = null;
            try
            {
                blogHomeItem = await _sitecore8Repository.GetItemById<BlogHome>(blogPageItemId);
                if (blogHomeItem == null)
                {
                    migrationLogger.LogError($"Unable to retrieve blog home page using id:'{blogPageItemId}'");
                    return false;
                }

                newSitecore9ItemPath = blogHomeItem.ItemPath.Replace(_sitecore8Website.RootPath, $"{_sitecore9Website.RootPath}/");

                SxaBlogHomeService sxaBlogHomeService = (SxaBlogHomeService)GetSxaService(typeof(SxaBlogHomeService));

                return await sxaBlogHomeService.UpdateFields(blogHomeItem, newSitecore9ItemPath);
            }
            catch (FailedUpdateException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(BlogHome), newSitecore9ItemPath, blogHomeItem?.ItemName, ex);
                return false;
            }
            catch (LinkException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(BlogHome), newSitecore9ItemPath, blogHomeItem?.ItemName, ex);
                return false;
            }
            catch (UpdateTargetNotFoundException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(BlogHome), newSitecore9ItemPath, blogHomeItem?.ItemName, ex);
                return false;
            }
        }
    }
}
