using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class Testimonial : SitecoreItem
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }

        [JsonProperty("Heading Type")]
        public string HeadingType { get; set; }
    }
}
