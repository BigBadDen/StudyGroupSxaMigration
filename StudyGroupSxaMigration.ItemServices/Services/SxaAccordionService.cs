using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using System;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaAccordionService : SxaServiceBase, ISxaService
    {
        public SxaAccordionService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaAccordionService> logger,
                                        ApplicationSettings applicationSettings,
                                        RichTextFieldMigration richTextFieldMigration) :
                base(sitecore9Client,
                    logger,
                    applicationSettings,
                    sitecore8Client: null,
                    richTextFieldMigration: richTextFieldMigration)
        {
        }

        public async Task<bool> Create(AccordionItem accordionItem, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting new accordion:'{accordionItem?.ItemName}' to path: '{insertionPath}'");

            SxaAccordionItem sxaAccordionItem = await ConvertAndValidate(new AccordionMapper().Map(accordionItem), sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return sxaAccordionItem == null ? false : await _sitecore9Client.CreateItem<SxaAccordionItem>(sxaAccordionItem, insertionPath);
        }

        private async Task<SxaAccordionItem> ConvertAndValidate(SxaAccordionItem sxaAccordionItem, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            var convertedContent = await _richTextFieldMigration.ValidateAndConvertLinks(sxaAccordionItem.Content, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sxaAccordionItem.Content))
            {
                migrationLogger.LogTrace($"Converting field 'Content' in accordion item:'{sxaAccordionItem?.ItemName} sitecore 9 path: '{insertionPath}' Before:'{sxaAccordionItem.Content}' After:'{convertedContent}' ");
                sxaAccordionItem.Content = convertedContent;
            }
            return sxaAccordionItem;
        }
    }
}
