using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaMaintainedByLogo : SitecoreItem
    {
        public string Image { get; set; }
        public string TargetUrl { get; set; }
        public string ImageCaption { get; set; }
    }
}
