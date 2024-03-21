using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class AccordionContainer : SitecoreItem
    {
        public List<AccordionItem> AccordionItems;
        public string Heading { get; set; }
        public string Content { get; set; }

        [JsonProperty("Heading Type")]
        public string HeadingType { get; set; }
    }
}
