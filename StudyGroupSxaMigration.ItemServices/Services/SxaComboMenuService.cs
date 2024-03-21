using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using System;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaComboMenuService : SxaServiceBase, ISxaService
    {
        public SxaComboMenuService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaComboMenuService> logger,
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

        public async Task<bool> Create(ComboMenuItem sitecore8ComboMenuItem, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting New ComboMenu Item:'{sitecore8ComboMenuItem?.ItemName}' to path: '{insertionPath}'");

            SgSxaComboMenuItem sgSxaComboMenuItem = await ConvertAndValidate(new ComboMenuMapper().Map(sitecore8ComboMenuItem), sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return (sgSxaComboMenuItem == null ? false : await _sitecore9Client.CreateItem<SgSxaComboMenuItem>(sgSxaComboMenuItem, insertionPath));
        }

        private async Task<SgSxaComboMenuItem> ConvertAndValidate(SgSxaComboMenuItem sgSxaComboMenuItem, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            //link field
            var convertedContent = await _linkFieldMigration.ConvertInternalLinks(sgSxaComboMenuItem.Link, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sgSxaComboMenuItem.Link))
            {
                migrationLogger.LogTrace($"Converting field 'Link' in sgSxaComboMenuItem :'{sgSxaComboMenuItem?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sgSxaComboMenuItem.Link}' After:'{convertedContent}'");
                sgSxaComboMenuItem.Link = convertedContent;
            }
            return sgSxaComboMenuItem;
        }
    }
}
