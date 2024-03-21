using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaWidgetFolder : SitecoreItem
    {
        public List<SgSxaWidget> Widgets { get; set; }
    }
}
