using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class LanguageLinkItem : SitecoreItem
    {
        [JsonProperty("Language Name")]
        public string LanguageName { get; set; }

        [JsonProperty("Language Code")]
        public string LanguageCode { get; set; }

        [JsonProperty("Custom Domain URL")]
        public string CustomDomainURL { get; set; }
    }
}
