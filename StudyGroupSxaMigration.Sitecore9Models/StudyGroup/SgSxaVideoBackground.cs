using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaVideoBackground : SitecoreItem
    {
        public string VideoBackgroundImage { get; set; }
        public string VideoBackgroundText { get; set; }
        public string VideoBackgroundVideoMP4 { get; set; }
        public string VideoBackgroundVideoWEBM { get; set; }
        public string VideoBackgroundFallback1 { get; set; }
        public string VideoBackgroundFallback2 { get; set; }
        public string VideoBackgroundFallback3 { get; set; }
    }
}
