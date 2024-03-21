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
    public class WeBlogEntryPageMigration : MigrationBase, IBlogMigration
    {
        public WeBlogEntryPageMigration(
                        ISitecore8Client sitecore8Client,
                        ISitecore9Client sitecore9Client,
                        ISitecore8Repository sitecore8Repository,
                        ILogger<WeBlogEntryPageMigration> logger,
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

        public async Task<bool> UpdateItemFields(string blogEntryPageItemId, List<SitecoreItem> blogItems = null)
        {
            string newSitecore9ItemPath = String.Empty;
            BlogEntry blogEntry = null;
            try
            {
                blogEntry = await _sitecore8Repository.GetItemById<BlogEntry>(blogEntryPageItemId);
                if (blogEntry == null)
                {
                    migrationLogger.LogError($"Unable to retrieve blog entry page using id:'{blogEntryPageItemId}'");
                    return false;
                }

                newSitecore9ItemPath = $"{_sitecore9Website.BlogHomePath}/{blogEntry.ItemName}";

                SxaBlogEntryService sxaBlogEntryService = (SxaBlogEntryService)GetSxaService(typeof(SxaBlogEntryService));
                return await sxaBlogEntryService.UpdateFields(blogEntry, _sitecore9Website.RootPath, _sitecore8Website.RootPath, newSitecore9ItemPath, _sitecore9Website.SharedItemPaths, blogItems);
            }
            catch (FailedUpdateException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(BlogEntry), newSitecore9ItemPath, blogEntry?.ItemName, ex);
                return false;
            }
            catch (LinkException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(BlogEntry), newSitecore9ItemPath, blogEntry?.ItemName, ex);
                return false;
            }
            catch (UpdateTargetNotFoundException ex)
            {
                migrationLogger.LogFailedUpdate(typeof(BlogEntry), newSitecore9ItemPath, blogEntry?.ItemName, ex);
                return false;
            }
        }
    }
}
