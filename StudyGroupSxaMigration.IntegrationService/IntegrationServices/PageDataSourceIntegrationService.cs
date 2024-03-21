using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.IntegrationService.Migration;
using StudyGroupSxaMigration.ItemServices.Services;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore8Constants.Extensions;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreConstants;
using StudyGroupSxaMigration.IntegrationService.ContentPageMigration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.IntegrationService.IntegrationServices
{
    public class PageDataSourceIntegrationService : IntegrationServiceBase, IIntegrationService
    {
        private int numberOfPagesFound = 0;
        private ContentPageItemMigration _contentPageItemMigration;

        /// <summary>
        /// Initialise required objects (carried out in base class)
        /// </summary>
        /// <param name="sitecore8Client"></param>
        /// <param name="sitecore9Client"></param>
        /// <param name="sitecore8Repository"></param>
        /// <param name="logger"></param>
        /// <param name="migrations"></param>
        public PageDataSourceIntegrationService(
                                ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ISitecore8Repository sitecore8Repository,
                                ILogger<PageDataSourceIntegrationService> logger,
                                IEnumerable<IItemMigration> migrations,
                                ISitecore8WebsiteConfiguration sitecore8Website,
                                Sitecore9Website sitecore9Website,
                                ApplicationSettings applicationSettings, 
                                ContentPageItemMigration contentPageItemMigration) :
                base(sitecore8Client,
                    sitecore9Client,
                    sitecore8Repository,
                    logger,
                    migrations,
                    sitecore8Website,
                    sitecore9Website,
                    applicationSettings
                    )
        {
            _contentPageItemMigration = contentPageItemMigration;
        }

        /// <summary>
        /// Initialise counters for all migration types (in _migrations) 
        /// plus an additional one for _contentPageItemMigration, which is not part of the _migrations collection
        /// Run the migrations for all page data items and page content (e.g. metadata)
        /// </summary>
        /// <returns></returns>
        public async Task Run()
        {
            try
            {
                InitialiseAllMigrationCounters();
                InitialiseCounter(_contentPageItemMigration.GetType().Name);

                await StartPageDataItemMigration();

                if (_applicationSettings.IntegrationServiceSettings.PageDataSourceIntegrationServiceCreateDataItems)
                {
                    LogSummaryOfItemsUpdated(this.GetType().Name, numberOfPagesFound);
                }
                if (_applicationSettings.IntegrationServiceSettings.PageDataSourceIntegrationServiceUpdatePageItems)
                {
                    LogSummaryOfPageContentUpdates(this.GetType().Name, _contentPageItemMigration.GetType().Name, numberOfPagesFound);
                }
            }
            catch (Exception ex)
            {
                migrationLogger.LogError("Unexpected error occurred during migration of page datasource items", ex);
            }
        }

        /// <summary>
        /// 1) Migrate all data items under the home page
        /// 2) Then Run MigrateDataItemsForAllPageTypes, passing Home item parameter. This begins the loop, finding all page items under the home page and then
        /// migrating their page items, and so on, until all pages and data items have been retrieved and migrated.
        /// </summary>
        /// <returns></returns>
        private async Task StartPageDataItemMigration()
        {
            if (!_sitecore8Website.HasHomePageTemplate())
            {
                throw new Exception("No home page template defined for sitecore 8 website");
            }
            var homeItem = await _sitecore8Repository.GetItemByPath<SitecoreItem>(_sitecore8Website.HomePagePath, _sitecore8Website.PageTemplates.HomePage, true);
            if (homeItem == null)
            {
                throw new ArgumentException($"home item '{_sitecore8Website?.HomePagePath}' not found for website ");
            }

            numberOfPagesFound++;

            if (!_applicationSettings.CheckForInconsistentFolderNaming)
            {
                migrationLogger.LogWarningLineSeparator();
                migrationLogger.LogWarning("CheckForInconsistentFolderNaming is switched OFF, so only there will be no additional folder checks for data items if they aren't found in the expected location");
                migrationLogger.LogWarningLineSeparator();
            }

            await RunMigrationsForPage(homeItem);
            await MigrateForAllPageTypes(homeItem, 1);
        }

        /// <summary>
        /// for each page type, retrieve all pages directly below current page and then migrate 
        /// </summary>
        /// <param name="sitecorePageItem"></param>
        /// <returns></returns>
        private async Task MigrateForAllPageTypes(SitecoreItem sitecorePageItem, int itemDepth)
        {
            if (_sitecore8Website.HasHubPageTemplate())
            {
                await MigrateByPageType(sitecorePageItem.ItemID, _sitecore8Website.PageTemplates.HubPage, itemDepth, "hub page");
            }
            if (_sitecore8Website.HasInternalPageTemplate())
            {
                await MigrateByPageType(sitecorePageItem.ItemID, _sitecore8Website.PageTemplates.InternalPage, itemDepth, "internal page");
            }
            if (_sitecore8Website.HasGenericPageTemplate())
            {
                await MigrateByPageType(sitecorePageItem.ItemID, _sitecore8Website.PageTemplates.GenericPage, itemDepth, "generic page");
            }
            if (_sitecore8Website.HasCampaignPageTemplate())
            {
                await MigrateByPageType(sitecorePageItem.ItemID, _sitecore8Website.PageTemplates.CampaignPage, itemDepth, "campaign page");
            }
         }

        /// <summary>
        /// Retrieve and then migrate all data items under a specified current page
        /// Then, calls the MigrateDataItemsForAllPageTypes to run through the loop again, finding all sub-pages under the current page
        /// NB. This runs up to a maximum depth of 5 items as the sitecore 8 sites should never go any deeper than this.
        /// </summary>
        /// <param name="currentPageId"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        private async Task MigrateByPageType(string currentPageId, string templateId,int itemDepth, string pageTypeDescription)
        {
            migrationLogger.LogTrace($"Item depth: {itemDepth}");

            migrationLogger.LogDebug($"Retrieving child items for page type: {pageTypeDescription}");

            List<SitecoreItem> childItems = await _sitecore8Repository.GetChildrenById<SitecoreItem>(currentPageId, templateId);
            if (childItems?.Count > 0)
            {
                migrationLogger.LogDebug($"Found {childItems.Count} {pageTypeDescription} child items");

                foreach (SitecoreItem sitecorePageItem in childItems)
                {
                    numberOfPagesFound++;

                    migrationLogger.LogDebugWithLineSeparator($"Retrieving page {sitecorePageItem.ItemPath}");

                    await RunMigrationsForPage(sitecorePageItem);

                    if (itemDepth <= _applicationSettings.MaximumPageHierarchyDepth)
                    {
                        await MigrateForAllPageTypes(sitecorePageItem, itemDepth + 1);
                    }
                    else
                    {
                        migrationLogger.LogWarning($"Maximum page hierarchy reached - will not search any deeper in the content tree. Current page: {sitecorePageItem.ItemPath}");
                    }
                }
            }
        }

        /// <summary>
        /// Migrate page data items and also update the page item fields (i.e. meta tags)
        /// (depending on which of these options is switched on in the appsettings.json config)
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        private async Task RunMigrationsForPage(SitecoreItem pageItem)
        {
            if (_applicationSettings.IntegrationServiceSettings.PageDataSourceIntegrationServiceCreateDataItems)
            {
                await MigrateAllDataItems(pageItem);
            }
            if (_applicationSettings.IntegrationServiceSettings.PageDataSourceIntegrationServiceUpdatePageItems)
            {
                await UpdateContentPageItem(pageItem);
            }
        }

        /// <summary>
        /// For each migration class defined in _migrations list (e.g. AccordionMigration, ButtonGroupMigration etc.),
        /// run the MigratePageDataItems method  to migrate all items of each template type.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private async Task MigrateAllDataItems(SitecoreItem item)
        {
            string currentItemMigrationClass;

            migrationLogger.LogDebug($"Migrating all data items for item: {item.ItemPath}");

            foreach (IItemMigration itemMigrationClass in _migrations)
            {
                try
                {
                    currentItemMigrationClass = itemMigrationClass.GetType()?.Name;
                    if (ExcludeThisMigration(currentItemMigrationClass))
                    {
                        migrationLogger.LogTrace($"{currentItemMigrationClass} is excluded from migration of page data items!");
                        continue;
                    }
                    ItemUpdateCounter pageUpdateCounter = await itemMigrationClass.MigratePageDataItems(item);
                    if (pageUpdateCounter.ItemsFoundInSitecore8 > 0)
                    {
                        migrationUpdateCounter[currentItemMigrationClass].AppendLatestUpdates(pageUpdateCounter);
                    }
                }
                catch (Exception ex)
                {
                    migrationLogger.LogError($"Unexpected error occurred during migration of page data items for item: '{item?.ItemPath}'. Migration type:'{itemMigrationClass?.GetType().ToString()}'", ex);
                }
            }
        }

        /// <summary>
        /// Update page items - meta data etc.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private async Task UpdateContentPageItem(SitecoreItem item)
        {
            migrationLogger.LogDebug($"Migrating meta tags for page: {item.ItemPath}");
            
            try
            {
                ItemUpdateCounter pageUpdateCounter = await _contentPageItemMigration.UpdateItemFields(item);
                migrationUpdateCounter[_contentPageItemMigration.GetType().Name].AppendLatestUpdates(pageUpdateCounter);
            }
            catch (Exception ex)
            {
                migrationLogger.LogError($"Unexpected error occurred during migration of meta tags for item: '{item?.ItemPath}'.", ex);
            }

        }
    }
}
