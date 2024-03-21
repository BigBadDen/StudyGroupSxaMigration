using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using StudyGroupSxaMigration.Sitecore9Constants;
using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class CarouselSlideMapper : SitecoreItemMapper
    {
        public SxaCarouselSlide Map(CarouselSlide sitecore8CarouselSlide)
        {
            SxaCarouselSlide sxaCarouselSlide = base.MapCommonFields<SxaCarouselSlide, CarouselSlide>(sitecore8CarouselSlide);

            sxaCarouselSlide.TemplateID = SxaTemplateIds.CarouselSlide;
            sxaCarouselSlide.SlideText = sitecore8CarouselSlide.Content;
            sxaCarouselSlide.SlideImage = sitecore8CarouselSlide.Image;

            return sxaCarouselSlide;
        }
    }
}
