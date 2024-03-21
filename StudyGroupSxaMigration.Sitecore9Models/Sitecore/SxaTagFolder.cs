using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.Sitecore
{
    public class SxaTagFolder : SitecoreItem
    {
        public List<SxaTag> Tags { get; set; }
    }
}
