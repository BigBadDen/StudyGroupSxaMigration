using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaFolderService : SxaServiceBase, ISxaService
    {
        public SxaFolderService(ISitecore9Client sitecore9Client,
                                     ILogger<SxaFolderService> logger,
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
        /// Creates folder item in sitecore 9 website. Also converts internal links in the content rich text field
        /// Passes param to CreateClient method to ensure that if the folder item already exists, it's only logged as info rather than a warning
        /// </summary>
        /// <param name="sitecore8Widget"></param>
        /// <param name="sxaSiteRootPath"></param>
        /// <param name="sitecore8SiteRootPath"></param>
        /// <param name="insertionPath"></param>
        /// <returns></returns>
        public async Task<bool> Create(string folderName, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting New folder Item:'{folderName}' to path: '{insertionPath}'");

            if (!String.IsNullOrEmpty(folderName))
            {
                SitecoreItem folder = new SitecoreItem()
                {
                    ItemName = folderName,
                    TemplateID = SxaTemplateIds.Folder,
                    ItemLanguage = "en",
                    DisplayName = folderName
                };
                return await _sitecore9Client.CreateItem<SitecoreCommon.Models.SitecoreItem>(folder, insertionPath, false);
            }
            return false;
        }
    }
}
