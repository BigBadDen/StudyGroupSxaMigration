using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaHeroFolder : SitecoreItem
    {
        public List<SgSxaHero> Heros { get; set; }
    }
}
