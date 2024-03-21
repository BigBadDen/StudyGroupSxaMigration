using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.Logging;
using StudyGroupSxaMigration.Logging.Exceptions;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.LinkHelpers
{
    public class LinkMigrationBase
    {
        internal ISitecore8Client _sitecore8Client;
        internal ISitecore9Client _sitecore9Client;
        internal ILogger _logger;
        internal MigrationLogger migrationLogger;
        private readonly ApplicationSettings _applicationSettings;

        public enum InternalLinkType { MediaLink, InternalItemLink, ImageField }

        public enum SitecoreFieldType { RichText, Image }

        internal bool throwSitecore8BrokenItemLinkExceptions, throwSitecore8BrokenMediaLinkExceptions, throwSitecore9ItemLinkExceptions, throwSitecore9MediaLinkMigrationExceptions;

        public LinkMigrationBase(ISitecore8Client sitecore8Client, ISitecore9Client sitecore9Client, ILogger logger, ApplicationSettings applicationSettings)
        {
            _sitecore8Client = sitecore8Client;
            _sitecore9Client = sitecore9Client;
            _logger = logger;
            _applicationSettings = applicationSettings;
            migrationLogger = new MigrationLogger(_applicationSettings, logger);

            throwSitecore8BrokenItemLinkExceptions = _applicationSettings.ExceptionSettings.SkipItemsWithSitecore8BrokenItemLinks;
            throwSitecore8BrokenMediaLinkExceptions = _applicationSettings.ExceptionSettings.SkipItemsWithSitecore8BrokenMediaLinks;
            throwSitecore9ItemLinkExceptions = _applicationSettings.ExceptionSettings.SkipItemsWithSitecore9BrokenItemLinks;
            throwSitecore9MediaLinkMigrationExceptions = _applicationSettings.ExceptionSettings.SkipItemsWithSitecore9BrokenMediaLinks;
        }

        /// <summary>
        /// Returns part of a field value that immediately precedes the id in a link, depending on what type of link it is 
        /// </summary>
        /// <param name="internalLinkType">InternalLinkType.ItemLink, InternalLinkType.MediaLink or InternalLinkType.ImageField </param>
        /// <returns></returns>
        internal static string GetLinkStart(InternalLinkType internalLinkType)
        {
            switch (internalLinkType)
            {
                case InternalLinkType.InternalItemLink:
                    return "<a href=\"~/link.aspx?_id=";

                case InternalLinkType.MediaLink:
                    return "<a href=\"-/media/";

                default:
                    return "<image mediaid=\"";
            }
        }

        /// <summary>
        /// Validates a Guid string that's been retrieved from a sitecore 8 link field. If it's invalid, logs the error. Also throws exception if this behaviour is configured in appsettings
        /// </summary>
        /// <param name="targetIdInSitecore8WithoutDashes"></param>
        /// <param name="linkType"></param>
        /// <param name="targetGuidInSitecore8"></param>
        /// <returns></returns>
        internal bool ValidateSitecore8Guid(string targetIdInSitecore8WithoutDashes, InternalLinkType linkType, out Guid targetGuidInSitecore8)
        {
            if (!Guid.TryParse(targetIdInSitecore8WithoutDashes, out targetGuidInSitecore8))
            {
                var ex = new Sitecore8BrokenMediaLinkException($"Broken link in {linkType.ToString()} field. ID is not a valid Guid:'{targetIdInSitecore8WithoutDashes}'");
                migrationLogger.LogError($"Invalid Guid:'{targetIdInSitecore8WithoutDashes}'", ex);
                if (throwSitecore8BrokenItemLinkExceptions)
                {
                    throw ex;
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates a media link before migrating. Media item ids remain the same in both environments, so there is no conversion at this stage, 
        /// but we validate the links in rich text fields to ensure they are valid
        /// </summary>
        /// <param name="targetId"></param>
        /// <returns></returns>
        public async Task ValidateMediaLink(string targetId,  SitecoreFieldType sitecoreFieldType)
        {
            // does it exist in Sitecore 8?

            SitecoreItem mediaItemInSitecore8 = await _sitecore8Client.GetItem<SitecoreItem>(targetId);
            if (mediaItemInSitecore8 == null)
            {
                var ex = new Sitecore8BrokenItemLinkException($"Broken media link in {sitecoreFieldType.ToString()} field", targetId);
                migrationLogger.LogError($"Broken sitecore 8 media link. Expected media item id:{targetId}", ex);
                if (throwSitecore8BrokenMediaLinkExceptions)
                {
                    throw ex;
                }
                return;
            }

            // does it exist in Sitecore 9?

            SitecoreItem mediaItemInSitecore9 = await _sitecore9Client.GetItemById<SitecoreItem>(targetId);
            if (mediaItemInSitecore9 == null)
            {
                var ex = new Sitecore9BrokenMediaLinkException($"Media item item does not exist in Sitecore 9 for {sitecoreFieldType.ToString()} field. Item id:{targetId}. Sitecore 8 media item path: '{mediaItemInSitecore8.ItemPath}'");
                migrationLogger.LogError("Media link target not found in Sitecore 9", ex);
                if (throwSitecore9MediaLinkMigrationExceptions)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Converts internal item link from Sitecore 8 to Sitecore 9
        /// </summary>
        /// <param name="currentSectionOfRichTextField"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="targetItem"></param>
        /// <param name="updatedRichTextField"></param>
        /// <param name="targetIdInSitecore8WithoutDashes"></param>
        /// <param name="targetIdInSitecore8"></param>
        /// <returns></returns>
        internal async Task<string> ConvertInternalItemLink(string currentSectionOfRichTextField, string sxaSiteRootPath,
                                                                        string sitecore8SiteRootPath, string updatedRichTextField,
                                                                        string targetIdInSitecore8WithoutDashes, string targetIdInSitecore8)
        {
            // does it exist in Sitecore 8?

            SitecoreItem targetItem = await _sitecore8Client.GetItem<SitecoreItem>(targetIdInSitecore8);

            if (targetItem == null)
            {
                var ex = new Sitecore8BrokenItemLinkException("Broken link in Sitecore 8 rich text field", targetIdInSitecore8);
                migrationLogger.LogError($"Sitecore 8 broken link in rich text field.", ex);
                if (throwSitecore8BrokenItemLinkExceptions)
                {
                    throw ex;
                }
                return updatedRichTextField;
            }

            // does it exist in Sitecore 9?

            string pathToTargetItem = $"{sxaSiteRootPath}/{targetItem?.ItemPath?.Replace(sitecore8SiteRootPath, "")}";

            SitecoreItem targetItemInSitecore9 = await _sitecore9Client.GetItemByPath<SitecoreItem>(pathToTargetItem);

            if (targetItemInSitecore9?.ItemID != null)
            {
                string targetIdInSitecore9WithoutDashes = targetItemInSitecore9.ItemID?.Replace("-", "");
                updatedRichTextField = currentSectionOfRichTextField.Replace(targetIdInSitecore8WithoutDashes, targetIdInSitecore9WithoutDashes);
            }
            else
            {
                var ex = new BrokenItemLinkSitecore9Exception($"Unable to retrieve rich text link target in Sitecore 9. Sitecore 8 link target id:'{targetIdInSitecore8}'. Sitecore 8 link target item: '{targetItem.ItemPath}'");
                migrationLogger.LogError($"Rich text internal link target not found in Sitecore 9", ex);
                if (throwSitecore9ItemLinkExceptions)
                {
                    throw ex;
                }
            }
            return updatedRichTextField;
        }
    }
}
