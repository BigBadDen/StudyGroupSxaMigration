using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaAccordionContainerService : SxaServiceBase, ISxaService
    {
        public SxaAccordionContainerService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaAccordionContainerService> logger,
                                        ApplicationSettings applicationSettings) :
                base(sitecore9Client, logger, applicationSettings)
        {
        }

        public async Task<bool> Create(AccordionContainer sitecore8AccordionContainer, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting new AccordionContainer item:'{sitecore8AccordionContainer?.ItemName}' to path: '{insertionPath}'");

            SxaAccordion sxaAccordion = new GenericSimpleSitecoreItemMapper().Map<SxaAccordion, AccordionContainer>(sitecore8AccordionContainer, SxaTemplateIds.Accordion);

            return await _sitecore9Client.CreateItem<SxaAccordion>(sxaAccordion, insertionPath);
        }
    }
}
