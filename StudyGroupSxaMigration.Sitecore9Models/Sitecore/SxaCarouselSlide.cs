using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.Sitecore
{
    public class SxaCarouselSlide : SitecoreItem
    {
        public string SlideImage { get; set; }
        public string SlideLink { get; set; }
        public string SlideText { get; set; }
    }
}
