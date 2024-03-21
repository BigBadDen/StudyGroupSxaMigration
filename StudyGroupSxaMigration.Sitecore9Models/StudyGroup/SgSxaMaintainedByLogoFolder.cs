using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaMaintainedByLogoFolder : SitecoreItem
    {
        public List<SgSxaMaintainedByLogo> MaintainedByLogoItems { get; set; }
    }
}
