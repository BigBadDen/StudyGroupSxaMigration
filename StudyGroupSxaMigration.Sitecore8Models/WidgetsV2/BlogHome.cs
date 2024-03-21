using Newtonsoft.Json;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class BlogHome : ContentPageItem
    {
        #region Blog settings Section
        public string Title { get; set; }

        public string Email { get; set; }
        public string Theme { get; set; }

        [JsonProperty("Show More Articles Text")]
        public string ShowMoreArticlesText { get; set; }

        public int DisplayItemCount { get; set; }
        public int DisplayCommentSidebarCount { get; set; }

        [JsonProperty("Maximum Entry Image Size")]
        public string MaximumEntryImageSize { get; set; }

        [JsonProperty("Maximum Thumbnail Image Size")]
        public string MaximumThumbnailImageSize { get; set; }
        #endregion

        #region Data Section
        [JsonProperty("Max Blog Feed items")]
        public int MaxBlogFeedItems { get; set; }

        [JsonProperty("Read More Text")]
        public string ReadMoreText { get; set; }

        [JsonProperty("Show All Blog Items")]
        public string ShowAllBlogItems { get; set; }
        #endregion

        #region Blog options Seciton
        [JsonProperty("Enable RSS")]
        public string EnableRSS { get; set; }

        [JsonProperty("Enable Comments")]
        public string EnableComments { get; set; }

        [JsonProperty("Show Email Within Comments")]
        public string ShowEmailOnComment { get; set; }

        public string EnableLiveWriter { get; set; }

        [JsonProperty("Enable Gravatar")]
        public string EnableGravatar { get; set; }

        [JsonProperty("Gravatar Size")]
        public int GravatarSize { get; set; }

        [JsonProperty("Default Gravatar Style")]
        public string DefaultGravatarStyle { get; set; }

        [JsonProperty("Gravatar Rating")]
        public string GravatarRating { get; set; }

        [JsonProperty("Custom Dictionary Folder")]
        public string CustomDictionaryFolder { get; set; }

        [JsonProperty("Hide Creator Name")]
        public string HideCreatorName { get; set; }
        #endregion

        #region Blog headers Section
        [JsonProperty("titleCategories")]
        public string TitleForTheCategoriesSidebarBlock { get; set; }

        [JsonProperty("titleRecentComments")]
        public string TitleForTheRecentCommentsSidebarBlock { get; set; }

        [JsonProperty("titleAdministration")]
        public string TitleForTheAdministrationSidebarBlock { get; set; }

        [JsonProperty("titleTagcloud")]
        public string TitleForTheTagcloudSidebarBlock { get; set; }

        [JsonProperty("titleComments")]
        public string TitleForTheCommentsHeader { get; set; }

        [JsonProperty("titleAddYourComment")]
        public string TitleForTheAddYourCommentHeader { get; set; }
        #endregion

        #region Alternate Templates Section
        [JsonProperty("Defined Category Template")]
        public string Category { get; set; }

        [JsonProperty("Defined Entry Template")]
        public string Entry { get; set; }

        [JsonProperty("Defined Comment Template")]
        public string Comment { get; set; }
        #endregion

        #region Header CTA Links Section
        [JsonProperty("Show CTA Contact Link")]
        public string ShowCTAContactLink { get; set; }

        [JsonProperty("Show CTA Apply Link")]
        public string ShowCTAApplyLink { get; set; }
        #endregion
    }
}
