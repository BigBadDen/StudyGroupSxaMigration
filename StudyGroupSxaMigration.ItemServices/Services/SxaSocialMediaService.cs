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
    public class SxaSocialMediaService : SxaServiceBase, ISxaService
    {
        public SxaSocialMediaService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaSocialMediaService> logger,
                                        ApplicationSettings applicationSettings,
                                        LinkFieldMigration linkFieldMigration) :
                base(sitecore9Client,
                    logger,
                    applicationSettings,
                    sitecore8Client: null,
                    linkFieldMigration: linkFieldMigration)
        {
        }

        public async Task<bool> Create(SocialMediaLinks socialMediaLinksItem, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting new Social Media item:'{socialMediaLinksItem?.ItemName}' to path: '{insertionPath}'");

            SxaSocialMediaTemplate sxaSocialMediaTemplate = await ConvertAndValidate(new SocialMediaMapper().Map(socialMediaLinksItem), sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return await _sitecore9Client.CreateItem<SxaSocialMediaTemplate>(sxaSocialMediaTemplate, insertionPath);
        }

        private async Task<SxaSocialMediaTemplate> ConvertAndValidate(SxaSocialMediaTemplate sxaSocialMediaTemplate, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            //link field
            var convertedContent = await _linkFieldMigration.ConvertInternalLinks(sxaSocialMediaTemplate.OnlyOnceCode, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sxaSocialMediaTemplate.OnlyOnceCode)) //internal link
            {
                //TODO: convert the convertedContent from <link> to <a>?
                migrationLogger.LogTrace($"Converting field 'OnlyOnceCode' in sxaSocialMediaTemplate item:'{sxaSocialMediaTemplate?.ItemName}' sitecore 9 path: '{insertionPath}' Before:'{sxaSocialMediaTemplate.OnlyOnceCode}' After:'{convertedContent}'");
                sxaSocialMediaTemplate.OnlyOnceCode = convertedContent;
            }

            return sxaSocialMediaTemplate;
        }
    }
}
