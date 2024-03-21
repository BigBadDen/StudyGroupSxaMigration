using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.JsonConverters;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class NewsArticlePage : SitecoreItem
    {
        #region Content Section
        public string Prioritised { get; set; }

        [JsonProperty("Use Page Sub Title for Article Title")]
        public string UsePageSubTitleForArticleTitle { get; set; }

        [JsonProperty("Use H2 tag for Article Title")]
        public string UseH2tagForArticleTitle { get; set; }

        public string Article { get; set; }
        public string Date { get; set; }

        [JsonProperty("ContentImage")]
        public string ContentImage { get; set; }

        [JsonProperty("Page Title Link")]
        public string PageTitleLink { get; set; }

        [JsonProperty("Image Link")]
        public string ImageLink { get; set; }

        [JsonProperty("Main Content")]
        public string MainContent { get; set; } //sitecore/content/Corporate Site/Home/News and events/Events Archive/Alphe London

        [JsonProperty("Top Content")]
        public string TopContent { get; set; } //sitecore/content/Corporate Site/Home/News and events/Events Archive/Alphe London
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

        [JsonProperty("Image")]
        public string OverviewImage { get; set; }

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

        [JsonProperty("Carousel Mode")]
        public string CarouselMode { get; set; }

        [JsonProperty("Find Out More Label")]
        public string FindOutMoreLabel { get; set; } //sitecore/content/ISC/Roosevelt/Home/international study center/student news/International Study Center Launch
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
