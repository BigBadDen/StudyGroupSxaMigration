using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SgSxaButtonGroupService : SxaServiceBase,  ISxaService
    {
        public SgSxaButtonGroupService(ISitecore9Client sitecore9Client,
                                        ILogger<SgSxaButtonGroupService> logger,
                                        ApplicationSettings applicationSettings) :
                base(sitecore9Client, logger, applicationSettings)
        {
        }

        public async Task<bool> Create(ButtonGroup sitecore8ButttnGroupItem, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting new Button Group Item:'{sitecore8ButttnGroupItem?.ItemName}' to path: '{insertionPath}'");

            SgSxaButtonGroup sgSxaButtonGroup = new GenericSimpleSitecoreItemMapper().Map<SgSxaButtonGroup, ButtonGroup>(sitecore8ButttnGroupItem, StudyGroupTemplateIds.ButtonGroup);

            return await _sitecore9Client.CreateItem<SgSxaButtonGroup>(sgSxaButtonGroup, insertionPath);
        }
    }
}
