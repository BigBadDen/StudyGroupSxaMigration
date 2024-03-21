using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaSiteLogoFolder : SitecoreItem
    {
        public List<SgSxaSiteLogo> SiteLogoItems { get; set; }
    }
}
