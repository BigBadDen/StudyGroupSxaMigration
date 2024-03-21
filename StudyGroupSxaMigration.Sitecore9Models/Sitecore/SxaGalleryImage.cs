using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.Sitecore
{
    public class SxaGalleryImage : SitecoreItem
    {
        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("ImageTitle")]
        public string ImageTitle { get; set; }

        [JsonProperty("ImageDescription")]
        public string ImageDescription { get; set; }
    }
}
