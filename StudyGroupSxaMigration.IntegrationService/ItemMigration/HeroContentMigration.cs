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
    public class HeroContentMigration : MigrationBase, IItemMigration
    {
        public HeroContentMigration(
                            ISitecore8Client sitecore8Client,
                            ISitecore9Client sitecore9Client,
                            ISitecore8Repository sitecore8Repository,
                            ILogger<HeroContentMigration> logger,
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
            itemUpdateCounter = new ItemUpdateCounter();

            string templateId = _sitecore8Website.WebsiteTemplateIds.Hero;
            string subfolderNameForThisItemType = _sitecore8Website.PageItemSubFolders.Heroes;

            string pageItemsSubFolderForThisType = GetPageItemsSubFolderPathForItemType(pageItem, subfolderNameForThisItemType);

            var dataItems = await _sitecore8Repository.GetItemChildrenByPath<Hero>(pageItemsSubFolderForThisType, templateId);

            // Additional checks (depending on config settings) to see if items of this type are located in any other folders under Page Items

            var itemsAreInExpectedLocation = (dataItems?.Count > 0);

            if (DoCheckForAlternativeFolders(itemsAreInExpectedLocation))
            {
                string currentItemDescription = "Hero";

                var sitecoreItemList = await CheckForAlternativeFolders<Hero>(pageItem, pageItemsSubFolderForThisType, subfolderNameForThisItemType,
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

                migrationLogger.LogDebug($"Migrating Page Data Hero Items from path: '{pageItemsSubFolderForThisType}'");

                if (dataItems.Count > 0)
                {
                    await InsertHeroes(dataItems, targetPath);
                }
            }
            return itemUpdateCounter;
        }

        /// <summary>
        /// Retrieve Hero items from Sitecore 8, then insert into sitecore 9 as SgSxaHero
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.HeroContent))
            {
                migrationLogger.LogDebug($"Migrating Shared Hero Items");

                List<Hero> sitecore8Heroes = await _sitecore8Repository.GetItemChildrenByPath<Hero>(_sitecore8Website.SharedItemFolderPaths.HeroContent, _sitecore8Website.WebsiteTemplateIds.Hero);

                if (sitecore8Heroes?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8Heroes.Count} Shared Hero Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.HeroContent}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.Heroes}");
                    await InsertHeroes(sitecore8Heroes, _sitecore9Website.SharedItemPaths.Heroes);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertHeroes(List<Hero> sitecore8Heroes, string insertionPath)
        {
            if (sitecore8Heroes?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8Heroes.Count;

                SxaHeroService sxaHeroService = (SxaHeroService)GetSxaService(typeof(SxaHeroService));

                foreach (Hero hero in sitecore8Heroes)
                {
                    try
                    {
                        if (await sxaHeroService.Create(hero, _sitecore9Website.RootPath, _sitecore8Website.RootPath, insertionPath))
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
                        migrationLogger.LogFailedInsert(typeof(Hero), insertionPath, hero?.ItemName, failedInsertException);
                        itemUpdateCounter.ItemsFailedToInsert++;
                    }
                    catch (LinkException ex)
                    {
                        migrationLogger.LogFailedInsert(typeof(Hero), insertionPath, hero?.ItemName, ex);
                        itemUpdateCounter.ItemsFailedToInsert++;
                    }
                }
            }
        }
    }
}
