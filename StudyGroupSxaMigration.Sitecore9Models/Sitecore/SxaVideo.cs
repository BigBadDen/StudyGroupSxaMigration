using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.Sitecore
{
    public class SxaVideo : SitecoreItem
    {
        #region Video Content section
        public string YoutubeMovie { get; set; }
        public string PosterImage { get; set; }
        public string MP4Movie { get; set; }
        public string OggMovie { get; set; }
        public string WebMMovie { get; set; }
        #endregion

        #region Video Description section
        public string MovieCaption { get; set; }
        public string MovieDescription { get; set; }
        public string MovieThumbnail { get; set; }
        #endregion

        #region Video Parameters section
        public string Autoplay { get; set; }
        public string MovieLabel { get; set; }
        public string MovieLength { get; set; }
        #endregion

        #region Player Settings
        /// <summary>
        /// Image Displayed When Video Unavailable
        /// </summary>
        public string VideoNotAvailableImage { get; set; }

        /// <summary>
        /// Text Displayed When Video Unavailable
        /// </summary>
        public string VideoNotAvailableText { get; set; }
        public string FlashPlayer { get; set; }
        #endregion
    }
}
