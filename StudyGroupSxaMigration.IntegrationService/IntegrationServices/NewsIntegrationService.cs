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
    public class NewsIntegrationService : IntegrationServiceBase, IIntegrationService
    {
        private int numberOfNewsPagesFound;
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
        public NewsIntegrationService(
                                ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ISitecore8Repository sitecore8Repository,
                                ILogger<NewsIntegrationService> logger,
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

                await MigrateNewsListingAndAllNewsArticlesItems();

                LogSummaryOfBlogUpdates(this.GetType().Name, numberOfNewsPagesFound, pagesUpdatedSuccessfully, pageUpdateFailures);
            }
            catch (Exception ex)
            {
                migrationLogger.LogError("Unexpected error occurred during migration of news pages and news listing data items", ex);
            }
        }

        /// <summary>
        /// 1) Retrieve and migrate the news listing page (i.e. update the equivalent page in Sitecore 9), then insert any hero data items
        /// 2) Then repeat the same process for all news articles.
        /// </summary>
        /// <returns></returns>
        private async Task MigrateNewsListingAndAllNewsArticlesItems()
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

            if (!_sitecore8Website.HasNewsListingPageTemplate())
            {
                migrationLogger.LogWarning($"No news listing page template has been configured for Sitecore 8 website");
                return;
            }

            var newsListingPage = await GetSitecore8NewsListingPage(homeItem.ItemID);
            if (newsListingPage != null)
            {
                numberOfNewsPagesFound++;

                await UpdatePageContentFields(newsListingPage, _sitecore8Website.PageTemplates.NewsListingPage, "News Listing Page");
                await MigrateDataItemsForNewsListingPage(newsListingPage);

                if (!_sitecore8Website.HasNewsArticlePageTemplate())
                {
                    migrationLogger.LogWarning($"No NewsArticle Page Template has been configured for the Sitecore 8 website");
                }
                else
                {
                    await MigrateAllNewsArticleAndHeroItems(newsListingPage.ItemID);
                }

                migrationLogger.LogInfo($"Completed Sitecore 9 News to Sxa Blog migration. Number of Sitecore 8 pages retrieved: {numberOfNewsPagesFound}");
            }
            else
            {
                migrationLogger.LogWarning($"News listing page not found in Sitecore 8. (news template id:{ _sitecore8Website.PageTemplates.NewsListingPage}");
            }
        }

        private async Task<SitecoreItem> GetSitecore8NewsListingPage(string homePageId)
        {
            migrationLogger.LogDebug($"Retrieving news listing page");

            SitecoreItem newsListingPage = null;

            List<SitecoreItem> childItems = await _sitecore8Repository.GetChildrenById<SitecoreItem>(homePageId, _sitecore8Website.PageTemplates.NewsListingPage);
            if (childItems?.Count > 0)
            {
                newsListingPage = childItems[0];
                migrationLogger.LogDebug($"Found news listing page {newsListingPage.ItemPath}");
            }
            return newsListingPage;
        }

        private async Task UpdatePageContentFields(SitecoreItem newsItem, string pageTemplateId, string pageTypeDescription)
        {
            bool success = false;

            migrationLogger.LogDebug($"Updating field values for {pageTypeDescription}");

            if (string.Equals(pageTemplateId, _sitecore8Website.PageTemplates.NewsListingPage, StringComparison.OrdinalIgnoreCase))
            {
                success = await newsListingMigration.UpdateItemFields(newsItem.ItemID);
            }
            else if (string.Equals(pageTemplateId, _sitecore8Website.PageTemplates.NewsArticlePage, StringComparison.OrdinalIgnoreCase))
            {
                success = await newsArticleMigration.UpdateItemFields(newsItem.ItemID);
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
        /// For each news article page, update the equivalent blog post in sitecore 9 and then migrate any hero data items
        /// </summary>
        /// <param name="sitecorePageItem"></param>
        /// <returns></returns>
        private async Task MigrateAllNewsArticleAndHeroItems(string newsListingPageId)
        {
            migrationLogger.LogDebug("Retrieving child items for news listing page");

            List<SitecoreItem> newsArticles = await _sitecore8Repository.GetChildrenById<SitecoreItem>(newsListingPageId, _sitecore8Website.PageTemplates.NewsArticlePage);

            if (newsArticles?.Count > 0)
            {
                migrationLogger.LogDebug($"Found {newsArticles.Count} newsArticles");
                numberOfNewsPagesFound += newsArticles.Count;
            }
            else
            {
                migrationLogger.LogWarning($"No news articles retrieved from Sitecore 8. (NewsArticlePage template id: {_sitecore8Website.PageTemplates.NewsArticlePage}");
                return;
            }

            foreach (SitecoreItem sitecorePageItem in newsArticles)
            {
                try
                {
                    await ShowWarningOfDataItem(sitecorePageItem);

                    if (_sitecore8Website.HasBlogEntryPageTemplate())
                    {
                        await UpdatePageContentFields(sitecorePageItem, "{" + sitecorePageItem.TemplateID + "}", "News Article Page");
                    }
                }
                catch (Exception ex)
                {
                    migrationLogger.LogError($"Unexpected error occurred during migration of blog entry items  (from sitecore 8 news articles) for item: '{sitecorePageItem?.ItemPath}'", ex);
                }
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

            migrationLogger.LogDebug($"Migrating news data items for item: {item.ItemPath}");

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
                    migrationLogger.LogError($"Unexpected error occurred during {currentItemMigrationClass} of blog data (from sitecore 8 news) items. News item path: '{item?.ItemPath}'.", ex);
                }
            }
        }

        private async Task ShowWarningOfDataItem(SitecoreItem item)
        {
            try
            {
                migrationLogger.LogDebug($"Checking data items under News Article item: {item.ItemPath}");

                //get all children items under current item
                List<SitecoreItem> dataFolderItems = await _sitecore8Repository.GetItemChildrenByPath<SitecoreItem>($"{item.ItemPath}/{Sitecore8Paths.PageItemsFolderName}");

                //If current news article item has some data folders inside, go through all of them to check if there are some data items need to be migrated
                if (dataFolderItems != null && dataFolderItems.Any())
                {
                    foreach (var folder in dataFolderItems)
                    {
                        List<SitecoreItem> dataItems = await _sitecore8Repository.GetItemChildrenByPath<SitecoreItem>(folder.ItemPath);

                        if (dataItems != null && dataItems.Any())
                        {
                            migrationLogger.LogWarning($"News Article data item warning: There are {dataItems.Count} items under {folder.ItemPath}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                migrationLogger.LogError($"Unexpected error occurred during checking data items under news article item: '{item.ItemPath}'.", ex);
            }
        }
    }
}
