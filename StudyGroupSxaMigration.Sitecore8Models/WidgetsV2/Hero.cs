using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class Hero : SitecoreItem
    {
        public string Image { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }

        [JsonProperty("Link Text")]
        public string LinkText { get; set; }
    }
}
