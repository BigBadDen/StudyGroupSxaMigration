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
    public class SxaGalleryService : SxaServiceBase, ISxaService
    {
        public SxaGalleryService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaGalleryService> logger,
                                        ApplicationSettings applicationSettings) :
                base(sitecore9Client, logger, applicationSettings)
        {
        }

        public async Task<bool> Create(GalleryContainer sitecore8GalleryContainer, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting new GalleryContainer item:'{sitecore8GalleryContainer?.ItemName}' to path: '{insertionPath}'");

            SxaGallery sxaGallery = new GenericSimpleSitecoreItemMapper().Map<SxaGallery, GalleryContainer>(sitecore8GalleryContainer, SxaTemplateIds.Gallery);

            return (sxaGallery == null ? false : await _sitecore9Client.CreateItem<SxaGallery>(sxaGallery, insertionPath));
        }
    }
}
