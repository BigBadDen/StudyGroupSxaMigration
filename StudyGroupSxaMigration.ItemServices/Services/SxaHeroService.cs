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
    public class SxaHeroService : SxaServiceBase, ISxaService
    {
        public SxaHeroService(ISitecore9Client sitecore9Client,
                                     ILogger<SxaHeroService> logger,
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
        /// Creates Hero item in sitecore 9 website. Also converts internal links in the rich text fields
        /// </summary>
        /// <param name="sitecore8Hero"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="insertionPath"></param>        
        /// <returns></returns>
        public async Task<bool> Create(Hero sitecore8Hero, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting New Hero Item:'{sitecore8Hero?.ItemName}' to path: '{insertionPath}'");

            SgSxaHero sgSxaHero = await ConvertAndValidate(new HeroMapper().Map(sitecore8Hero), sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return (sgSxaHero == null ? false : await _sitecore9Client.CreateItem<SgSxaHero>(sgSxaHero, insertionPath));
        }

        private async Task<SgSxaHero> ConvertAndValidate(SgSxaHero sgSxaHero, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            //content field
            var convertedContent = await _richTextFieldMigration.ValidateAndConvertLinks(sgSxaHero.HeroText, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sgSxaHero.HeroText))
            {
                migrationLogger.LogTrace($"Converting field 'Text' in SgSxaHero item:'{sgSxaHero?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sgSxaHero.HeroText}' After:'{convertedContent}' ");
                sgSxaHero.HeroText = convertedContent;
            }

            //image field
            convertedContent = await _imageFieldMigration.ValidateImageField(sgSxaHero.HeroImage);
            if (!String.Equals(convertedContent, sgSxaHero.HeroImage))
            {
                migrationLogger.LogTrace($"Converting field 'Image' in sgSxaHero during image validation item:'{sgSxaHero?.ItemName}' path: '{sgSxaHero?.ItemPath}' Before:'{sgSxaHero.HeroImage}' After:'{convertedContent}' ");
                sgSxaHero.HeroImage = convertedContent;
            }

            //link field
            convertedContent = await _linkFieldMigration.ConvertInternalLinks(sgSxaHero.HeroLink1, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sgSxaHero.HeroLink1))
            {
                migrationLogger.LogTrace($"Converting field 'Link 1' in sgSxaWidget item:'{sgSxaHero?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sgSxaHero.HeroLink1}' After:'{convertedContent}'");
                sgSxaHero.HeroLink1 = convertedContent;
            }

            return sgSxaHero;
        }
    }
}
