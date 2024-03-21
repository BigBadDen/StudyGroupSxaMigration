using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class Logo : SitecoreItem
    {
        [JsonProperty("Site Logo")]
        public string SiteLogo { get; set; }

        [JsonProperty("Site Logo Url")]
        public string SiteLogoUrl { get; set; }

        [JsonProperty("Maintained By Logo")]
        public string MaintainedByLogo { get; set; }

        [JsonProperty("Maintained By Link")]
        public string MaintainedByLink { get; set; }

        [JsonProperty("Maintained By Text")]
        public string MaintainedByText { get; set; }
    }
}
