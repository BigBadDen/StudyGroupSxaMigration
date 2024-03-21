using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.IntegrationService.Migration;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.Sitecore8Constants.Extensions;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.IntegrationService.IntegrationServices
{
    public class WeBlogIntegrationService : IntegrationServiceBase, IIntegrationService
    {
        private int weBlogPagesFound;
        private int pageUpdateFailures;
        private int pagesUpdatedSuccessfully;

        /// <summary>
        /// Initialise required objects (carried out in base class)
        /// </summary>
        /// <param name="sitecore8Client"></param>
        /// <param name="sitecore9Client"></param>
        /// <param name="sitecore8Repository"></param>
        /// <param name="logger"></param>
        /// <param name="migrations"></param>
        public WeBlogIntegrationService(
                                ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ISitecore8Repository sitecore8Repository,
                                ILogger<WeBlogIntegrationService> logger,
                                IEnumerable<IItemMigration> migrations,
                                ISitecore8WebsiteConfiguration sitecore8Website,
                                Sitecore9Website sitecore9Website,
                                ApplicationSettings applicationSettings,
                                IEnumerable<IBlogMigration> blogMigrations) :
                base(sitecore8Client,
                    sitecore9Client,
                    sitecore8Repository,
                    logger,
                    migrations,
                    sitecore8Website,
                    sitecore9Website,
                    applicationSettings,
                    blogMigrations)
        {
        }

        /// <summary>
        /// Validate that required DI classes exist, initialise migrationUpdateCounter (for hero data items only; pagesUpdateFailures & pagesUpdatedSuccessfully are used to log page update counts)
        /// </summary>
        /// <returns></returns>
        public async Task Run()
        {
            try
            {
                ThrowExceptionIfArgumentsAreMissing();
                InitialiseMigrationUpdateCounterForBlogs();

                await MigrateBlogHomeAndAllEntryItems();

                LogSummaryOfBlogUpdates(this.GetType().Name, weBlogPagesFound, pagesUpdatedSuccessfully, pageUpdateFailures);
            }
            catch (Exception ex)
            {
                migrationLogger.LogError("Unexpected error occurred during migration of blog pages and blog home datasource items", ex);
            }
        }

        /// <summary>
        /// 1) Migrate all data items under the home page
        /// 2) Then update blog home item fields and insert its page data items
        /// 3) Then retrieve all blog entry items recursively from Sitecore 8. For the equivalent blog post in Sitcore 9, update their item fields and insert any page data items
        /// </summary>
        /// <returns></returns>
        private async Task MigrateBlogHomeAndAllEntryItems()
        {
            if (!_sitecore8Website.HasHomePageTemplate())
            {
                throw new Exception("No home page template defined for sitecore 8 website");
            }
            var homeItem = await _sitecore8Repository.GetItemByPath<SitecoreItem>(_sitecore8Website.HomePagePath, _sitecore8Website.PageTemplates.HomePage, true);
            if (homeItem == null)
            {
                throw new ArgumentException($"home item '{_sitecore8Website?.HomePagePath}' not found for website (template id:{_sitecore8Website.PageTemplates.HomePage}) ");
            }

            if (!_sitecore8Website.HasBlogPageTemplate())
            {
                migrationLogger.LogWarning($"No blog home page template has been configured for Sitecore 8 website");
                return;
            }

            var blogHomePage = await GetSitecore8BlogHomePage(homeItem.ItemID);
            if (blogHomePage != null)
            {
                weBlogPagesFound++;
                //the idea is get all the blog entry items and blog category items to minimun the number of API calling
                List<SitecoreItem> blogItems = await _sitecore8Repository.GetAllChildrenRecursivelyById<SitecoreItem>(blogHomePage.ItemID,
                                                                                                                    _sitecore8Website.PageTemplates.BlogEntryPage, 
                                                                                                                    _sitecore8Website.PageTemplates.BlogCategoryPage, true);
                await UpdatePageContentFields(blogHomePage, _sitecore8Website.PageTemplates.BlogHomePage, "Blog Home Page", blogItems);
                await MigrateDataItemsForNewsListingPage(blogHomePage);

                if (!_sitecore8Website.HasBlogEntryPageTemplate())
                {
                    migrationLogger.LogWarning($"No Blog Entry Page Template has been configured for the Sitecore 8 website");
                }
                else
                {
                    await MigrateAllBlogEntryItemsAndHeroDataItems(blogItems);
                }
            }
            else
            {
                migrationLogger.LogWarning($" blog home page not found in Sitecore 8. (blog home template id:{ _sitecore8Website.PageTemplates.BlogHomePage}");
            }
            migrationLogger.LogInfo($"Completed weblog migration.");
        }

        private async Task<SitecoreItem> GetSitecore8BlogHomePage(string homePageId)
        {
            migrationLogger.LogDebug($"Retrieving blog home page");

            SitecoreItem blogPage = null;

            List<SitecoreItem> blogPagesDirectlyUnderHomeNode = await _sitecore8Repository.GetChildrenById<SitecoreItem>(homePageId, _sitecore8Website.PageTemplates.BlogHomePage);
            if (blogPagesDirectlyUnderHomeNode?.Count > 0)
            {
                blogPage = blogPagesDirectlyUnderHomeNode[0];
                migrationLogger.LogDebug($"Found blog home page {blogPage.ItemPath}");
            }
            return blogPage;
        }

        private async Task UpdatePageContentFields(SitecoreItem blogItem, string pageTemplateId, string pageTypeDescription, List<SitecoreItem> blogItems)
        {
            bool success = false;

            migrationLogger.LogDebug($"Updating field values for {pageTypeDescription}");

            if (string.Equals(pageTemplateId, _sitecore8Website.PageTemplates.BlogHomePage, StringComparison.OrdinalIgnoreCase))
            {
                success = await weBlogHomeMigration.UpdateItemFields(blogItem.ItemID);
            }
            else if (string.Equals(pageTemplateId, _sitecore8Website.PageTemplates.BlogEntryPage, StringComparison.OrdinalIgnoreCase))
            {
                success = await weBlogEntryMigration.UpdateItemFields(blogItem.ItemID, blogItems);
            }

            if (success)
            {
                pagesUpdatedSuccessfully++;
            }
            else
            {
                pageUpdateFailures++;
            }
        }

        /// <summary>
        /// Retrieve and all sitecore 8 blog entry items, by using a recursive search. Then update the equivalent item in Sitecore 9
        /// </summary>
        /// <param name="blogItems"></param>
        /// <returns></returns>
        private async Task MigrateAllBlogEntryItemsAndHeroDataItems(List<SitecoreItem> blogItems)
        {
            migrationLogger.LogDebug("Retrieving child items for blog Entry pages");

            var blogEntryItems = blogItems.Where(x => string.Equals(x.TemplateID, _sitecore8Website.PageTemplates.BlogEntryPage.Replace("{", "").Replace("}", ""), StringComparison.OrdinalIgnoreCase));
            if (blogItems?.Count > 0 && blogEntryItems.Any())
            {
                migrationLogger.LogDebug($"Found {blogEntryItems.Count()} blog entry items");
                weBlogPagesFound += blogEntryItems.Count();
            }
            else
            {
                migrationLogger.LogWarning($"No blog entry items  retrieved from Sitecore 8. (BlogEntryPage template id: {_sitecore8Website.PageTemplates.BlogEntryPage}");
                return;
            }

            foreach (SitecoreItem sitecorePageItem in blogEntryItems)
            {
                try
                {
                    await ShowWarningOfDataItem(sitecorePageItem);

                    if (_sitecore8Website.HasBlogEntryPageTemplate())
                    {
                        await UpdatePageContentFields(sitecorePageItem, "{" + sitecorePageItem.TemplateID + "}", "Blog Entry Page", blogItems);
                    }
                }
                catch (Exception ex)
                {
                    migrationLogger.LogError($"Unexpected error occurred during migration of blog entry items for item: '{sitecorePageItem?.ItemPath}'", ex);
                }
            }
        }

        private async Task ShowWarningOfDataItem(SitecoreItem item)
        {
            try
            {
                migrationLogger.LogDebug($"Checking data items under Blog Entry item: {item.ItemPath}");

                //get all children items under current item
                List<SitecoreItem> dataFolderItems = await _sitecore8Repository.GetItemChildrenByPath<SitecoreItem>($"{item.ItemPath}/{Sitecore8Paths.PageItemsFolderName}");

                //If current blog entry item has some data folders inside, go through all of them to check if there are some data items need to be migrated
                if (dataFolderItems != null && dataFolderItems.Any())
                {
                    foreach (var folder in dataFolderItems)
                    {
                        List<SitecoreItem> dataItems = await _sitecore8Repository.GetItemChildrenByPath<SitecoreItem>(folder.ItemPath);

                        if (dataItems != null && dataItems.Any())
                        {
                            migrationLogger.LogWarning($"Blog Entry data item warning: There are {dataItems.Count} items under {folder.ItemPath}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                migrationLogger.LogError($"Unexpected error occurred during checking data items under blog entry item: '{item.ItemPath}'.", ex);
            }
        }

        /// <summary>
        /// For each migration class defined in BlogDataItemMigrations in appsettings, run the MigratePageDataItems method to migrate all items of each template type.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private async Task MigrateDataItemsForNewsListingPage(SitecoreItem item)
        {
            string currentItemMigrationClass = String.Empty;

            migrationLogger.LogDebug($"Migrating WeBlog data items for item: {item.ItemPath}");

            foreach (IItemMigration itemMigrationClass in blogDataItemMigrations)
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
                    migrationLogger.LogError($"Unexpected error occurred during {currentItemMigrationClass} of blog data (from sitecore 8 weblog) items. Weblog item path: '{item?.ItemPath}'.", ex);
                }
            }
        }
    }
}
