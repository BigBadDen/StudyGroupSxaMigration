using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using System;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaTestimonialService : SxaServiceBase, ISxaService
    {
        public SxaTestimonialService(ISitecore9Client sitecore9Client,
                                     ILogger<SxaTestimonialService> logger,
                                     ApplicationSettings applicationSettings,
                                     RichTextFieldMigration richTextFieldMigration,
                                     ImageFieldMigration imageFieldMigration) :
             base(sitecore9Client,
                 logger,
                 applicationSettings,
                 sitecore8Client: null,
                 richTextFieldMigration: richTextFieldMigration,
                 imageFieldMigration: imageFieldMigration)
        {
        }

        /// <summary>
        /// Creates Testimonial item in sitecore 9 website. Also converts internal links in the rich text fields
        /// </summary>
        /// <param name="sitecore8Testimonial"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="insertionPath"></param>        
        /// <returns></returns>
        public async Task<bool> Create(Testimonial sitecore8Testimonial, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting New Testimonial Item:'{sitecore8Testimonial?.ItemName}' to path: '{insertionPath}'");

            SgSxaTestimonial sgSxaTestimonial = await ConvertAndValidate(new TestimonialMapper().Map(sitecore8Testimonial), sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return (sgSxaTestimonial == null ? false : await _sitecore9Client.CreateItem<SgSxaTestimonial>(sgSxaTestimonial, insertionPath));
        }

        private async Task<SgSxaTestimonial> ConvertAndValidate(SgSxaTestimonial sgSxaTestimonial, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            //content field
            var convertedContent = await _richTextFieldMigration.ValidateAndConvertLinks(sgSxaTestimonial.TestimonialContent, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sgSxaTestimonial.TestimonialContent))
            {
                migrationLogger.LogTrace($"Converting field 'Content' in SgSxaTestimonial item:'{sgSxaTestimonial?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sgSxaTestimonial.TestimonialContent}' After:'{convertedContent}' ");
                sgSxaTestimonial.TestimonialContent = convertedContent;
            }

            //description field
            convertedContent = await _richTextFieldMigration.ValidateAndConvertLinks(sgSxaTestimonial.TestimonialDescription, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sgSxaTestimonial.TestimonialDescription))
            {
                migrationLogger.LogTrace($"Converting field 'Description' in SgSxaTestimonial item:'{sgSxaTestimonial?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sgSxaTestimonial.TestimonialDescription}' After:'{convertedContent}' ");
                sgSxaTestimonial.TestimonialDescription = convertedContent;
            }

            //image field
            convertedContent = await _imageFieldMigration.ValidateImageField(sgSxaTestimonial.TestimonialImage);
            if (!String.Equals(convertedContent, sgSxaTestimonial.TestimonialImage))
            {
                migrationLogger.LogTrace($"Converting field 'Image' in sgSxaWidget during image validation item:'{sgSxaTestimonial?.ItemName}' path: '{sgSxaTestimonial?.ItemPath}' Before:'{sgSxaTestimonial.TestimonialImage}' After:'{convertedContent}' ");
                sgSxaTestimonial.TestimonialImage = convertedContent;
            }

            return sgSxaTestimonial;
        }
    }
}
