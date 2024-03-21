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
    public class SxaTabService : SxaServiceBase, ISxaService
    {
        public SxaTabService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaTabService> logger,
                                        ApplicationSettings applicationSettings,
                                        RichTextFieldMigration richTextFieldMigration) :
                base(sitecore9Client,
                    logger,
                    applicationSettings,
                    sitecore8Client: null,
                    richTextFieldMigration: richTextFieldMigration)
        {
        }

        public async Task<bool> Create(Tab tabItem, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting new tab:'{tabItem?.ItemName}' to path: '{insertionPath}'");

            SxaTabItem sxaTabItem = await ConvertAndValidate(new TabsMapper().Map(tabItem), sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return await _sitecore9Client.CreateItem<SxaTabItem>(sxaTabItem, insertionPath);
        }

        private async Task<SxaTabItem> ConvertAndValidate(SxaTabItem sxaTabItem, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            var convertedContent = await _richTextFieldMigration.ValidateAndConvertLinks(sxaTabItem.Content, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sxaTabItem.Content))
            {
                migrationLogger.LogTrace($"Converting field 'Content' in tab item:'{sxaTabItem?.ItemName} sitecore 9 path: '{insertionPath}' Before:'{sxaTabItem.Content}' After:'{convertedContent}' ");
                sxaTabItem.Content = convertedContent;
            }
            return sxaTabItem;
        }
    }
}
