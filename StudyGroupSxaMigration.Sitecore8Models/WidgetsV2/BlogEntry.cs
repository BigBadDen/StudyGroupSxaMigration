using Newtonsoft.Json;
using System;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class BlogEntry : ContentPageItem
    {
        #region Entry Section
        public string Title { get; set; }
        public string Introduction { get; set; }
        public string Content { get; set; }

        [JsonProperty("Blog Image")]
        public string BlogImage { get; set; }

        [JsonProperty("Blog Thumbnail Image")]
        public string BlogThumbnailImage { get; set; }
        #endregion

        #region Metadata Section
        public string Category { get; set; }
        public string Tags { get; set; }
        public string Author { get; set; }

        [JsonProperty("Entry Date")]
        public string EntryDate { get; set; }
        #endregion

        #region Options section
        [JsonProperty("Disable comments")]
        public string DisableComments { get; set; }
        #endregion
    }
}
