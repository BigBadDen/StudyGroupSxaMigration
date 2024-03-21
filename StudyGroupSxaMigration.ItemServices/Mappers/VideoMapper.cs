using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class VideoMapper : SitecoreItemMapper
    {
        public SxaVideo Map(Video video)
        {
            SxaVideo sxaVideo = base.MapCommonFields<SxaVideo, Video>(video);

            var videoTitle = !string.IsNullOrEmpty(video.Title) ? video.Title : video.VideoTitle;
            sxaVideo.MovieCaption = videoTitle;
            sxaVideo.MovieLabel = videoTitle;
            sxaVideo.MovieThumbnail = video.VideoImage;
            sxaVideo.YoutubeMovie = video.VideoLink;

            sxaVideo.TemplateID = SxaTemplateIds.Video;

            return sxaVideo;
        }
    }
}
