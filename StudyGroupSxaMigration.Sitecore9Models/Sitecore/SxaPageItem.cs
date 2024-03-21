using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Sitecore9Models.Sitecore
{
    public class SxaPageItem : SitecoreItem
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        /// <summary>
        /// NB. This appears as Page Description in Content Editor
        /// </summary>
        [JsonProperty("MetaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("NavigationTitle")]
        public string NavigationTitle { get; set; }
    }
}
