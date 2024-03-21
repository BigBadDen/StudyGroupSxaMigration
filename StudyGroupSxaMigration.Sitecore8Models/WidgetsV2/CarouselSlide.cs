using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class CarouselSlide : SitecoreItem
    {
        public string Image { get; set; }
        public string Content { get; set; }

        [JsonProperty("Image Text")]
        public string ImageText { get; set; }

        /// <summary>
        /// custom field for DTO purposes - may not be needed though!
        /// </summary>
        //public string ImageMediaUrl { get; set; }
    }
}
