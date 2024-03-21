using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class TabContainer : SitecoreItem
    {
        public List<Tab> Tabs { get; set; }
    }
}
