using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class Widget : SitecoreItem
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }

        [JsonProperty("Link Text")]
        public string LinkText { get; set; }

        public string Class { get; set; }

        [JsonProperty("Heading Type")]
        public string HeadingType { get; set; }

        [JsonProperty("Link Type")]
        public string LinkType { get; set; }
    }
}
