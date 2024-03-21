using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using System;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaVideoService : SxaServiceBase, ISxaService
    {
        public SxaVideoService(ISitecore9Client sitecore9Client,
                                     ILogger<SxaVideoService> logger,
                                     ApplicationSettings applicationSettings,
                                     RichTextFieldMigration richTextFieldMigration,
                                     ImageFieldMigration imageFieldMigration,
                                     LinkFieldMigration linkFieldMigration) :
             base(sitecore9Client,
                 logger,
                 applicationSettings,
                 sitecore8Client: null,
                 richTextFieldMigration: richTextFieldMigration,
                 imageFieldMigration: imageFieldMigration,
                 linkFieldMigration: linkFieldMigration)
        {
        }

        /// <summary>
        /// Creates Video item in sitecore 9 website. Also converts internal links in the rich text fields
        /// </summary>
        /// <param name="sitecore8Video"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="insertionPath"></param>        
        /// <returns></returns>
        public async Task<bool> Create(Video sitecore8Video, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting New Video Item:'{sitecore8Video?.ItemName}' to path: '{insertionPath}'");

            SxaVideo sgSxaVideo = await ConvertAndValidate(new VideoMapper().Map(sitecore8Video), sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return await _sitecore9Client.CreateItem<SxaVideo>(sgSxaVideo, insertionPath);
        }

        private async Task<SxaVideo> ConvertAndValidate(SxaVideo sxaVideo, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            //image field
            var convertedContent = await _imageFieldMigration.ValidateImageField(sxaVideo.MovieThumbnail);
            if (!String.Equals(convertedContent, sxaVideo.MovieThumbnail))
            {
                migrationLogger.LogTrace($"Converting field 'Video Image' in sgSxaWidget during image validation item:'{sxaVideo?.ItemName}' path: '{sxaVideo?.ItemPath}' Before:'{sxaVideo.MovieThumbnail}' After:'{convertedContent}' ");
                sxaVideo.MovieThumbnail = convertedContent;
            }

            //link field
            convertedContent = await _linkFieldMigration.ConvertInternalLinks(sxaVideo.YoutubeMovie, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sxaVideo.YoutubeMovie))
            {
                migrationLogger.LogTrace($"Converting field 'Video Link' in sgSxaWidget item:'{sxaVideo?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sxaVideo.YoutubeMovie}' After:'{convertedContent}'");
                sxaVideo.YoutubeMovie = convertedContent;
            }
            return sxaVideo;
        }
    }
}
