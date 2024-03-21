using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.Logging.Exceptions;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StudyGroupSxaMigration.Logging.MigrationLogger;

namespace StudyGroupSxaMigration.ItemServices.LinkHelpers
{
    /// <summary>
    /// Helper methods for converting Link fields (not richTextFields)
    /// </summary>
    public class LinkFieldMigration : LinkMigrationBase
    {
        public LinkFieldMigration(ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ILogger<LinkFieldMigration> logger,
                                ApplicationSettings applicationSettings) :
                            base(sitecore8Client,
                                sitecore9Client,
                                logger,
                                applicationSettings)
        {
        }

        /// <summary>
        /// Find the link target item in sitecore 9. If found, create a new CTA linking to the Sitecore 9 Item
        /// </summary>
        /// <param name="linkField"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="parentItemPath"></param>
        /// <returns></returns>
        public async Task<string> ConvertInternalLinks(string linkField, string sxaSiteRootPath, string sitecore8SiteRootPath)
        {
            const int lengthOfGuidWithDashes = 36;
            string updatedLinkField = linkField;

            if(string.IsNullOrWhiteSpace(linkField))
            {
                return linkField;
            }

            if (linkField.Contains("linktype=\"internal\""))
            {
                migrationLogger.LogTrace($"Internal link field before converting: {linkField}");

                int startOfIdAttribute = linkField.IndexOf("id=\"{");
                if (linkField.Length >= startOfIdAttribute + 38)
                {
                    string targetIdInSitecore8 = linkField.Substring(startOfIdAttribute + 5, lengthOfGuidWithDashes);

                    if (ValidateSitecore8Guid(targetIdInSitecore8, InternalLinkType.InternalItemLink, out Guid targetGuidInSitecore8))
                    {
                        SitecoreItem targetItemInSitecore8 = await _sitecore8Client.GetItem<SitecoreItem>(targetIdInSitecore8);

                        if (targetItemInSitecore8 == null || String.IsNullOrEmpty(targetItemInSitecore8.ItemID))
                        {
                            var ex = new Sitecore8BrokenItemLinkException("Broken link in Sitecore 8 link field", targetIdInSitecore8);
                            migrationLogger.LogError($"Sitecore 8 broken link in link field.", ex);
                            if (throwSitecore8BrokenItemLinkExceptions)
                            {
                                throw ex;
                            }
                            return updatedLinkField;
                        }

                        string pathToTargetItem = $"{sxaSiteRootPath}/{targetItemInSitecore8.ItemPath?.Replace(sitecore8SiteRootPath, "")}";

                        SitecoreItem targetItemInSitecore9 = await _sitecore9Client.GetItemByPath<SitecoreItem>(pathToTargetItem);

                        if (targetItemInSitecore9?.ItemID != null)
                        {
                            string targetIdInSitecore9 = targetItemInSitecore9.ItemID;
                            updatedLinkField = linkField.Replace(targetIdInSitecore8, targetIdInSitecore9);
                        }
                        else
                        {
                            // Link target cannot be found in Sitecore 9
                            var ex = new BrokenItemLinkSitecore9Exception($"Unable to retrieve link field target in Sitecore 9. Sitecore 8 link target id:'{targetIdInSitecore8}'. Sitecore 8 link target: '{targetItemInSitecore8.ItemPath}'");
                            migrationLogger.LogError($"Link field target not found in Sitecore 9", ex);
                            if (throwSitecore9ItemLinkExceptions)
                            {
                                throw new LinkException("Failed to convert link", targetIdInSitecore8 ?? String.Empty);
                            }
                        }
                    }
                }
                migrationLogger.LogTrace($"Internal link field after migration: {updatedLinkField}");
            }
            return updatedLinkField;
        }

        /// <summary>
        /// Find the link target item in sitecore 9. If found, create a new CTA linking to the Sitecore 9 Item and add a custom text to this link
        /// </summary>
        /// <param name="linkField"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="parentItemPath"></param>
        /// <returns></returns>
        public async Task<string> ConvertInternalLinksWithCustomText(string linkField, string customText, string sxaSiteRootPath, string sitecore8SiteRootPath)
        {
            const int lengthOfGuidWithDashes = 36;
            string updatedLinkField = linkField;

            if (string.IsNullOrWhiteSpace(linkField))
            {
                return linkField;
            }

            if (linkField.Contains("linktype=\"internal\""))
            {
                migrationLogger.LogTrace($"Internal link field before converting: {linkField}");

                int startOfIdAttribute = linkField.IndexOf("id=\"{");
                if (linkField.Length >= startOfIdAttribute + 38)
                {
                    string targetIdInSitecore8 = linkField.Substring(startOfIdAttribute + 5, lengthOfGuidWithDashes);

                    if (ValidateSitecore8Guid(targetIdInSitecore8, InternalLinkType.InternalItemLink, out Guid targetGuidInSitecore8))
                    {
                        SitecoreItem targetItemInSitecore8 = await _sitecore8Client.GetItem<SitecoreItem>(targetIdInSitecore8);

                        if (targetItemInSitecore8 == null || String.IsNullOrEmpty(targetItemInSitecore8.ItemID))
                        {
                            var ex = new Sitecore8BrokenItemLinkException("Broken link in Sitecore 8 link field", targetIdInSitecore8);
                            migrationLogger.LogError($"Sitecore 8 broken link in link field.", ex);
                            if (throwSitecore8BrokenItemLinkExceptions)
                            {
                                throw ex;
                            }
                            return updatedLinkField;
                        }

                        string pathToTargetItem = $"{sxaSiteRootPath}/{targetItemInSitecore8.ItemPath?.Replace(sitecore8SiteRootPath, "")}";

                        SitecoreItem targetItemInSitecore9 = await _sitecore9Client.GetItemByPath<SitecoreItem>(pathToTargetItem);

                        if (targetItemInSitecore9?.ItemID != null)
                        {
                            string targetIdInSitecore9 = targetItemInSitecore9.ItemID;
                            updatedLinkField = linkField.Replace(targetIdInSitecore8, targetIdInSitecore9);
                        }
                        else
                        {
                            // Link target cannot be found in Sitecore 9
                            var ex = new BrokenItemLinkSitecore9Exception($"Unable to retrieve link field target in Sitecore 9. Sitecore 8 link target id:'{targetIdInSitecore8}'. Sitecore 8 link target: '{targetItemInSitecore8.ItemPath}'");
                            migrationLogger.LogError($"Link field target not found in Sitecore 9", ex);
                            if (throwSitecore9ItemLinkExceptions)
                            {
                                throw new LinkException("Failed to convert link", targetIdInSitecore8 ?? String.Empty);
                            }
                        }
                    }
                }

                //add custom text
                if (!string.IsNullOrEmpty(customText))
                {
                    if (updatedLinkField.IndexOf("text=\"\"") > 0)
                    {
                        updatedLinkField = updatedLinkField.Replace("text=\"\"", $"text=\"{customText}\"");
                    }
                    else if (updatedLinkField.IndexOf("<link") > 0)
                    {
                        updatedLinkField = updatedLinkField.Replace("<link", $"<link text=\"{customText}\"");
                    }
                }

                migrationLogger.LogTrace($"Internal link field after migration: {updatedLinkField}");
            }

            return updatedLinkField;
        }
    }
}
