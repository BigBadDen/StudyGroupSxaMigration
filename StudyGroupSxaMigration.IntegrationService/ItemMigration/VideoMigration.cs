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
    public class VideoMigration : MigrationBase, IItemMigration
    {
        public VideoMigration(
                            ISitecore8Client sitecore8Client,
                            ISitecore9Client sitecore9Client,
                            ISitecore8Repository sitecore8Repository,
                            ILogger<VideoMigration> logger,
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
        /// Retrieve all and migrate all Videos under the Data folder for this page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            itemUpdateCounter = new ItemUpdateCounter();

            string templateId = _sitecore8Website.WebsiteTemplateIds.Video;
            string subfolderNameForThisItemType = _sitecore8Website.PageItemSubFolders.Videos;

            string pageItemsSubFolderForThisType = GetPageItemsSubFolderPathForItemType(pageItem, subfolderNameForThisItemType);

            var dataItems = await _sitecore8Repository.GetItemChildrenByPath<Video>(pageItemsSubFolderForThisType,templateId);

            // Additional checks (depending on config settings) to see if items of this type are located in any other folders under Page Items

            var itemsAreInExpectedLocation = (dataItems?.Count > 0);

            if (DoCheckForAlternativeFolders(itemsAreInExpectedLocation))
            {
                string currentItemDescription = "Video";

                var sitecoreItemList = await CheckForAlternativeFolders<Video>(pageItem, pageItemsSubFolderForThisType, subfolderNameForThisItemType,
                                                                                                            templateId, currentItemDescription, itemsAreInExpectedLocation);

                if (!itemsAreInExpectedLocation && sitecoreItemList.SitecoreItems?.Count > 0 && !String.IsNullOrEmpty(sitecoreItemList.FolderName) && !String.IsNullOrEmpty(sitecoreItemList.FolderPath))
                {
                    dataItems = sitecoreItemList.SitecoreItems;
                    pageItemsSubFolderForThisType = sitecoreItemList.FolderPath;
                    subfolderNameForThisItemType = sitecoreItemList.FolderName;
                }
            }

            // Migration

            if (dataItems?.Count > 0)
            {
                string targetPath = GetSitecore9TargetPath(pageItemsSubFolderForThisType, subfolderNameForThisItemType);

                migrationLogger.LogDebug($"Migrating Page Data Video Items from path: '{pageItemsSubFolderForThisType}'");

                if (dataItems.Count > 0)
                {
                    await InsertVideos(dataItems, targetPath);
                }
            }
            return itemUpdateCounter;
        }

        /// <summary>
        /// Retrieve Video items from Sitecore 8, then insert into sitecore 9 as SxaVideo
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.Videos))
            {
                migrationLogger.LogDebug($"Migrating Shared Video Items");

                List<Video> sitecore8Videos = await _sitecore8Repository.GetItemChildrenByPath<Video>(_sitecore8Website.SharedItemFolderPaths.Videos, _sitecore8Website.WebsiteTemplateIds.Video);

                if (sitecore8Videos?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8Videos.Count} Shared Video Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.Videos}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.Videos}");
                    await InsertVideos(sitecore8Videos, _sitecore9Website.SharedItemPaths.Videos);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertVideos(List<Video> sitecore8Videos, string insertionPath)
        {
            if (sitecore8Videos?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8Videos.Count;

                SxaVideoService sxaVideoService = (SxaVideoService)GetSxaService(typeof(SxaVideoService));

                foreach (Video video in sitecore8Videos)
                {
                    try
                    {
                        if (await sxaVideoService.Create(video, _sitecore9Website.RootPath, _sitecore8Website.RootPath, insertionPath))
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
                        itemUpdateCounter.ItemsFailedToInsert++;
                        migrationLogger.LogFailedInsert(typeof(Video), insertionPath, video?.ItemName, failedInsertException);
                    }
                    catch (LinkException ex)
                    {
                        itemUpdateCounter.ItemsFailedToInsert++;
                        migrationLogger.LogFailedInsert(typeof(Video), insertionPath, video?.ItemName, ex);
                    }
                }
            }
        }
    }
}
