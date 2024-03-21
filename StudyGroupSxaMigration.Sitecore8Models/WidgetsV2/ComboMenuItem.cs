using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class ComboMenuItem : SitecoreItem
    {
        public string Title { get; set; }
        public string Link { get; set; }

        [JsonProperty("Icon input")]
        public string IconInput { get; set; }
    }
}
