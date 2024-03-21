using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaBlogHome : SitecoreItem
    {
        #region Content section
        public string Title { get; set; }
        public string Content { get; set; }
        #endregion

        // not sure what this field is!!?
        //#region Custom Metadata section
        //[JsonProperty("Attributes")]
        //public Dictionary<string, string> MatadataKeyValues { get; set; }
        //#endregion

        #region Designing section
        [JsonProperty("Page Design")]
        public string PageDesign { get; set; }
        #endregion

        #region Navigation section
        public string NavigationTitle { get; set; }
        public string NavigationFilter { get; set; }
        public string NavigationClass { get; set; }
        #endregion

        #region OpenGraph section
        public string OpenGraphTitle { get; set; }
        public string OpenGraphDescription { get; set; }
        public string OpenGraphImageUrl { get; set; }
        public string OpenGraphType { get; set; }
        public string OpenGraphSiteName { get; set; }
        public string OpenGraphAdmins { get; set; }
        #endregion

        #region Search Criteria section
        [JsonProperty("Scope")]
        public string SearchScope { get; set; }
        #endregion

        #region Sticky Notes section
        public string StickyNotes { get; set; }
        #endregion

        #region Styling section
        [JsonProperty("Body Css Class")]
        public string BodyCssClass { get; set; }

        [JsonProperty("Body Id")]
        public string BodyId { get; set; }
        #endregion

        #region Tagging section
        [JsonProperty("SxaTags")]
        public List<string> Tags { get; set; }
        #endregion

        #region Sitemap Settings section
        public string ChangeFrequency { get; set; }
        public string Priority { get; set; }
        #endregion

        #region Page Meta Properties section
        [JsonProperty("Cannonical Link")]
        public string CannonicalLink { get; set; }

        [JsonProperty("MetaKeywords")]
        public string PageKeywords { get; set; }

        [JsonProperty("MetaDescription")]
        public string PageDescription { get; set; }
        #endregion

        #region Twitter section
        [JsonProperty("TwitterTitle")]
        public string TweetText { get; set; }

        [JsonProperty("TwitterSite")]
        public string TweetSite { get; set; }

        [JsonProperty("TwitterDescription")]
        public string TweetDescription { get; set; }

        [JsonProperty("TwitterImage")]
        public string TweetImage { get; set; }

        [JsonProperty("TwitterCardType")]
        public string CardType { get; set; }
        #endregion
    }
}
