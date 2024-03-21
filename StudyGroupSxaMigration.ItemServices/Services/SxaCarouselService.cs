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
    public class SxaCarouselService : SxaServiceBase, ISxaService
    {
        public SxaCarouselService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaCarouselService> logger,
                                        ApplicationSettings applicationSettings) :
                base(sitecore9Client, logger, applicationSettings)
        {
        }

        /// <summary>
        /// create the carousel and slides in sitecore 9
        /// </summary>
        /// <param name="sitecore8Carousel"></param>
        /// <param name="insertionPath"></param>
        /// <returns></returns>
        public async Task<bool> Create(Carousel sitecore8Carousel, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting New Carousel Item:'{sitecore8Carousel?.ItemName}' to path: '{insertionPath}'");

            SxaCarousel sxaCarousel = new GenericSimpleSitecoreItemMapper().Map<SxaCarousel, Carousel>(sitecore8Carousel, SxaTemplateIds.Carousel);

            return await _sitecore9Client.CreateItem<SxaCarousel>(sxaCarousel, insertionPath);
        }
    }
}
