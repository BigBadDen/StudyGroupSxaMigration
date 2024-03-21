using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class ProgressionRoutes : SitecoreItem
    {
        [JsonProperty("centre ID")]
        public string CentreID { get; set; }

        [JsonProperty("article ID")]
        public string ArticleID { get; set; }

        [JsonProperty("Intro Content")]
        public string IntroContent { get; set; }

        [JsonProperty("Display Grade Module")]
        public string DisplayGradeModule { get; set; }

        [JsonProperty("Page Size")]
        public string PageSize { get; set; }
    }
}
