using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaProgressionRouteService : SxaServiceBase, ISxaService
    {
        public SxaProgressionRouteService(ISitecore9Client sitecore9Client,
                                     ILogger<SxaProgressionRouteService> logger,
                                     ApplicationSettings applicationSettings) :
             base(sitecore9Client,
                 logger,
                 applicationSettings,
                 sitecore8Client: null)
        {
        }

        /// <summary>
        /// Creates Progression Route item in sitecore 9 website. Also converts internal links in the rich text fields
        /// </summary>
        /// <param name="sitecore8ProgressionRoute"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="insertionPath"></param>        
        /// <returns></returns>
        public async Task<bool> Create(ProgressionRoutes sitecore8ProgressionRoute, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting New Progression Route Item:'{sitecore8ProgressionRoute?.ItemName}' to path: '{insertionPath}'");

            SgSxaProgressionRoutesTable sgSxaProgressionRoutesTable = new ProgressionRoutesMapper().Map(sitecore8ProgressionRoute);

            return await _sitecore9Client.CreateItem<SgSxaProgressionRoutesTable>(sgSxaProgressionRoutesTable, insertionPath);
        }
    }
}
