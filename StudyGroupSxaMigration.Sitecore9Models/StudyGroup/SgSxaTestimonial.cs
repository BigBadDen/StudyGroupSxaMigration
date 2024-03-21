using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaTestimonial : SitecoreItem
    {
        [JsonProperty("Testimonial Title")]
        public string TestimonialTitle { get; set; }

        [JsonProperty("Testimonial Image")]
        public string TestimonialImage { get; set; }

        [JsonProperty("Testimonial Content")]
        public string TestimonialContent { get; set; }

        [JsonProperty("Testimonial Description")]
        public string TestimonialDescription { get; set; }
    }
}
