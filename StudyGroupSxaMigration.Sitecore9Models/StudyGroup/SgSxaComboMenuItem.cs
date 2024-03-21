using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaComboMenuItem : SitecoreItem
    {
        public string Title { get; set; }
        public string Link { get; set; }

        [JsonProperty("Icon CSS Classes")]
        public string IconCSSClasses { get; set; }
    }
}
