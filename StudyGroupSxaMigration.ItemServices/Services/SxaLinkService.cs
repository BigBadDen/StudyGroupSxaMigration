using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Logging.Exceptions;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaLinkService : SxaServiceBase, ISxaService
    {
        public SxaLinkService(
                            ISitecore9Client sitecore9Client,
                            ILogger<SxaLinkService> logger,
                            ApplicationSettings applicationSettings,
                            ISitecore8Client sitecore8Client,
                            LinkFieldMigration linkFieldMigration
                            )
                            : base(sitecore9Client, logger, applicationSettings, sitecore8Client, linkFieldMigration)
        {
        }

        /// <summary>
        /// Insert new sxa link from CallToAction object
        /// Records no. of items successfully inserted and also the no. of failures. Nb. if the item already exists, it not counted as either.
        /// </summary>
        /// <param name="cta"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="parentItemPath"></param>
        /// <returns></returns>
        public async Task<bool> Create(CallToAction cta, string sxaSiteRootPath, string sitecore8SiteRootPath, string parentItemPath)
        {
            migrationLogger.LogDebug($"Inserting new link item: '{cta?.ItemName}' to path: '{parentItemPath}'");

            SxaLink link = await ConvertAndValidate(new CtaToLinkMapper().Map(cta), sxaSiteRootPath, sitecore8SiteRootPath, parentItemPath);

            return await _sitecore9Client.CreateItem<SxaLink>(link, parentItemPath);
        }

        /// <summary>
        /// Insert new sxa link from list of ids - using for Header and Footer Links Migration
        /// </summary>
        /// <param name="itemIdList"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="parentItemPath"></param>
        /// <returns>succeeded: succeeded, skipped: alreadyExisted, failed: failed</returns>
        public async Task<(int, int, int)> Create(string[] itemIdList, string sxaSiteRootPath, string sitecore8SiteRootPath, string parentItemPath)
        {
            int failed = 0, succeeded = 0, alreadyExisted = 0;

            if (itemIdList?.Any() == true)
            {
                migrationLogger.LogDebug($"Inserting new link items to path: '{parentItemPath}'");

                for (int i = 0; i < itemIdList.Length; i++)
                {
                    try
                    {
                        SitecoreItem targetItemInSitecore8 = await _sitecore8Client.GetItem<SitecoreItem>(itemIdList[i]);

                        if (targetItemInSitecore8 == null || String.IsNullOrEmpty(targetItemInSitecore8.ItemID))
                        {
                            var ex = new Sitecore8BrokenItemLinkException("Broken link in Sitecore 8 link field", itemIdList[i]);
                            migrationLogger.LogError($"Sitecore 8 broken link in link field.", ex);
                            failed++;
                        }
                        else
                        {
                            var link = $"<link text=\"\" anchor=\"\" linktype=\"internal\" class=\"\" title=\"\" target=\"\" querystring=\"\" id=\"{itemIdList[i]}\" />";

                            SxaLink sxaLink = new SxaLink()
                            {
                                Link = link,
                                ItemName = targetItemInSitecore8.ItemName,
                                DisplayName = targetItemInSitecore8.DisplayName,
                                TemplateID = SxaTemplateIds.Link
                            };

                            sxaLink = await ConvertAndValidate(sxaLink, sxaSiteRootPath, sitecore8SiteRootPath, parentItemPath);

                            if (await _sitecore9Client.CreateItem<SxaLink>(sxaLink, parentItemPath))
                            {
                                succeeded++;
                            }
                            else
                            {
                                alreadyExisted++;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        migrationLogger.LogError("Unepected error during insertion of SxaLink", ex);
                        failed++;
                    }
                }

                migrationLogger.LogDebug($"Inserted new link items to path: '{parentItemPath}' succeeded: {succeeded} - failed: {failed} - already existed in target location: {alreadyExisted}");
            }
            return (succeeded, alreadyExisted, failed);
        }

        private async Task<SxaLink> ConvertAndValidate(SxaLink sxaLink, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            var convertedLink = await _linkFieldMigration.ConvertInternalLinks(sxaLink.Link, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedLink, sxaLink.Link))
            {
                migrationLogger.LogTrace($"Converting field 'Link' in Sxa Link item:'{sxaLink?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sxaLink.Link}' After:'{convertedLink}'");
                sxaLink.Link = convertedLink;
            }
            return sxaLink;
        }
    }
}
