using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaHero : SitecoreItem
    {
        public string HeroImage { get; set; }
        public string HeroText { get; set; }
        public string HeroLink1 { get; set; }
        public string HeroLink2 { get; set; }
        public string HeroLink3 { get; set; }
    }
}
