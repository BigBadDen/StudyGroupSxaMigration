using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class ProgressionRouteLabels : SitecoreItem
    {
        [JsonProperty("No Data Label")]
        public string NoDataLabel { get; set; }

        [JsonProperty("Degree Programmes Label")]
        public string DegreeProgrammesLabel { get; set; }

        [JsonProperty("Awards Label")]
        public string AwardsLabel { get; set; }

        [JsonProperty("Overall Grade Label")]
        public string OverallGradeLabel { get; set; }

        [JsonProperty("English Grade Label")]
        public string EnglishGradeLabel { get; set; }

        [JsonProperty("Grade Module Label")]
        public string GradeModuleLabel { get; set; }

        [JsonProperty("University Label")]
        public string UniversityLabel { get; set; }

        [JsonProperty("To University Label")]
        public string ToUniversityLabel { get; set; }

        [JsonProperty("From Article Label")]
        public string FromArticleLabel { get; set; }
    }
}
