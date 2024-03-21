using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Logging.Exceptions;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaBlogEntryService : SxaServiceBase, ISxaService
    {
        public SxaBlogEntryService(ISitecore9Client sitecore9Client,
                                       ILogger<SxaBlogEntryService> logger,
                                       ApplicationSettings applicationSettings,
                                       ISitecore8Client sitecore8Client,
                                       RichTextFieldMigration richTextFieldMigration,
                                       ImageFieldMigration imageFieldMigration,
                                       LinkFieldMigration linkFieldMigration) :
               base(sitecore9Client,
                 logger,
                 applicationSettings,
                 sitecore8Client: sitecore8Client,
                 richTextFieldMigration: richTextFieldMigration,
                 imageFieldMigration: imageFieldMigration,
                 linkFieldMigration: linkFieldMigration)
        {
        }

        /// <summary>
        /// Update the blog entry item fields, from sitecore 8 blog item. NB. Insertion path will be directly under the blog home item 
        /// </summary>
        /// <param name="blogEntry"></param>
        /// <param name="insertionPath"></param>
        /// <returns></returns>
        public async Task<bool> UpdateFields(BlogEntry blogEntry, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath, SharedItemPaths sxaSharedItemPath, List<SitecoreItem> blogItems)
        {
            migrationLogger.LogDebug($"Updating blogEntry item:'{blogEntry?.ItemName}' to path: '{insertionPath}'");

            SgSxaBlogPost sgSxaBlogPost = new BlogPostMapper().Map(blogEntry);

            sgSxaBlogPost = await ConvertAndValidateBlogPostItem(sgSxaBlogPost, sxaSiteRootPath, sitecore8SiteRootPath, insertionPath, sxaSharedItemPath, blogItems);

            return await _sitecore9Client.UpdateItem<SgSxaBlogPost>(sgSxaBlogPost, insertionPath);
        }

        /// <summary>
        /// Update the news item fields. NB. Insertion path will be directly under the blog home item 
        /// </summary>
        /// <param name="newsArticlePage"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="insertionPath"></param>
        /// <returns></returns>
        public async Task<bool> UpdateFields(NewsArticlePage newsArticlePage, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            migrationLogger.LogDebug($"Updating New Article (Blog Entry) page item:'{newsArticlePage?.ItemName}' to path: '{insertionPath}'");

            SgSxaBlogPost sgSxaBlogPost = new NewsArticlePageToBlogPostMapper().Map(newsArticlePage);

            sgSxaBlogPost = await ConvertAndValidateBlogPostItem(sgSxaBlogPost, sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return await _sitecore9Client.UpdateItem<SgSxaBlogPost>(sgSxaBlogPost, insertionPath);
        }

        private async Task<SgSxaBlogPost> ConvertAndValidateBlogPostItem(SgSxaBlogPost sgSxaBlogPost, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath,
            SharedItemPaths sxaSharedItemPath = null, List<SitecoreItem> blogItems = null)
        {
            SitecoreItem blogPostItemInSitecore9 = await _sitecore9Client.GetItemByPath<SitecoreItem>(insertionPath);

            if (blogPostItemInSitecore9 == null)
            {
                throw new UpdateTargetNotFoundException("Unable to retrieve blogPost item in sitecore 9 to update", insertionPath);
            }

            sgSxaBlogPost.ItemID = blogPostItemInSitecore9.ItemID;
            sgSxaBlogPost.ItemPath = blogPostItemInSitecore9.ItemPath;

            sgSxaBlogPost.Content = await ConvertRichTextField(sgSxaBlogPost.Content, sgSxaBlogPost?.ItemName, sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);
            sgSxaBlogPost.Introduction = await ConvertRichTextField(sgSxaBlogPost.Introduction, sgSxaBlogPost?.ItemName, sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);
            sgSxaBlogPost.PageDescription = await ConvertRichTextField(sgSxaBlogPost.PageDescription, sgSxaBlogPost?.ItemName, sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);
            sgSxaBlogPost.Image = await ConvertImageField(sgSxaBlogPost.Image, sgSxaBlogPost?.ItemName, sgSxaBlogPost?.ItemPath);
            sgSxaBlogPost.Thumbnail = await ConvertImageField(sgSxaBlogPost.Thumbnail, sgSxaBlogPost?.ItemName, sgSxaBlogPost?.ItemPath);
            sgSxaBlogPost.CannonicalLink = await ConvertLinkField(sgSxaBlogPost.CannonicalLink, sgSxaBlogPost?.ItemName, sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);
            sgSxaBlogPost.Tags = await ConvertTagField(sgSxaBlogPost.Tags, sgSxaBlogPost?.ItemName, insertionPath, sxaSharedItemPath, blogItems);

            return sgSxaBlogPost;
        }

        private async Task<string> ConvertRichTextField(string content, string itemName, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            var convertedContent = await _richTextFieldMigration.ValidateAndConvertLinks(content, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, content))
            {
                migrationLogger.LogTrace($"Converting field 'Content' in sgSxaBlogPost item:'{itemName}' sitecore 9 path: '{insertionPath}' Before:'{content}' After:'{convertedContent}' ");
                return convertedContent;
            }

            return content;
        }

        private async Task<string> ConvertImageField(string content, string itemName, string itemPath)
        {
            var convertedContent = await _imageFieldMigration.ValidateImageField(content);
            if (!String.Equals(convertedContent, content))
            {
                migrationLogger.LogTrace($"Converting field 'Image' in sgSxaBlogPost during image validation. Item:'{itemName}' Sitecore 9 item path: '{itemPath}' Image field before:'{content}' Image field after:'{convertedContent}' ");
                return convertedContent;
            }

            return content;
        }

        private async Task<string> ConvertLinkField(string content, string itemName, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            var convertedContent = await _linkFieldMigration.ConvertInternalLinks(content, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, content))
            {
                migrationLogger.LogTrace($"Converting field 'Cannonical Link' in sgSxaBlogPost item:'{itemName}' sitecore 9 path: '{insertionPath}' Before:'{content}' After:'{convertedContent}'");
                return convertedContent;
            }

            return content;
        }

        private async Task<string> ConvertTagField(string content, string itemName, string insertionPath, SharedItemPaths sxaSharedItemPath, List<SitecoreItem> blogItems)
        {
            if (!string.IsNullOrEmpty(content) && sxaSharedItemPath != null)
            {
                var sitecore8CategoryItemIds = content.Trim().Split('|');

                List<string> sitecore9TagsItemIds = new List<string>();

                foreach (var sc8CategoryItemId in sitecore8CategoryItemIds)
                {
                    var currentSC8CategoryItem = blogItems.Where(x => string.Equals(x.ItemID, sc8CategoryItemId.Replace("{", "").Replace("}", ""), StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    if (currentSC8CategoryItem != null && !string.IsNullOrEmpty(currentSC8CategoryItem.ItemID))
                    {
                        string pathToTagItem = $"{sxaSharedItemPath.Tags}/{currentSC8CategoryItem.ItemName}";
                        SitecoreItem tagItemInSitecore9 = await _sitecore9Client.GetItemByPath<SitecoreItem>(pathToTagItem);
                        if (tagItemInSitecore9 != null)
                        {
                            sitecore9TagsItemIds.Add("{" + tagItemInSitecore9.ItemID + "}");
                        }
                        else
                        {
                            var ex = new BrokenItemLinkSitecore9Exception($"The following tag is missing from Sitecore 9, so cannot be mapped to the current blog entry item. " +
                                $"'{pathToTagItem}'. Sitecore 8 category target id:'{sc8CategoryItemId}'. Sitecore 8 category target: '{currentSC8CategoryItem.ItemPath}'");

                            migrationLogger.LogError("Tag item not found in Sitecore 9", ex);
                            if (_applicationSettings.ExceptionSettings.SkipItemsWithSitecore9BrokenItemLinks)
                            {
                                throw ex;
                            }
                        }
                    }
                    else
                    {
                        var ex = new Sitecore8BrokenItemLinkException("Broken link in Sitecore 8 category field", sc8CategoryItemId);
                        migrationLogger.LogError($"Sitecore 8 broken link in category field.", ex);
                        if (_applicationSettings.ExceptionSettings.SkipItemsWithSitecore8BrokenItemLinks)
                        {
                            throw ex;
                        }
                    }
                }

                var convertedContent = String.Join("|", sitecore9TagsItemIds.ToArray());

                if (!String.Equals(convertedContent, content))
                {
                    migrationLogger.LogTrace($"Converting field 'Tags' in sgSxaBlogPost item:'{itemName}' sitecore 9 path: '{insertionPath}' Before:'{content}' After:'{convertedContent}'");
                    return convertedContent;
                }
            }

            return content;
        }
    }
}
