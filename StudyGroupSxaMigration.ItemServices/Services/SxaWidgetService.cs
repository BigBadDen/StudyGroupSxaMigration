using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaWidgetService : SxaServiceBase, ISxaService
    {
        public SxaWidgetService(ISitecore9Client sitecore9Client,
                                     ILogger<SxaWidgetService> logger,
                                     ApplicationSettings applicationSettings,
                                     RichTextFieldMigration richTextFieldMigration,
                                     ImageFieldMigration imageFieldMigration,
                                     LinkFieldMigration linkFieldMigration) :
             base(sitecore9Client,
                 logger,
                 applicationSettings,
                 sitecore8Client: null,
                 richTextFieldMigration: richTextFieldMigration,
                 imageFieldMigration: imageFieldMigration,
                 linkFieldMigration: linkFieldMigration)
        {
        }

        /// <summary>
        /// Creates widget item in sitecore 9 website. Also converts internal links in the content rich text field
        /// </summary>
        /// <param name="sitecore8Widget"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="insertionPath"></param>        
        /// <returns></returns>
        public async Task<bool> Create(Widget sitecore8Widget, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting New Widget Item:'{sitecore8Widget?.ItemName}' to path: '{insertionPath}'");

            SgSxaWidget sgSxaWidget = await ConvertAndValidate(new WidgetMapper().Map(sitecore8Widget), sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return (sgSxaWidget == null ? false : await _sitecore9Client.CreateItem<SgSxaWidget>(sgSxaWidget, insertionPath));
        }

        private async Task<SgSxaWidget> ConvertAndValidate(SgSxaWidget sgSxaWidget, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            //content field
            var convertedContent = await _richTextFieldMigration.ValidateAndConvertLinks(sgSxaWidget.WidgetContent, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sgSxaWidget.WidgetContent))
            {
                migrationLogger.LogTrace($"Converting field 'Content' in SgSxaWidget item:'{sgSxaWidget?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sgSxaWidget.WidgetContent}' After:'{convertedContent}' ");
                sgSxaWidget.WidgetContent = convertedContent;
            }

            //image field
            convertedContent = await _imageFieldMigration.ValidateImageField(sgSxaWidget.WidgetImage);
            if (!String.Equals(convertedContent, sgSxaWidget.WidgetImage))
            {
                migrationLogger.LogTrace($"Converting field 'Image' in sgSxaWidget during image validation item:'{sgSxaWidget?.ItemName}' path: '{sgSxaWidget?.ItemPath}' Before:'{sgSxaWidget.WidgetImage}' After:'{convertedContent}' ");
                sgSxaWidget.WidgetImage = convertedContent;
            }

            //link field
            convertedContent = await _linkFieldMigration.ConvertInternalLinksWithCustomText(sgSxaWidget.WidgetLink, sgSxaWidget.WidgetLinkText, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sgSxaWidget.WidgetLink))
            {
                migrationLogger.LogTrace($"Converting field 'Link' in sgSxaWidget item:'{sgSxaWidget?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sgSxaWidget.WidgetLink}' After:'{convertedContent}'");
                sgSxaWidget.WidgetLink = convertedContent;
            }

            return sgSxaWidget;
        }
    }
}
