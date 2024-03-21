using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.JsonConverters;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Sitecore9Models.Sitecore
{
    public class SxaSocialMediaTemplate : SitecoreItem
    {
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool Enabled { get; set; }

        public string OnlyOnceCode { get; set; }
        public string ButtonCode { get; set; }
        public string ShareTextProperty { get; set; }
    }
}
