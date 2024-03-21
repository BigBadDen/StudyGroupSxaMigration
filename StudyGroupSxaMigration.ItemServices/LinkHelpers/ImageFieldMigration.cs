using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore9;
using System;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.LinkHelpers
{
    /// <summary>
    /// Validates the contents of Image fields. Expected raw value would be in the following format: 
    ///    <image mediaid="{BEAA81B5-7DFF-4D1D-8A9F-437BE86346EE}" />
    /// </summary>
    public class ImageFieldMigration : LinkMigrationBase
    {
        private const string theLinkString = "<image mediaid=\"";

        public ImageFieldMigration(ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ILogger<ImageFieldMigration> logger,
                                ApplicationSettings applicationSettings) :
                            base(sitecore8Client,
                                sitecore9Client,
                                logger,
                                applicationSettings)
        {
        }

        /// <summary>
        /// Validates the media link in an image field
        /// </summary>
        /// <param name="linkType"></param>
        /// <param name="imageFieldValue"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <returns></returns>
        public async Task<string> ValidateImageField(string imageFieldValue)
        {
            if(string.IsNullOrWhiteSpace(imageFieldValue))
            {
                return imageFieldValue;
            }

            int startOfIdAttribute = imageFieldValue.IndexOf(theLinkString);
            if (startOfIdAttribute >= 0)
            {
                migrationLogger.LogTrace($"Media link found in Image field '{imageFieldValue}'");
                return await ValidateImageFieldLinks(imageFieldValue, startOfIdAttribute);
            }
            else
            {
                return imageFieldValue;
            }
        }

        /// <summary>
        /// Validates an image field media link
        /// For media links, this step is validation-only. 
        /// For non-media link, this method makes a further method call to base class to convert the link id to the equivalent id in sitecore 9.
        /// The expected format of the link ID is 6AA3B704C78643CDA585E3608BDFB7E9 i.e. the guid does NOT contain dashes
        /// </summary>
        /// <param name="theLinkString">This is the first part of the link that immediately precedes the id e.g. a href=\'~/link.aspx?_id="</param>
        /// <param name="mediaLinkFieldValue">The rich text field will have been split into sections before calling this method. This field contains the current section</param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <returns></returns>
        private async Task<string> ValidateImageFieldLinks(string mediaLinkFieldValue, int startOfIdAttribute)
        {
            const int guidLengthWithDashesAndCurlyBraces = 38;
            if (mediaLinkFieldValue.Length >= startOfIdAttribute + theLinkString.Length + guidLengthWithDashesAndCurlyBraces)
            {
                string targetIdInSitecore8WithoutDashes = mediaLinkFieldValue.Substring(startOfIdAttribute + theLinkString.Length, guidLengthWithDashesAndCurlyBraces);
                if (ValidateSitecore8Guid(targetIdInSitecore8WithoutDashes, InternalLinkType.ImageField, out Guid targetGuidInSitecore8))
                {
                   await ValidateMediaLink(targetGuidInSitecore8.ToString(), SitecoreFieldType.Image);
                }
            }
            return mediaLinkFieldValue;
        }
    }
}