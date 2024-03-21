using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class SocialMediaLinks : SitecoreItem
    {
        public string Link { get; set; }

        [JsonProperty("Css Class")]
        public string CssClass { get; set; }

        [JsonProperty("rel Attribute")]
        public string RelAttribute { get; set; }
    }
}
