using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.IntegrationService.Migration;
using StudyGroupSxaMigration.ItemServices.Services;
using StudyGroupSxaMigration.Logging.Exceptions;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreConstants;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.IntegrationService.ItemMigration
{
    public class LiveChatMigration : MigrationBase, IItemMigration
    {
        public LiveChatMigration(
                            ISitecore8Client sitecore8Client,
                            ISitecore9Client sitecore9Client,
                            ISitecore8Repository sitecore8Repository,
                            ILogger<LiveChatMigration> logger,
                            IEnumerable<ISxaService> sxaServices,
                            ISitecore8WebsiteConfiguration sitecore8Website,
                            Sitecore9Website sitecore9Website,
                            ApplicationSettings applicationSettings
                            )
                        : base(
                            sitecore8Client,
                            sitecore9Client,
                            sitecore8Repository,
                            logger,
                            sxaServices,
                            sitecore8Website,
                            sitecore9Website,
                            applicationSettings)
        {
            this.HasHierarchicalItemStructure = false;
        }

        /// <summary>
        /// Retrieve all and migrate all Hero items under the Data folder for this page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            //do nothing, LiveChat only makes sense as a Shared Item
            return new ItemUpdateCounter();
        }

        /// <summary>
        /// Retrieve LiveChat items from Sitecore 8, then insert into sitecore 9 as SgSxaLiveChat
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.LiveChat))
            {
                migrationLogger.LogDebug($"Migrating Shared LiveChat Items");

                List<LiveChat> sitecore8LiveChatItems = await _sitecore8Repository.GetItemChildrenByPath<LiveChat>(_sitecore8Website.SharedItemFolderPaths.LiveChat, _sitecore8Website.WebsiteTemplateIds.LiveChat);

                if (sitecore8LiveChatItems?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8LiveChatItems.Count} Shared LiveChat Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.LiveChat}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.LiveChat}");
                    await InsertLiveChatItems(sitecore8LiveChatItems, _sitecore9Website.SharedItemPaths.LiveChat);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertLiveChatItems(List<LiveChat> sitecore8LiveChatItems, string insertionPath)
        {
            if (sitecore8LiveChatItems?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8LiveChatItems.Count;

                SxaLiveChatService sxaLiveChatService = (SxaLiveChatService)GetSxaService(typeof(SxaLiveChatService));

                foreach (LiveChat livechat in sitecore8LiveChatItems)
                {
                    try
                    {
                        if (await sxaLiveChatService.Create(livechat, _sitecore9Website.RootPath, _sitecore8Website.RootPath, insertionPath))
                        {
                            itemUpdateCounter.ItemsMigrated++;
                        }
                        else
                        {
                            itemUpdateCounter.ItemsSkipped++;
                        }
                    }
                    catch (FailedInsertException failedInsertException)
                    {
                        migrationLogger.LogFailedInsert(typeof(LiveChat), insertionPath, livechat?.ItemName, failedInsertException);
                        itemUpdateCounter.ItemsFailedToInsert++;
                    }
                    catch (LinkException ex)
                    {
                        migrationLogger.LogFailedInsert(typeof(LiveChat), insertionPath, livechat?.ItemName, ex);
                        itemUpdateCounter.ItemsFailedToInsert++;
                    }
                }
            }
        }
    }
}
