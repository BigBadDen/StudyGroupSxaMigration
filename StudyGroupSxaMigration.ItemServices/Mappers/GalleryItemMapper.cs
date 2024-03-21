using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class GalleryItemMapper : SitecoreItemMapper
    {
        public SxaGalleryImage Map(GalleryItem galleryItem)
        {
            SxaGalleryImage sxaGalleryImage = base.MapCommonFields<SxaGalleryImage, GalleryItem>(galleryItem);

            sxaGalleryImage.Image = galleryItem.Image;
            sxaGalleryImage.ImageDescription = galleryItem.ImageText;

            sxaGalleryImage.TemplateID = SxaTemplateIds.GalleryImage;

            return sxaGalleryImage;
        }
    }
}
