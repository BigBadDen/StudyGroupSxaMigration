using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Logging.Exceptions;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Threading.Tasks;
namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaContentPageService : SxaServiceBase, ISxaService
    {
        public SxaContentPageService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaContentPageService> logger,
                                        ApplicationSettings applicationSettings,
                                        RichTextFieldMigration richTextFieldMigration) :
                base(sitecore9Client,
                    logger,
                    applicationSettings,
                    sitecore8Client: null,
                    richTextFieldMigration: richTextFieldMigration)
        {
        }


        /// <summary>
        /// Retrieve the Update the SxaContentPageItem fields (meta data fields)
        /// </summary>
        /// <param name="blogEntry"></param>
        /// <param name="insertionPath"></param>
        /// <returns></returns>
        public async Task<bool> UpdateFields(ContentPageItem contentPageItem, string targetItemPath, SitecoreItem itemInSitecore9)
        {
            migrationLogger.LogDebug($"Updating contentPageItem item:'{contentPageItem?.ItemName}' to Sitecore 9 path: '{targetItemPath}'");

            SxaPageItem sxaPageItem = new ContentPageMapper().Map(contentPageItem);
            sxaPageItem.ItemID = itemInSitecore9.ItemID;

            return await _sitecore9Client.UpdateItem<SxaPageItem>(sxaPageItem, targetItemPath);
        }
    }
}
