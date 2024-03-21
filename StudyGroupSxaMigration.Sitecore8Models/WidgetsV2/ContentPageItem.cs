using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreCommon.JsonConverters;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class ContentPageItem : SitecoreItem
    {
        #region Overview Section
        [JsonProperty("Page Title")]
        public string PageTitle { get; set; }

        [JsonProperty("Nav Menu Title")]
        public string NavMenuTitle { get; set; }

        [JsonProperty("Page Content Title")]
        public string PageContentTitle { get; set; }

        public string Summary { get; set; }
        public string Image { get; set; }

        [JsonProperty("Page Sub Title")]
        public string PageSubTitle { get; set; }

        [JsonProperty("Hide From Navigation")]
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool HideFromNavigation { get; set; }

        [JsonProperty("Hide From Breadcrumb")]
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool HideFromBreadcrumb { get; set; }

        [JsonProperty("Hide From Sitemap")]
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool HideFromSitemap { get; set; }

        [JsonProperty("Body ID")]
        public string BodyID { get; set; }

        [JsonProperty("Body Css")]
        public string BodyCss { get; set; }

        [JsonProperty("Do Not Index")]
        public string DoNotIndex { get; set; }
        #endregion

        #region Meta section
        [JsonProperty("Meta Title")]
        public string MetaTitle { get; set; }

        [JsonProperty("Meta Description")]
        public string MetaDescription { get; set; }

        [JsonProperty("Meta Keywords")]
        public string MetaKeywords { get; set; }

        [JsonProperty("Canonical Link")]
        public string CanonicalLink { get; set; }

        [JsonProperty("Hreflang override")]
        public string HreflangOverride { get; set; }

        [JsonProperty("Disable hreflang")]
        public string DisableHreflang { get; set; }

        [JsonProperty("Disable hreflang for")]
        public string DisableHreflangFor { get; set; }

        [JsonProperty("Google Optimise Id")]
        public string GoogleOptimiseId { get; set; }
        #endregion

        #region Style section
        public string Colour { get; set; }
        #endregion
    }
}
