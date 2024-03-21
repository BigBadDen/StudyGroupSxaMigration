using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class LanguageLinks : SitecoreItem
    {
        public List<LanguageLinkItem> LanguageLinkItems { get; set; }

        [JsonProperty("Current Language")]
        public LanguageLinkItem CurrentLanguage { get; set; }

        public List<LanguageLinkItem> Links { get; set; }

        [JsonProperty("Show Flags")]
        public string ShowFlags { get; set; }
    }
}
