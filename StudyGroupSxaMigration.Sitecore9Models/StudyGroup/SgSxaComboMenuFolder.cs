using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaComboMenuFolder : SitecoreItem
    {
        public List<SgSxaComboMenuItem> ComboMenuItems { get; set; }
    }
}
