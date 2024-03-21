using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaContentBoxService : SxaServiceBase, ISxaService
    {
        public SxaContentBoxService(ISitecore9Client sitecore9Client,
                                     ILogger<SxaContentBoxService> logger,
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
        /// Creates content box item in sitecore 9 website. Also converts internal links in the content rich text field
        /// </summary>
        /// <param name="sitecore8ContentBox"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="insertionPath"></param>        
        /// <returns></returns>
        public async Task<bool> Create(ContentBox sitecore8ContentBox, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting New ContentBox Item:'{sitecore8ContentBox?.ItemName}' to path: '{insertionPath}'");

            SxaText sxaText = await ConvertAndValidate(new ContentBoxToTextMapper().Map(sitecore8ContentBox), sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return (sxaText == null ? false : await _sitecore9Client.CreateItem<SxaText>(sxaText, insertionPath));
        }

        private async Task<SxaText> ConvertAndValidate(SxaText sxaText, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            var convertedContent = await _richTextFieldMigration.ValidateAndConvertLinks(sxaText.Text, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sxaText.Text))
            {
                migrationLogger.LogTrace($"Converting field 'Text' in SxaText item:'{sxaText?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sxaText.Text}' After:'{convertedContent}' ");
                sxaText.Text = convertedContent;
            }
            return sxaText;
        }
    }
}
