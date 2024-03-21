using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class VideoBackground : SitecoreItem
    {
        [JsonProperty("Video Image")]
        public string VideoImage { get; set; }

        [JsonProperty("Video Content")]
        public string VideoContent { get; set; }

        [JsonProperty("MP4 Video")]
        public string MP4Video { get; set; }

        [JsonProperty("WebM Video")]
        public string WebMVideo { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
    }
}
