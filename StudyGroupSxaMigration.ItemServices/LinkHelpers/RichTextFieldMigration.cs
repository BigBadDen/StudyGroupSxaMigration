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
using static StudyGroupSxaMigration.Logging.MigrationLogger;

namespace StudyGroupSxaMigration.ItemServices.LinkHelpers
{
    public class RichTextFieldMigration : LinkMigrationBase
    {
        public RichTextFieldMigration(ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ILogger<RichTextFieldMigration> logger,
                                ApplicationSettings applicationSettings) :
                            base(sitecore8Client,
                                sitecore9Client,
                                logger,
                                applicationSettings)
        {
        }

        /// <summary>
        /// For Rich Text field, convert internal links for:
        ///         a) item links, then,
        ///         b) media links
        /// </summary>
        /// <param name="richTextContent"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <returns></returns>
        public async Task<string> ValidateAndConvertLinks(string richTextContent, string sxaSiteRootPath, string sitecore8SiteRootPath)
        {
            string convertedRichTextContent = await FindInternalLinksInRichTextField(InternalLinkType.InternalItemLink, richTextContent, sxaSiteRootPath, sitecore8SiteRootPath);
            convertedRichTextContent = await FindInternalLinksInRichTextField(InternalLinkType.ImageField, convertedRichTextContent, sxaSiteRootPath, sitecore8SiteRootPath);
            return await FindInternalLinksInRichTextField(InternalLinkType.MediaLink, convertedRichTextContent, sxaSiteRootPath, sitecore8SiteRootPath);
        }

        /// <summary>
        /// There may be links to internal sitecore items in the rich text field. Images are fine, but for links to other sitecore 
        /// pages, we need to convert them so they link to the correct item in sitecore 9
        /// </summary>
        /// <param name="linkType"></param>
        /// <param name="richTextContent"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <returns></returns>
        public async Task<string> FindInternalLinksInRichTextField(InternalLinkType linkType, string richTextContent, string sxaSiteRootPath, string sitecore8SiteRootPath)
        {
            string theLinkString = (linkType == InternalLinkType.InternalItemLink ? "<a href=\"~/link.aspx?_id=" : ( linkType == InternalLinkType.MediaLink ? "<a href=\"-/media/" : "<img"));

            if(string.IsNullOrWhiteSpace(richTextContent))
            {
                return richTextContent;
            }

            int occurenceOfLinkString = richTextContent.IndexOf(theLinkString);
            if (occurenceOfLinkString < 0)
            {
                return richTextContent;
            }

            StringBuilder outputString = new StringBuilder();

            var richTextFieldParts = richTextContent.Split(theLinkString, StringSplitOptions.None);

            migrationLogger.LogTrace($"{linkType.ToString()} links exist in the rich text field. Total no:{richTextFieldParts.Length}");

            int index = 0;

            foreach (string richTextFieldPart in richTextFieldParts)
            {
                //prepend the link string UNLESS we're at the beginning of the rich text field AND the link search term DOES NOT appear at the beginning of the field content

                string currentSectionOfRichTextField = (index > 0 || (index == 0 && occurenceOfLinkString == 0)) ? theLinkString + richTextFieldPart : richTextFieldPart;
                string thisPartWithUpdatedLinks = await ValidateAndConvertLinks(linkType, theLinkString, currentSectionOfRichTextField, sxaSiteRootPath, sitecore8SiteRootPath);

                outputString.Append(thisPartWithUpdatedLinks);

                index++;
            }
            return outputString.ToString();
        }

        /// <summary>
        /// Validates the current section of the rich text field. 
        /// For media links, this step is validation-only. 
        /// For non-media internal item links, this method makes a further method call to convert the link id to the equivalent id in sitecore 9.
        /// The expected format of the link ID for Rich Text fields is 6AA3B704C78643CDA585E3608BDFB7E9 i.e. the guid does NOT contain dashes
        /// </summary>
        /// <param name="startOfLinkString">This is the first part of the link that immediately precedes the id e.g. a href=\'~/link.aspx?_id="</param>
        /// <param name="currentSectionOfRichTextField">The rich text field will have been split into sections before calling this method. This field contains the current section</param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <returns></returns>
        private async Task<string> ValidateAndConvertLinks(InternalLinkType linkType,
                                                            string startOfLinkString,
                                                            string currentSectionOfRichTextField,
                                                            string sxaSiteRootPath,
                                                            string sitecore8SiteRootPath)
        {
            //migrationLogger.LogTrace($"Converting links in this part of the rich text field:'{currentSectionOfRichTextField}'");

            const int guidLengthWithoutDashes = 32;
            string updatedRichTextField = currentSectionOfRichTextField;

            int startOfIdAttribute = currentSectionOfRichTextField.IndexOf(startOfLinkString);
            if (startOfIdAttribute == -1)
            {
                return updatedRichTextField;
            }

            if (currentSectionOfRichTextField.Length >= startOfIdAttribute + startOfLinkString.Length + guidLengthWithoutDashes)
            {
                string targetIdInSitecore8WithoutDashes;
                if (linkType == InternalLinkType.ImageField)
                {
                    var dict = await GetTargetIdInSitecore8WithoutDashesFromImgTag(currentSectionOfRichTextField, guidLengthWithoutDashes);
                    updatedRichTextField = dict["currentString"];
                    targetIdInSitecore8WithoutDashes = dict["itemId"];
                }
                else
                {
                    targetIdInSitecore8WithoutDashes = currentSectionOfRichTextField.Substring(startOfIdAttribute + startOfLinkString.Length, guidLengthWithoutDashes);
                }

                if (ValidateSitecore8Guid(targetIdInSitecore8WithoutDashes, linkType, out Guid targetGuidInSitecore8))
                {
                    // for media library links, validate the link. For other internal item links, convert the id to the equivalent sitecore 9 item id

                    if (linkType == InternalLinkType.MediaLink || linkType == InternalLinkType.ImageField)
                    {
                        await ValidateMediaLink(targetGuidInSitecore8.ToString(), SitecoreFieldType.RichText);
                    }
                    else
                    {
                        updatedRichTextField = await ConvertInternalItemLink(currentSectionOfRichTextField,
                                                                            sxaSiteRootPath,
                                                                            sitecore8SiteRootPath,
                                                                            updatedRichTextField,
                                                                            targetIdInSitecore8WithoutDashes,
                                                                            targetGuidInSitecore8.ToString());
                    }
                }
            }
            return updatedRichTextField;
        }

        /// <summary>
        /// get the id without dashes of target item in sitecore 8
        /// </summary>
        /// <param name="currentSectionString"></param>
        /// <param name="guidLengthWithoutDashes"></param>
        /// <returns>a dictionary with two elements: itemId and currentString</returns>
        private async Task<Dictionary<string, string>> GetTargetIdInSitecore8WithoutDashesFromImgTag(string currentSectionString, int guidLengthWithoutDashes)
        {
            //get index of img end tag
            int index = currentSectionString.IndexOf("/>");
            index = index > 0 ? index : (currentSectionString.IndexOf(">"));
            var mediaString = "src=\"-/media/";

            if (index == -1)
            {
                return new Dictionary<string, string>() { { "itemId", null }, { "currentString", currentSectionString } };
            }

            string imgTag = currentSectionString.Substring(0, index); //expect value: <img alt="" height="260" width="370" src="-/media/1B0DE400B5624CB08B92014CB4C540BB.ashx" />
            index = imgTag.IndexOf(mediaString);

            if (index == -1)
            {
                return new Dictionary<string, string>() { { "itemId", null }, { "currentString", currentSectionString } };
            }

            //check src value id guid or media file path
            int startIndex = imgTag.IndexOf(mediaString) + mediaString.Length;
            var stringAfterMedia = imgTag.Substring(startIndex, imgTag.IndexOf("\"", startIndex) - startIndex); //expect value: 1B0DE400B5624CB08B92014CB4C540BB.ashx or Corporate-Site/images/Pay/UKEU_Card_Logos.jpg

            if (stringAfterMedia.Contains("/")) //src value contain media file path
            {
                var itemPath = ($"/sitecore/media library/{stringAfterMedia}");
                //convert media file path to media item path by remove file extension and replace "-" by space, expect: /sitecore/media library/Corporate Site/images/Pay/UKEU_Card_Logos
                itemPath = itemPath.Replace("-", " ").Substring(0, itemPath.LastIndexOf("."));
                var mediaItem = await _sitecore8Client.GetItemByPath<SitecoreItem>(itemPath, true); //get media item by the item path

                if (mediaItem != null) //if found any item by the item path above, go replace the original file path by item id with dashes
                {
                    currentSectionString = currentSectionString.Replace(stringAfterMedia, $"{mediaItem.ItemID.Replace("-", string.Empty)}.ashx");
                    return new Dictionary<string, string>() { { "itemId", mediaItem.ItemID }, { "currentString", currentSectionString } };
                }
                else
                    return new Dictionary<string, string>() { { "itemId", null }, { "currentString", currentSectionString } };
            }
            else //src value contain guid
            {
                return new Dictionary<string, string>() { { "itemId", imgTag.Substring(index + mediaString.Length, guidLengthWithoutDashes) }, { "currentString", currentSectionString } };
            }
        }
    }
}
