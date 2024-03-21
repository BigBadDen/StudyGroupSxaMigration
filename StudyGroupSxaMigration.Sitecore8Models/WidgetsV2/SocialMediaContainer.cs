using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class SocialMediaContainer : SitecoreItem
    {
        public List<SocialMediaLinks> SocialMediaLinkItems { get; set; }
        public string Title { get; set; }

        [JsonProperty("Heading Type")]
        public string HeadingType { get; set; }
    }
}
