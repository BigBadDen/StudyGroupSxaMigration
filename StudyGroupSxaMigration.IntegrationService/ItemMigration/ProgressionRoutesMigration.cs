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
    public class ProgressionRoutesMigration : MigrationBase, IItemMigration
    {
        public ProgressionRoutesMigration(
                            ISitecore8Client sitecore8Client,
                            ISitecore9Client sitecore9Client,
                            ISitecore8Repository sitecore8Repository,
                            ILogger<ProgressionRoutesMigration> logger,
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
        /// There is no Progression Route item under Page Data Item, this function do nothing and return null
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            await Task.CompletedTask;
            return new ItemUpdateCounter();
        }

        /// <summary>
        /// Retrieve Progression Route items from Sitecore 8, then insert into sitecore 9 as SgSxaProgressionRoutesTable
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.ProgressionRoutes))
            {
                migrationLogger.LogDebug($"Migrating Shared Progression Route Items");

                List<ProgressionRoutes> sitecore8ProgressionRoutes = await _sitecore8Repository.GetItemChildrenByPath<ProgressionRoutes>(_sitecore8Website.SharedItemFolderPaths.ProgressionRoutes, _sitecore8Website.WebsiteTemplateIds.ProgressionRoutes);

                if (sitecore8ProgressionRoutes?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8ProgressionRoutes.Count} Shared Progression Route Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.ProgressionRoutes}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.ProgressionRoutes}");
                    await InsertProgressionRoutes(sitecore8ProgressionRoutes, _sitecore9Website.SharedItemPaths.ProgressionRoutes);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertProgressionRoutes(List<ProgressionRoutes> sitecore8ProgressionRoutes, string insertionPath)
        {
            if (sitecore8ProgressionRoutes?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8ProgressionRoutes.Count;

                SxaProgressionRouteService sxaProgressionRouteService = (SxaProgressionRouteService)GetSxaService(typeof(SxaProgressionRouteService));

                foreach (ProgressionRoutes progressionRoutes in sitecore8ProgressionRoutes)
                {
                    try
                    {
                        if (await sxaProgressionRouteService.Create(progressionRoutes, insertionPath))
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
                        migrationLogger.LogFailedInsert(typeof(ProgressionRoutes), insertionPath, progressionRoutes?.ItemName, failedInsertException);
                    }
                    catch (LinkException ex)
                    {
                        itemUpdateCounter.ItemsFailedToInsert++;
                        migrationLogger.LogFailedInsert(typeof(ProgressionRoutes), insertionPath, progressionRoutes?.ItemName, ex);
                    }
                }
            }
        }
    }
}
