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
    public class SxaGalleryImageService : SxaServiceBase, ISxaService
    {
        public SxaGalleryImageService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaGalleryImageService> logger,
                                        ApplicationSettings applicationSettings,
                                        ImageFieldMigration imageFieldMigration) :
                base(sitecore9Client,
                    logger,
                    applicationSettings,
                    imageFieldMigration: imageFieldMigration)
        {
        }

        public async Task<bool> Create(GalleryItem galleryItem, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting new gallery image:'{galleryItem?.ItemName}' to path: '{insertionPath}'");

            SxaGalleryImage sxaGalleryImageItem = await ConvertAndValidate(new GalleryItemMapper().Map(galleryItem));

             return (sxaGalleryImageItem == null ? false : await _sitecore9Client.CreateItem<SxaGalleryImage>(sxaGalleryImageItem, insertionPath));
        }

        private async Task<SxaGalleryImage> ConvertAndValidate(SxaGalleryImage sxaGalleryImage)
        {
            var convertedContent = await _imageFieldMigration.ValidateImageField(sxaGalleryImage.Image);
            if (!String.Equals(convertedContent, sxaGalleryImage.Image))
            {
                migrationLogger.LogTrace($"Converting field 'Image' in sxaGalleryImage during image validation item:'{sxaGalleryImage?.ItemName}' path: '{sxaGalleryImage?.ItemPath}' Before:'{sxaGalleryImage.Image}' After:'{convertedContent}' ");
                sxaGalleryImage.Image = convertedContent;
            }
            return sxaGalleryImage;
        }
    }
}
