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
    public class SxaSocialMediaContainerService : SxaServiceBase, ISxaService
    {
        public SxaSocialMediaContainerService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaSocialMediaContainerService> logger,
                                        ApplicationSettings applicationSettings) :
                base(sitecore9Client, logger, applicationSettings)
        {
        }

        public async Task<bool> Create(SocialMediaContainer sitecore8SocialMediaContainer, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting new SocialMediaContainer item:'{sitecore8SocialMediaContainer?.ItemName}' to path: '{insertionPath}'");

            SxaSocialMediaButtons socialMediaButtons = new GenericSimpleSitecoreItemMapper().Map<SxaSocialMediaButtons, SocialMediaContainer>(sitecore8SocialMediaContainer, SxaTemplateIds.SocialMediaButtons);

            return await _sitecore9Client.CreateItem<SxaSocialMediaButtons>(socialMediaButtons, insertionPath);
        }
    }
}
