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
    public class SxaCarouselSlideService : SxaServiceBase, ISxaService
    {
        public SxaCarouselSlideService(ISitecore9Client sitecore9Client,
                                      ILogger<SxaCarouselSlideService> logger,
                                      ApplicationSettings applicationSettings,
                                      ImageFieldMigration imageFieldMigration,
                                      RichTextFieldMigration richTextFieldMigration) :
              base(sitecore9Client,
                  logger,
                  applicationSettings,
                  sitecore8Client: null,
                  richTextFieldMigration: richTextFieldMigration,
                  imageFieldMigration: imageFieldMigration)
        {
        }

        /// <summary>
        /// create the carousel and slides in sitecore 9
        /// </summary>
        /// <param name="sitecore8Carousel"></param>
        /// <param name="insertionPath"></param>
        /// <returns></returns>
        public async Task<bool> Create(CarouselSlide sitecore8CarouselSlide, string insertionPath, string sxaSiteRootPath, string sitecore8SiteRootPath)
        {
            migrationLogger.LogDebug($"Inserting New Carousel Slide Item:'{sitecore8CarouselSlide?.ItemName}' to path: '{insertionPath}'");

            SxaCarouselSlide sxaCarouselSlide = await ConvertAndValidate(new CarouselSlideMapper().Map(sitecore8CarouselSlide), sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return await _sitecore9Client.CreateItem<SxaCarouselSlide>(sxaCarouselSlide, insertionPath);
        }

        private async Task<SxaCarouselSlide> ConvertAndValidate(SxaCarouselSlide sxaCarouselSlide, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            var convertedContent = await _imageFieldMigration.ValidateImageField(sxaCarouselSlide.SlideImage);
            if (!String.Equals(convertedContent, sxaCarouselSlide.SlideImage))
            {
                migrationLogger.LogTrace($"Converting field 'SlideImage' in sxaCarouselSlide during image validation item:'{sxaCarouselSlide?.ItemName}' path: '{sxaCarouselSlide?.ItemPath}' Before:'{sxaCarouselSlide.SlideImage}' After:'{convertedContent}' ");
                sxaCarouselSlide.SlideImage = convertedContent;
            }

            convertedContent = await _richTextFieldMigration.ValidateAndConvertLinks(sxaCarouselSlide.SlideText, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sxaCarouselSlide.SlideText))
            {
                migrationLogger.LogTrace($"Converting field 'SlideText' in sxaCarouselSlide item:'{sxaCarouselSlide?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sxaCarouselSlide.SlideText}' After:'{convertedContent}' ");
                sxaCarouselSlide.SlideText = convertedContent;
            }
            return sxaCarouselSlide;
        }
    }
}
