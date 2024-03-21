using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.IntegrationService.Migration;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.SitecoreConstants;
using System;
using System.Collections.Generic;
using StudyGroupSxaMigration.Logging;
using StudyGroupSxaMigration.AppSettings;
using System.Linq;
using StudyGroupSxaMigration.IntegrationService.BlogMigration;
using StudyGroupSxaMigration.IntegrationService.ItemMigration;

namespace StudyGroupSxaMigration.IntegrationService.IntegrationServices
{
    public class IntegrationServiceBase
    {
        internal static ISitecore8WebsiteConfiguration _sitecore8Website;
        internal static ISitecore8Client _sitecore8Client;
        internal static ISitecore9Client _sitecore9Client;
        internal ISitecore9Website _sitecore9Website;
        internal ISitecore8Repository _sitecore8Repository;
        internal IEnumerable<IItemMigration> _migrations;

        internal ILogger<IIntegrationService> _logger;
        internal ApplicationSettings _applicationSettings;
        internal IEnumerable<IBlogMigration> _blogMigrations;

        internal MigrationLogger migrationLogger;

        internal IBlogMigration weBlogHomeMigration;
        internal IBlogMigration weBlogEntryMigration;
        internal IBlogMigration newsArticleMigration;
        internal IBlogMigration newsListingMigration;

        // A subset of _migrations used for only for blog / news pages
        internal List<IItemMigration> blogDataItemMigrations;

        // Used to keep a tally of updates. Instantiated in IntegrationServiceBase
        internal Dictionary<string, ItemUpdateCounter> migrationUpdateCounter;

        /// <summary>
        /// Base constructor for non-blog migration classes (for blog base constructor, see further below...)
        /// Initialises required objects etc.
        /// </summary>
        /// <param name="sitecore8Client"></param>
        /// <param name="sitecore9Client"></param>
        /// <param name="sitecore8Repository"></param>
        /// <param name="logger"></param>
        /// <param name="migrations"></param>
        public IntegrationServiceBase(
                                    ISitecore8Client sitecore8Client,
                                    ISitecore9Client sitecore9Client,
                                    ISitecore8Repository sitecore8Repository,
                                    ILogger<IIntegrationService> logger,
                                    IEnumerable<IItemMigration> migrations,
                                    ISitecore8WebsiteConfiguration sitecore8Website,
                                    Sitecore9Website sitecore9Website,
                                    ApplicationSettings applicationSettings)
        {
            _sitecore8Client = sitecore8Client;
            _sitecore9Client = sitecore9Client;
            _sitecore8Repository = sitecore8Repository;
            _migrations = migrations;
            _logger = logger;
            _sitecore8Website = sitecore8Website;
            _sitecore9Website = sitecore9Website;
            _applicationSettings = applicationSettings;

            migrationLogger = new MigrationLogger(applicationSettings, logger);
            migrationUpdateCounter = new Dictionary<string, ItemUpdateCounter>();
        }

        /// <summary>
        /// Base constructor for blog migration classes
        /// Initialises required objects etc.
        /// </summary>
        /// <param name="sitecore8Client"></param>
        /// <param name="sitecore9Client"></param>
        /// <param name="sitecore8Repository"></param>
        /// <param name="logger"></param>
        /// <param name="migrations"></param>
        /// <param name="sitecore8Website"></param>
        /// <param name="sitecore9Website"></param>
        /// <param name="applicationSettings"></param>
        /// <param name="blogMigrations"></param>
        public IntegrationServiceBase(
                                   ISitecore8Client sitecore8Client,
                                   ISitecore9Client sitecore9Client,
                                   ISitecore8Repository sitecore8Repository,
                                   ILogger<IIntegrationService> logger,
                                   IEnumerable<IItemMigration> migrations,
                                   ISitecore8WebsiteConfiguration sitecore8Website,
                                   Sitecore9Website sitecore9Website,
                                   ApplicationSettings applicationSettings,
                                   IEnumerable<IBlogMigration> blogMigrations)
        {
            _sitecore8Client = sitecore8Client;
            _sitecore9Client = sitecore9Client;
            _sitecore8Repository = sitecore8Repository;
            _migrations = migrations;
            _logger = logger;
            _sitecore8Website = sitecore8Website;
            _sitecore9Website = sitecore9Website;
            _applicationSettings = applicationSettings;

            migrationLogger = new MigrationLogger(applicationSettings, logger);
            migrationUpdateCounter = new Dictionary<string, ItemUpdateCounter>();

            _blogMigrations = blogMigrations;

            weBlogHomeMigration = GetBlogMigration(typeof(WeBlogHomePageMigration));
            weBlogEntryMigration = GetBlogMigration(typeof(WeBlogEntryPageMigration));
            newsArticleMigration = GetBlogMigration(typeof(NewsArticleMigration));
            newsListingMigration = GetBlogMigration(typeof(NewsListingMigration));
        }

        internal bool ExcludeThisMigration(string itemMigrationClassName)
        {
            var isExcluded = _applicationSettings?.MigrationsToExlude?.Where(i => i == itemMigrationClassName).FirstOrDefault();
            return isExcluded != null;
        }

        /// <summary>
        ///  This is configured in appsettings.json as there is no need to migrate ALL data types for blog & news migration as they only usually use heroes and sometimes content boxes
        ///  Any additional data types can be included in appsettings.
        /// </summary>
        /// <param name="itemMigrationClassName"></param>
        /// <returns></returns>
        internal bool IsThisMigrationTypeRequiredForBlogs(string itemMigrationClassName)
        {
            var isRequired = _applicationSettings?.BlogDataItemMigrations?.Where(i => i == itemMigrationClassName).FirstOrDefault();
            return isRequired != null;
        }

        /// <summary>
        /// Retrieves sxaService from IEnumerable<ISxaService> _sxaServices. Throws exception if not found 
        /// </summary>
        /// <param name="sxaServiceType"></param>
        /// <returns></returns>
        private IBlogMigration GetBlogMigration(Type sxaBlogMigrationType)
        {
            IBlogMigration blogMigration = _blogMigrations.FirstOrDefault(i => i.GetType() == sxaBlogMigrationType);

            if (blogMigration == null)
                throw new MissingMemberException($"Unable to retrieve {sxaBlogMigrationType.Name} from blogMigrations");

            return blogMigration;
        }

        /// <summary>
        /// Retrieves sxaService from IEnumerable<ISxaService> _sxaServices. Throws exception if not found 
        /// </summary>
        /// <param name="sxaServiceType"></param>
        /// <returns></returns>
        internal IItemMigration GetHeroMigration()
        {
            IItemMigration heroMigration = _migrations.FirstOrDefault(i => i.GetType() == typeof(HeroContentMigration));
            if (heroMigration != null)
            {
                var currentItemMigrationClass = heroMigration.GetType()?.Name;
                if (ExcludeThisMigration(currentItemMigrationClass))
                {
                    migrationLogger.LogTrace($"{currentItemMigrationClass} is excluded from migrations!");
                }
            }
            return heroMigration;
        }

        /// <summary>
        /// initializes the migrationUpdateCounter counters for success, failed, skipped items - there is one counter for each class in _migrations
        /// </summary>
        internal void InitialiseAllMigrationCounters()
        {
            if (migrationUpdateCounter == null)
            {
                throw new Exception("migrationUpdateCounter is null - unable to execute InitialiseCounter in IntegrationServiceBase");
            }

            foreach (IItemMigration itemMigrationClass in _migrations)
            {
                InitialiseCounter(itemMigrationClass.GetType().Name);
                //string typeName = itemMigrationClass.GetType().Name;
                //migrationUpdateCounter.Add(typeName, new ItemUpdateCounter());
            }
        }

        /// <summary>
        /// Initializes the migrationUpdateCounter counter (for success, failed, skipped items)
        /// - for a specified class type
        /// </summary>
        /// <param name="typeName"></param>
        public void InitialiseCounter(string typeName)
        {
            if (String.IsNullOrEmpty(typeName))
            {
                throw new Exception("unable to InitialiseCounter in IntegrationServiceBase - typeName is null");
            }
            migrationUpdateCounter.Add(typeName, new ItemUpdateCounter());
        }

        /// <summary>
        /// initializes the counters for success, failed, skipped items
        /// Also initializes the global collection blogDataItemMigrations, which is a subset of _migrations and
        /// only contains migrations for data items associated with blog & news pages
        /// </summary>
        internal void InitialiseMigrationUpdateCounterForBlogs()
        {
            string currentItemMigrationClass;
            blogDataItemMigrations = new List<IItemMigration>();

            foreach (IItemMigration itemMigrationClass in _migrations)
            {
                currentItemMigrationClass = itemMigrationClass.GetType()?.Name;
                if (IsThisMigrationTypeRequiredForBlogs(currentItemMigrationClass))
                {
                    blogDataItemMigrations.Add(itemMigrationClass);

                    string typeName = itemMigrationClass.GetType().Name;
                    migrationUpdateCounter.Add(typeName, new ItemUpdateCounter());
                }
            }
        }

        /// <summary>
        /// Log success and failure count for news / blog items, then call LogItemsUpdatedForCurrentMigration to log stats for hero migration
        /// </summary>
        /// <param name="integrationServiceClassName"></param>
        internal void LogSummaryOfBlogUpdates(string integrationServiceClassName, int numberOfNewsPagesFound, int pagesUpdatedSuccessfully, int pageUpdateFailures)//, List<IItemMigration> itemMigrationsForBlogs)
        {
            migrationLogger.LogInfoWithLineSeparator($"Completed {integrationServiceClassName} migration. Migration statistics are detailed below:");

            migrationLogger.LogInfo($"Number of Sitecore 8 pages retrieved: {numberOfNewsPagesFound}");
            migrationLogger.LogInfo($"Update stats for Blog Entry & Blog Home items: successfully updated: {pagesUpdatedSuccessfully}, update failures: {pageUpdateFailures}");

            foreach (IItemMigration itemMigration in blogDataItemMigrations)
            {
                LogItemsUpdatedForCurrentMigration(itemMigration, integrationServiceClassName);
            }
        }

        /// <summary>
        /// Log success and failure count for page content item updates (meta tags)
        /// </summary>
        /// <param name="integrationServiceClassName"></param>
        internal void LogSummaryOfPageContentUpdates(string integrationServiceClassName, string itemMigrationClassTypeName, int noOfPagesFound)
        {
            migrationLogger.LogInfoWithLineSeparator($"Completed migration of Page Content ( {itemMigrationClassTypeName} - {integrationServiceClassName})");
            
            migrationLogger.LogInfo($"Number of Sitecore 8 pages retrieved: {noOfPagesFound}");
            migrationLogger.LogInfo($"Number of pages found: {noOfPagesFound} | PagesUpdated: {migrationUpdateCounter[itemMigrationClassTypeName].PagesUpdated} | PagesFailedToUpdate: {migrationUpdateCounter[itemMigrationClassTypeName].PagesFailedToUpdate}  | PagesNotFoundInSitecore9: {migrationUpdateCounter[itemMigrationClassTypeName].PagesNotFoundInSitecore9} | PagesSkipped: {migrationUpdateCounter[itemMigrationClassTypeName].PagesSkipped}");
         
            migrationLogger.LogInfoLineSeparator();
        }

        internal void LogSummaryOfItemsUpdated(string integrationServiceClassName, int? numberOfPagesFound)
        {
            migrationLogger.LogInfoWithLineSeparator($"Completed {integrationServiceClassName} migration. Migration statistics are detailed below:");

            if (numberOfPagesFound != null)
            {
                migrationLogger.LogInfo($"Number of Sitecore 8 pages retrieved: {numberOfPagesFound}");
            }

            foreach (IItemMigration itemMigrationClass in _migrations)
            {
                LogItemsUpdatedForCurrentMigration(itemMigrationClass, integrationServiceClassName);
            }
        }

        internal void LogItemsUpdatedForCurrentMigration(IItemMigration itemMigrationClass, string integrationServiceClassName)
        {
            string typeName = itemMigrationClass.GetType().Name;

            migrationLogger.LogInfoWithLineSeparator($"Migration statistics for {typeName} ({integrationServiceClassName}):");
            migrationLogger.LogInfo($"ItemsFoundInSitecore8: {migrationUpdateCounter[typeName].ItemsFoundInSitecore8} | ItemsMigrated: {migrationUpdateCounter[typeName].ItemsMigrated}  | ItemsSkipped: {migrationUpdateCounter[typeName].ItemsSkipped} | ItemsFailedToInsert: {migrationUpdateCounter[typeName].ItemsFailedToInsert}");
            if (itemMigrationClass.HasHierarchicalItemStructure)
            {
                migrationLogger.LogInfo($"ChildItemsFoundInSitecore8: {migrationUpdateCounter[typeName].ChildItemsFoundInSitecore8} | ChildItemsMigrated: {migrationUpdateCounter[typeName].ChildItemsMigrated} | ChildItemsSkipped: { migrationUpdateCounter[typeName].ChildItemsSkipped} | ChildItemsFailedToInsert: { migrationUpdateCounter[typeName].ChildItemsFailedToInsert}");
            }
            migrationLogger.LogInfoLineSeparator();
        }

         /// <summary>
        /// Retrieves sxaService from IEnumerable<ISxaService> _sxaServices. Throws exception if not found 
        /// </summary>
        /// <param name="sxaServiceType"></param>
        /// <returns></returns>
        internal IItemMigration GetSxaMigration(Type sxaMigrationType)
        {
            IItemMigration sxaMigration = _migrations.FirstOrDefault(i => i.GetType() == sxaMigrationType);

            if (sxaMigrationType == null)
                throw new MissingMemberException($"Unable to retrieve {sxaMigrationType.Name} from migrations");

            return sxaMigration;
        }

        /// <summary>
        /// Ensure we have all the required DI classes, or we can't continue with the migration!
        /// </summary>
        internal void ThrowExceptionIfArgumentsAreMissing()
        {
            if (_migrations == null)
            {
                throw new ArgumentNullException("_migrations", "Migrations classes have not been initialised. Unable to carry out migration.");
            }
            if (_sitecore8Client == null)
            {
                throw new ArgumentNullException("_sitecore8Client", "Sitecore 8 Client has not been initialised. Unable to carry out migration.");
            }
            if (_sitecore9Client == null)
            {
                throw new ArgumentNullException("_sitecore9Client", "Sitecore 9 Client has not been initialised. Unable to carry out migration.");
            }
            if (_sitecore8Repository == null)
            {
                throw new ArgumentNullException("_sitecore8Repository", "Sitecore8Repository is null. Unable to carry out migration.");
            }
            if (string.IsNullOrEmpty(_sitecore9Website.RootPath))
            {
                throw new ArgumentNullException("_sitecore9Website.RootPath", "_sitecore9Website.RootPath is null. Unable to carry out migration.");
            }
            if (string.IsNullOrEmpty(_sitecore8Website.RootPath))
            {
                throw new ArgumentNullException("_sitecore8Website.RootPath", "_sitecore8Website.RootPath is null. Unable to carry out migration.");
            }
            if (_applicationSettings == null)
            {
                throw new ArgumentNullException("_applicationSettings", "_applicationSettings is null. Unable to carry out migration.");
            }
        }
    }
}
