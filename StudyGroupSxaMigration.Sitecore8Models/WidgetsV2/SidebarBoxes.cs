using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class SidebarBoxes : SitecoreItem
    {
        public string Heading { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }

        [JsonProperty("Heading Is Link")]
        public string HeadingIsLink { get; set; }

        [JsonProperty("Image Is Link")]
        public string ImageIsLink { get; set; }

        [JsonProperty("Button Is Link")]
        public string ButtonIsLink { get; set; }

        public string Colour { get; set; }
    }
}
