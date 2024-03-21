using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.JsonConverters;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    //sitecore/templates/ISC White Label/Site Pages/Western Washington V2/News Hub Page
    public class NewsListingPage : SitecoreItem
    {
        #region Data section
        [JsonProperty("Featured Article")]
        public string FeaturedArticle { get; set; }

        [JsonProperty("Archive Listing Title")]
        public string ArchiveListingTitle { get; set; }

        [JsonProperty("Read More Text")]
        public string ReadMoreText { get; set; }

        [JsonProperty("Max News Articles")]
        public string MaxNewsArticles { get; set; }

        [JsonProperty("Show All News")]
        public string ShowAllNews { get; set; }

        [JsonProperty("News Feed Title")]
        public string NewsFeedTitle { get; set; }

        [JsonProperty("Max News Feed Articles")]
        public string MaxNewsFeedArticles { get; set; }
        #endregion

        #region Overview section
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
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool HideFromNavigation { get; set; }

        [JsonProperty("Hide From Sitemap")]
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool HideFromSitemap { get; set; }

        [JsonProperty("Hide From Breadcrumb")]
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool HideFromBreadcrumb { get; set; }

        [JsonProperty("Body ID")]
        public string BodyID { get; set; }

        [JsonProperty("Body Css")]
        public string BodyCss { get; set; }

        [JsonProperty("Do Not Index")]
        public string DoNotIndex { get; set; }
        #endregion

        #region Content section
        [JsonProperty("Main Content")]
        public string MainContent { get; set; }
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

        [JsonProperty("Combres CSS Groups")]
        public string CombresCssGroups { get; set; }

        [JsonProperty("Combres JS Groups")]
        public string CombresJsGroups { get; set; }
        #endregion

    }
}
