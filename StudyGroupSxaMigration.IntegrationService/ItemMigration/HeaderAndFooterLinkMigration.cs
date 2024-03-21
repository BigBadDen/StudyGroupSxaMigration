using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.IntegrationService.Migration;
using StudyGroupSxaMigration.ItemServices.Services;
using StudyGroupSxaMigration.Logging.Exceptions;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.IntegrationService.ItemMigration
{
    public class HeaderAndFooterLinkMigration : MigrationBase, IItemMigration
    {
        public HeaderAndFooterLinkMigration(
                            ISitecore8Client sitecore8Client,
                            ISitecore9Client sitecore9Client,
                            ISitecore8Repository sitecore8Repository,
                            ILogger<HeaderAndFooterLinkMigration> logger,
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
        /// Header/Footer links would never reside under a page!
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem)
        {
            return new ItemUpdateCounter();
        }

        /// <summary>
        /// Retrieve Header/Footer Link items from Sitecore 8, then insert into sitecore 9 as SxaLinkList and SxaLink items
        /// </summary>
        /// <returns></returns>
        public async Task<ItemUpdateCounter> MigrateSharedItems()
        {
            itemUpdateCounter = new ItemUpdateCounter();

            if (!String.IsNullOrEmpty(this._sitecore8Website.SharedItemFolderPaths.HeaderAndFooterLinks))
            {
                migrationLogger.LogDebug($"Migrating Shared Header/Footer Link Items");

                List<MenuLinks> sitecore8MenuLinks = await _sitecore8Repository.GetItemChildrenByPath<MenuLinks>(_sitecore8Website.SharedItemFolderPaths.HeaderAndFooterLinks, _sitecore8Website.WebsiteTemplateIds.MenuLinks);

                if (sitecore8MenuLinks?.Count > 0)
                {
                    migrationLogger.LogInfo($"Migrating {sitecore8MenuLinks.Count} Shared Header/Footer Link Items from folder: '{this._sitecore8Website.SharedItemFolderPaths.HeaderAndFooterLinks}' to sitcore 9 folder: '{_sitecore9Website.SharedItemPaths.LinkLists}");
                    await InsertMenuLinks(sitecore8MenuLinks, _sitecore9Website.SharedItemPaths.LinkLists);
                }
            }
            return itemUpdateCounter;
        }

        private async Task InsertMenuLinks(List<MenuLinks> sitecore8MenuLinks, string insertionPath)
        {
            if (sitecore8MenuLinks?.Count > 0)
            {
                itemUpdateCounter.ItemsFoundInSitecore8 += sitecore8MenuLinks.Count;

                SxaLinkService sxaLinkService = (SxaLinkService)GetSxaService(typeof(SxaLinkService));
                SxaLinkListService sxaLinkListService = (SxaLinkListService)GetSxaService(typeof(SxaLinkListService));

                foreach (MenuLinks menuLinks in sitecore8MenuLinks)
                {
                    try
                    {
                        if (await sxaLinkListService.Create(menuLinks, insertionPath))
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
                        migrationLogger.LogFailedInsert(typeof(MenuLinks), insertionPath, menuLinks?.ItemName, failedInsertException);
                    }

                    string menuLinkItemPath = insertionPath + $"/{menuLinks.ItemName}";

                    string[] linkItems = menuLinks.Links.Split('|');

                    if (linkItems?.Length > 0)
                    {
                        itemUpdateCounter.ChildItemsFoundInSitecore8 += linkItems.Length;
                        try
                        {
                            (int, int, int) successfulLinkInserts = await sxaLinkService.Create(linkItems, _sitecore9Website.RootPath, _sitecore8Website.RootPath, menuLinkItemPath);
                            itemUpdateCounter.ChildItemsMigrated += successfulLinkInserts.Item1;
                            itemUpdateCounter.ChildItemsSkipped += successfulLinkInserts.Item2;
                            itemUpdateCounter.ChildItemsFailedToInsert += successfulLinkInserts.Item3;
                        }
                        catch (FailedInsertException ex)
                        {
                            itemUpdateCounter.ChildItemsFailedToInsert++;
                            migrationLogger.LogFailedInsert(typeof(SxaLink), menuLinkItemPath, $"{menuLinks?.ItemName}'s child items", ex);
                        }
                        catch (LinkException ex)
                        {
                            itemUpdateCounter.ChildItemsFailedToInsert++;
                            migrationLogger.LogFailedInsert(typeof(SxaLink), menuLinkItemPath, $"{menuLinks?.ItemName}'s child items", ex);
                        }
                    }
                }
            }
        }
    }
}
