using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore8Constants;
using StudyGroupSxaMigration.IntegrationService.Migration;
using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.IntegrationService.ItemMigration;
using StudyGroupSxaMigration.SitecoreConstants;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.AppSettings;
using System.Linq;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;

namespace StudyGroupSxaMigration.IntegrationService.IntegrationServices
{
    public class SharedItemIntegrationService : IntegrationServiceBase, IIntegrationService
    {
        /// <summary>
        /// Initialise required objects (carried out in base class)
        /// </summary>
        /// <param name="sitecore8Client"></param>
        /// <param name="sitecore9Client"></param>
        /// <param name="sitecore8Repository"></param>
        /// <param name="logger"></param>
        /// <param name="migrations"></param>
        public SharedItemIntegrationService(
                                ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ISitecore8Repository sitecore8Repository,
                                ILogger<SharedItemIntegrationService> logger,
                                IEnumerable<IItemMigration> migrations,
                                ISitecore8WebsiteConfiguration sitecore8Website,
                                Sitecore9Website sitecore9Website,
                                ApplicationSettings applicationSettings) :
                    base(sitecore8Client,
                        sitecore9Client,
                        sitecore8Repository,
                        logger,
                        migrations,
                        sitecore8Website,
                        sitecore9Website,
                        applicationSettings)
        {
        }

        /// <summary>
        /// For each migration class defined in _migrations list, 
        /// go through each folder in sitecore 8 shared items and push into the equivalent folder in sitecore 9 data
        /// </summary>
        /// <param name="sitecore8Website"></param>
        /// <param name="sitecore9Website"></param>
        /// <returns></returns>
        public async Task Run()
        {
            string currentItemMigrationClass = string.Empty;

            try
            {
                ThrowExceptionIfArgumentsAreMissing();

                InitialiseAllMigrationCounters();

                foreach (IItemMigration itemMigrationClass in _migrations)
                {
                    currentItemMigrationClass = itemMigrationClass.GetType()?.Name;
                    if (ExcludeThisMigration(currentItemMigrationClass))
                    {
                        migrationLogger.LogDebug($"{currentItemMigrationClass} is excluded from migration of shared data items!");
                        continue;
                    }
                    migrationLogger.LogDebug( $"Loading migration class: {currentItemMigrationClass}");

                    ItemUpdateCounter updateCounter = await itemMigrationClass.MigrateSharedItems();
                    if (updateCounter.ItemsFoundInSitecore8 > 0)
                    {
                        migrationUpdateCounter[currentItemMigrationClass].AppendLatestUpdates(updateCounter);
                    }
                    LogItemsUpdatedForCurrentMigration(itemMigrationClass, this.GetType()?.Name);
                }

                currentItemMigrationClass = "MigrateMiscellaneousSharedItems";

                await MigrateMiscellaneousSharedItems();

                LogSummaryOfItemsUpdated(this.GetType().Name, null);

                migrationLogger.LogInfo("Completed migration of shared data items!");
            }
            catch(Exception ex)
            {
                migrationLogger.LogError($"Unexpected error occurred during migration of shared items! currentItemMigrationClass:'{currentItemMigrationClass}'", ex);
            }
        }

        /// <summary>
        /// TODO Call migrate content box & migrate widget classes for the non-standard locations, which are stored in the sitecore8Configuration settings
        /// </summary>
        /// <returns></returns>
        private async Task MigrateMiscellaneousSharedItems()
        {
            if (_sitecore8Website.MiscellaneousSharedItemsFolders?.Count > 0)
            {
                var sitecore9DataFolderPath = $"{_sitecore9Website.RootPath}/{_sitecore9Website.DataFolderName}";

                foreach (MiscellaneousSharedItemsFolders miscellaneousSharedItemsFolder in _sitecore8Website.MiscellaneousSharedItemsFolders)
                {
                    if (miscellaneousSharedItemsFolder.Sitecore8TemplateId == _sitecore8Website.WebsiteTemplateIds.ContentBox)
                    {
                        ContentBoxMigration contentBoxMigration = (ContentBoxMigration)_migrations.FirstOrDefault(i => i.GetType() == typeof(ContentBoxMigration));
                        if (contentBoxMigration != null)
                        {
                            contentBoxMigration.ResetItemUpdateCounter();
                            List<ContentBox> sitecore8ContentBoxes = await _sitecore8Repository.GetItemChildrenByPath<ContentBox>(miscellaneousSharedItemsFolder.SharedFolderPath, miscellaneousSharedItemsFolder.Sitecore8TemplateId);
                            ItemUpdateCounter updateCounter = await contentBoxMigration.InsertContentBoxes(sitecore8ContentBoxes, $"{sitecore9DataFolderPath}/{miscellaneousSharedItemsFolder.Sitecore9SharedFolderName}");
                        }
                    }
                    else if (_sitecore8Website.WebsiteTemplateIds.Widgets.Contains(miscellaneousSharedItemsFolder.Sitecore8TemplateId))
                    {
                        WidgetMigration widgetMigration = (WidgetMigration)_migrations.FirstOrDefault(i => i.GetType() == typeof(WidgetMigration));
                        if (widgetMigration != null)
                        {
                            widgetMigration.ResetItemUpdateCounter();
                            List<Widget> sitecore8Widgets = await _sitecore8Repository.GetItemChildrenByPath<Widget>(miscellaneousSharedItemsFolder.SharedFolderPath, miscellaneousSharedItemsFolder.Sitecore8TemplateId);
                            ItemUpdateCounter updateCounter =  await widgetMigration.InsertWidgets(sitecore8Widgets, $"{sitecore9DataFolderPath}/{miscellaneousSharedItemsFolder.Sitecore9SharedFolderName}");
                        }
                    }
                }
            }
        }
    }
}
