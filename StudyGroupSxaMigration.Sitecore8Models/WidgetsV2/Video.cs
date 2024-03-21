using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class Video : SitecoreItem
    {
        public string Title { get; set; }

        [JsonProperty("Video Title")]
        public string VideoTitle { get; set; }

        [JsonProperty("Video Link")]
        public string VideoLink { get; set; }

        [JsonProperty("Video Image")]
        public string VideoImage { get; set; }

        [JsonProperty("Heading Type")]
        public string HeadingType { get; set; }
    }
}
