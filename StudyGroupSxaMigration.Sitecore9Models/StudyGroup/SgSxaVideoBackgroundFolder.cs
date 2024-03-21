using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaVideoBackgroundFolder : SitecoreItem
    {
        public List<SgSxaVideoBackground> VideoBackgroundItems { get; set; }
    }
}
