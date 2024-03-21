using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class ScriptSnippet : SitecoreItem
    {
        [JsonProperty("Script name")]
        public string ScriptName { get; set; }

        public string Description { get; set; }
        public string Code { get; set; }

        [JsonProperty("Script location")]
        public string ScriptLocation { get; set; }
    }
}
