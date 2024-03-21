using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class CarouselContainer : SitecoreItem
    {
        public List<CarouselSlide> CarouselSlides { get; set; }
    }
}
