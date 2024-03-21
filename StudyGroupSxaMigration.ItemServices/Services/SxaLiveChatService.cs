using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using System;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaLiveChatService : SxaServiceBase, ISxaService
    {
        public SxaLiveChatService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaLiveChatService> logger,
                                        ApplicationSettings applicationSettings,
                                        RichTextFieldMigration richTextFieldMigration) :
                base(sitecore9Client,
                    logger,
                    applicationSettings,
                    sitecore8Client: null,
                    richTextFieldMigration: richTextFieldMigration)
        {
        }

        public async Task<bool> Create(LiveChat liveChatItem, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting new livechat item:'{liveChatItem?.ItemName}' to path: '{insertionPath}'");

            SgSxaLiveChat sxaLiveChatItem = await ConvertAndValidate(new LiveChatMapper().Map(liveChatItem), sxaSiteRootPath, sitecore8SiteRootPath, insertionPath);

            return (sxaLiveChatItem == null ? false : await _sitecore9Client.CreateItem<SgSxaLiveChat>(sxaLiveChatItem, insertionPath));
        }

        private async Task<SgSxaLiveChat> ConvertAndValidate(SgSxaLiveChat sxaLiveChatItem, string sxaSiteRootPath, string sitecore8SiteRootPath, string insertionPath)
        {
            //rich text field
            var convertedContent = await _richTextFieldMigration.ValidateAndConvertLinks(sxaLiveChatItem.OfflineMessage, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sxaLiveChatItem.OfflineMessage))
            {
                migrationLogger.LogTrace($"Converting field 'OfflineMessage' in LiveChat item:'{sxaLiveChatItem?.ItemName} sitecore 9 path: '{insertionPath}' Before:'{sxaLiveChatItem.OfflineMessage}' After:'{convertedContent}' ");
                sxaLiveChatItem.OfflineMessage = convertedContent;
            }

            //rich text field
            convertedContent = await _richTextFieldMigration.ValidateAndConvertLinks(sxaLiveChatItem.OnlineMessage, sxaSiteRootPath, sitecore8SiteRootPath);
            if (!String.Equals(convertedContent, sxaLiveChatItem.OnlineMessage))
            {
                migrationLogger.LogTrace($"Converting field 'OnlineMessage' in LiveChat item:'{sxaLiveChatItem?.ItemName} sitecore 9 path: '{insertionPath}' Before:'{sxaLiveChatItem.OnlineMessage}' After:'{convertedContent}' ");
                sxaLiveChatItem.OnlineMessage = convertedContent;
            }

            return sxaLiveChatItem;
        }
    }
}
