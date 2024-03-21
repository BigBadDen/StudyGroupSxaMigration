using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.Sitecore
{
    public class SxaSocialMediaButtons : SitecoreItem
    {
        public List<SxaSocialMediaTemplate> SocialMediaItems { get; set; }
    }
}
