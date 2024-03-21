using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class AccordionItem : SitecoreItem
    {
        [JsonProperty("Accordion Description")]
        public string AccordionDescription { get; set; }

        [JsonProperty("Accordion Description Type")]
        public string AccordionDescriptionType { get; set; }

        public string Heading { get; set; }

        [JsonProperty("Heading Type")]
        public string HeadingType { get; set; }

        public string Content { get; set; }
    }
}
