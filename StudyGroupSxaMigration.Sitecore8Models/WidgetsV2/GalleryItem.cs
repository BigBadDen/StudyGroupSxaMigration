using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class GalleryItem : SitecoreItem
    {
        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("Image Text")]
        public string ImageText { get; set; }
    }
}
