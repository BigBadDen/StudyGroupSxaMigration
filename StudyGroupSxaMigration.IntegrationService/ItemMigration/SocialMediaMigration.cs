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
    public class SocialMediaMigration : MigrationBase, IItemMigration
    {
        public SocialMediaMigration(
                                ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ISitecore8Repository sitecore8Repository,
                                ILogger<SocialMediaMigration> logger,
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
            this.HasHierarchicalItemStructure = true;
        }

        /// <summary>
        /// Social Media items only on shared folder, this function do nothing
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            await Task.CompletedTask;
            return new ItemUpdateCounter();
        }

        /// <summary>
        /// Retrieve Social Media items under shared items folder then insert into sitecore 9
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.SocialMedia))
            {
                migrationLogger.LogDebug($"Migrating Shared Social Media Items");

                List<SocialMediaContainer> sitecore8SocialMediaContainers = await _sitecore8Repository.GetItemChildrenByPath<SocialMediaContainer>(_sitecore8Website.SharedItemFolderPaths.SocialMedia, _sitecore8Website.WebsiteTemplateIds.SocialMediaContainer);

                if (sitecore8SocialMediaContainers?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8SocialMediaContainers.Count} Shared Social Media Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.SocialMedia}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.SocialMedia}");
                    await InsertSocialMediaContainerAndItems(sitecore8SocialMediaContainers, _sitecore9Website.SharedItemPaths.SocialMedia);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertSocialMediaContainerAndItems(List<SocialMediaContainer> sitecore8SocialMediaContainers, string insertionPath)
        {
            if (sitecore8SocialMediaContainers?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8SocialMediaContainers.Count;

                SxaSocialMediaService sxaSocialMediaService = (SxaSocialMediaService)GetSxaService(typeof(SxaSocialMediaService));
                SxaSocialMediaContainerService sxaSocialMediaContainerService = (SxaSocialMediaContainerService)GetSxaService(typeof(SxaSocialMediaContainerService));

                foreach (SocialMediaContainer socialMediaContainer in sitecore8SocialMediaContainers)
                {
                    try
                    {
                        if (await sxaSocialMediaContainerService.Create(socialMediaContainer, insertionPath))
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
                        migrationLogger.LogFailedInsert(typeof(SocialMediaContainer), insertionPath, socialMediaContainer?.ItemName, failedInsertException);
                    }

                    string socialMediaContainerItemPath = insertionPath + $"/{socialMediaContainer.ItemName}";

                    if (socialMediaContainer.HasChildren)
                    {
                        socialMediaContainer.SocialMediaLinkItems = await _sitecore8Repository.GetChildrenById<SocialMediaLinks>(socialMediaContainer.ItemID, _sitecore8Website.WebsiteTemplateIds.SocialMediaLinks);

                        if (socialMediaContainer.SocialMediaLinkItems?.Count > 0)
                        {
                            itemUpdateCounter.ChildItemsFoundInSitecore8 += socialMediaContainer.SocialMediaLinkItems.Count;

                            foreach (SocialMediaLinks socialMediaLinkItem in socialMediaContainer.SocialMediaLinkItems)
                            {
                                try
                                {
                                    if (await sxaSocialMediaService.Create(socialMediaLinkItem, _sitecore9Website.RootPath, _sitecore8Website.RootPath, socialMediaContainerItemPath))
                                    {
                                        itemUpdateCounter.ChildItemsMigrated++;
                                    }
                                    else
                                    {
                                        itemUpdateCounter.ChildItemsSkipped++;
                                    }
                                }
                                catch (FailedInsertException ex)
                                {
                                    itemUpdateCounter.ChildItemsFailedToInsert++;
                                    migrationLogger.LogFailedInsert(typeof(SocialMediaLinks), socialMediaContainerItemPath, socialMediaLinkItem?.ItemName, ex);
                                }
                                catch (LinkException ex)
                                {
                                    itemUpdateCounter.ChildItemsFailedToInsert++;
                                    migrationLogger.LogFailedInsert(typeof(SocialMediaLinks), socialMediaContainerItemPath, socialMediaLinkItem?.ItemName, ex);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
