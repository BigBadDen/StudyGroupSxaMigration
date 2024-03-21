using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaTabContainerService : SxaServiceBase, ISxaService
    {
        public SxaTabContainerService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaTabContainerService> logger,
                                        ApplicationSettings applicationSettings) :
                base(sitecore9Client, logger, applicationSettings)
        {
        }

        public async Task<bool> Create(TabContainer sitecore8TabContainer, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting new TabContainer item:'{sitecore8TabContainer?.ItemName}' to path: '{insertionPath}'");

            SxaTabItem sxaTabs = new GenericSimpleSitecoreItemMapper().Map<SxaTabItem, TabContainer>(sitecore8TabContainer, SxaTemplateIds.TabFolder);

            return await _sitecore9Client.CreateItem<SxaTabItem>(sxaTabs, insertionPath);
        }
    }
}
