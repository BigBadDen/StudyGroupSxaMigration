using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.Sitecore
{
    public class SxaLinkListFolder : SitecoreItem
    {
        public List<SxaLinkList> LinkListItems { get; set; }
    }
}
