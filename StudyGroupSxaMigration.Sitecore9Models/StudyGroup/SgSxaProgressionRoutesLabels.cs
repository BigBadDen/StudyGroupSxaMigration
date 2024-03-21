using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaProgressionRoutesLabels : SitecoreItem
    {
        #region Headings
        [JsonProperty("Degree Programmes")]
        public string DegreeProgrammes { get; set; }

        public string Awards { get; set; }

        [JsonProperty("Overall Grade")]
        public string OverallGrade { get; set; }

        [JsonProperty("English Grade")]
        public string EnglishGrade { get; set; }

        [JsonProperty("Grade Module")]
        public string GradeModule { get; set; }

        [JsonProperty("From University")]
        public string FromUniversity { get; set; }

        [JsonProperty("To University")]
        public string ToUniversity { get; set; }

        [JsonProperty("From Article")]
        public string FromArticle { get; set; }
        #endregion

        #region Labels
        [JsonProperty("No Data")]
        public string NoData { get; set; }

        [JsonProperty("Empty Table")]
        public string EmptyTable { get; set; }

        [JsonProperty("Showing Entries")]
        public string ShowingEntries { get; set; }

        [JsonProperty("Showing Entries Empty")]
        public string ShowingEntriesEmpty { get; set; }

        [JsonProperty("Showing Entries Filtered")]
        public string ShowingEntriesFiltered { get; set; }

        [JsonProperty("Thousands Separator")]
        public string ThousandsSeparator { get; set; }

        [JsonProperty("Length Menu")]
        public string LengthMenu { get; set; }

        [JsonProperty("Loading Records")]
        public string LoadingRecords { get; set; }

        public string Processing { get; set; }
        public string Search { get; set; }

        [JsonProperty("Zero Records")]
        public string ZeroRecords { get; set; }
        #endregion

        #region Pagination
        [JsonProperty("First Page")]
        public string FirstPage { get; set; }

        [JsonProperty("Last Page")]
        public string LastPage { get; set; }

        [JsonProperty("Next Page")]
        public string NextPage { get; set; }

        [JsonProperty("Previous Page")]
        public string PreviousPage { get; set; }
        #endregion
    }
}
