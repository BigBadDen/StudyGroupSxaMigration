using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaWidget : SitecoreItem
    {
        [JsonProperty("Widget Title")]
        public string WidgetTitle { get; set; }

        [JsonProperty("Widget Content")]
        public string WidgetContent { get; set; }

        [JsonProperty("Widget Image")]
        public string WidgetImage { get; set; }

        [JsonProperty("Widget Link")]
        public string WidgetLink { get; set; }

        public string WidgetLinkText { get; set; }
    }
}
