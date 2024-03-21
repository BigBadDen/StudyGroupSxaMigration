using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaProgressionRoutesTable : SitecoreItem
    {
        [JsonProperty("Centre Id")]
        public string CentreId { get; set; }

        [JsonProperty("Article Id")]
        public string ArticleId { get; set; }

        [JsonProperty("Display Grade Module")]
        public string DisplayGradeModule { get; set; }

        [JsonProperty("Page Size")]
        public string PageSize { get; set; }
    }
}
