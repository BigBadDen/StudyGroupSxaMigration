using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.Sitecore
{
    public class SxaGalleryVideo : SitecoreItem
    {
        public string VideoProvider { get; set; }
        public string VideoID { get; set; }
        public string VideoTitle { get; set; }
        public string VideoDescription { get; set; }
        public string VideoThumbnail { get; set; }
    }
}
