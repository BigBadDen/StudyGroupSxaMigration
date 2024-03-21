using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class BlogCategory : SitecoreItem
    {
        #region Category Section
        public string Title { get; set; }

        [JsonProperty("Show More Articles Text")]
        public string ShowMoreArticlesText { get; set; }
        #endregion

        #region Overview Section
        [JsonProperty("Nav Menu Title")]
        public string NavMenuTitle { get; set; }

        [JsonProperty("Page Title")]
        public string PageTitle { get; set; }

        [JsonProperty("Page Content Title")]
        public string PageContentTitle { get; set; }

        [JsonProperty("Page Sub Title")]
        public string PageSubTitle { get; set; }

        public string Summary { get; set; }
        public string Image { get; set; }

        [JsonProperty("Hide From Navigation")]
        public string HideFromNavigation { get; set; }

        [JsonProperty("Hide From Sitemap")]
        public string HideFromSitemap { get; set; }

        [JsonProperty("Hide From Breadcrumb")]
        public string HideFromBreadcrumb { get; set; }

        [JsonProperty("Body ID")]
        public string BodyID { get; set; }

        [JsonProperty("Body Css")]
        public string BodyCss { get; set; }

        [JsonProperty("Do Not Index")]
        public string DoNotIndex { get; set; }
        #endregion

        #region Meta Section
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

        #region Style Section
        public string Colour { get; set; }
        #endregion
    }
}
