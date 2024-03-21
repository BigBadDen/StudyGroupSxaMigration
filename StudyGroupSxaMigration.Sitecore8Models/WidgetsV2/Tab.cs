using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class Tab : SitecoreItem
    {
        public string Title { get; set; }
        public string Content { get; set; }

        [JsonProperty("Heading Type")]
        public string HeadingType { get; set; }
    }
}
