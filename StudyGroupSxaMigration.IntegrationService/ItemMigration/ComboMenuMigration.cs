using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.IntegrationService.Migration;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreConstants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using StudyGroupSxaMigration.Logging;
using StudyGroupSxaMigration.Logging.Exceptions;
using Microsoft.Extensions.Configuration;
using StudyGroupSxaMigration.ItemServices.Services;
using StudyGroupSxaMigration.AppSettings;

namespace StudyGroupSxaMigration.IntegrationService.ItemMigration
{
    public class ComboMenuMigration : MigrationBase, IItemMigration
    {
        public ComboMenuMigration(
                                ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ISitecore8Repository sitecore8Repository,
                                ILogger<ComboMenuMigration> logger,
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
        /// Do nothing; ComboMenuItem only ever exists in Shared Item folder
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            return new ItemUpdateCounter();
        }

        /// <summary>
        /// Retrieve Combo Menu Items under shared items folder and insert into sitecore 9
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.SharedComboMenus))
            {
                migrationLogger.LogDebug($"Migrating Combo Menu Items");

                List<ComboMenuItem> sitecore8ComboMenuItems = await _sitecore8Repository.GetItemChildrenByPath<ComboMenuItem>(_sitecore8Website.SharedItemFolderPaths.SharedComboMenus, _sitecore8Website.WebsiteTemplateIds.ComboMenuItem);

                if (sitecore8ComboMenuItems?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8ComboMenuItems.Count} Combo Menu Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.SharedComboMenus}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.ComboMenuItems}");
                    await InsertComboMenuItems(sitecore8ComboMenuItems, _sitecore9Website.SharedItemPaths.ComboMenuItems);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertComboMenuItems(List<ComboMenuItem> sitecore8ComboMenuItems, string insertionPath)
        {
            if (sitecore8ComboMenuItems?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8ComboMenuItems.Count;

                SxaComboMenuService sxaComboMenuItemService = (SxaComboMenuService)GetSxaService(typeof(SxaComboMenuService));

                foreach (ComboMenuItem comboMenuItem in sitecore8ComboMenuItems)
                {
                    try
                    {
                        if (await sxaComboMenuItemService.Create(comboMenuItem, _sitecore9Website.RootPath, _sitecore8Website.RootPath, insertionPath))
                        {
                            itemUpdateCounter.ItemsMigrated++;
                        }
                        else
                        {
                            itemUpdateCounter.ItemsSkipped++;
                        }
                    }
                    catch (FailedInsertException ex)
                    {
                        itemUpdateCounter.ItemsFailedToInsert++;
                        migrationLogger.LogFailedInsert(typeof(ComboMenuItem), insertionPath, comboMenuItem?.ItemName, ex);
                    }
                    catch (LinkException ex)
                    {
                        itemUpdateCounter.ItemsFailedToInsert++;
                        migrationLogger.LogFailedInsert(typeof(ComboMenuItem), insertionPath, comboMenuItem?.ItemName, ex);
                    }
                }
            }
        }
    }
}
