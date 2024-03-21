using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaButtonGroupFolder : SitecoreItem
    {
        public List<SgSxaButtonGroup> ButtonGroupItems { get; set; }
    }
}
