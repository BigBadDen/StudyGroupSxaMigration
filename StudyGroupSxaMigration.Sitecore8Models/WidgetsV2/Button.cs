using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class Button : SitecoreItem
    {
        public string Link { get; set; }

        [JsonProperty("Link Text")]
        public string LinkText { get; set; }
    }
}
