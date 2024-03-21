using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class CallToAction : SitecoreItem
    {
        public string Link { get; set; }

        [JsonProperty("Link Text")]
        public string LinkText { get; set; }
    }
}
