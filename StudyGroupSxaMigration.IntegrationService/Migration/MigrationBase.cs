using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.Services;
using StudyGroupSxaMigration.Logging;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.IntegrationService.Migration
{
    public class MigrationBase
    {
        internal ISitecore8WebsiteConfiguration _sitecore8Website;
        internal ISitecore9Website _sitecore9Website;
        internal ISitecore8Repository _sitecore8Repository;
        internal ISitecore8Client _sitecore8Client;
        internal ISitecore9Client _sitecore9Client;
        internal ILogger<MigrationBase> _logger;
        internal IEnumerable<ISxaService> _sxaServices;
        internal MigrationLogger migrationLogger;
        internal ApplicationSettings _applicationSettings;
        internal ItemUpdateCounter itemUpdateCounter;

        /// <summary>
        /// Base class for all migration classes.
        /// Initialise objects used for migration classes(logger, sitecore API clients, repsitory)
        /// </summary>
        /// <param name="sitecore8Client"></param>
        /// <param name="sitecore9Client"></param>
        /// <param name="sitecore8Repository"></param>
        /// <param name="logger"></param>
        /// <param name="sxaServices"></param>
        /// <param name="sitecore8Website"></param>
        /// <param name="sitecore9Website"></param>
        /// <param name="configuration"></param>
        public MigrationBase(

            ISitecore8Client sitecore8Client,
            ISitecore9Client sitecore9Client,
            ISitecore8Repository sitecore8Repository,
            ILogger<MigrationBase> logger,
            IEnumerable<ISxaService> sxaServices,
            ISitecore8WebsiteConfiguration sitecore8Website,
            ISitecore9Website sitecore9Website,
            ApplicationSettings applicationSettings
           )
        {
            _sitecore8Client = sitecore8Client;
            _sitecore9Client = sitecore9Client;
            _sitecore8Repository = sitecore8Repository;
            _logger = logger;
            _sxaServices = sxaServices;
            _sitecore8Website = sitecore8Website;
            _sitecore9Website = sitecore9Website;
            _applicationSettings = applicationSettings;
            migrationLogger = new MigrationLogger(applicationSettings, logger);
            itemUpdateCounter = new ItemUpdateCounter();
        }

        /// <summary>
        /// This is only called when the Insert method is called directly for miscellaneous shared items (content boxes and widgets)
        /// Just to be sure it won't return update stats from the previous call!
        /// </summary>
        public void ResetItemUpdateCounter()
        {
            itemUpdateCounter = new ItemUpdateCounter();
        }

        /// <summary>
        /// Returns the full path to the Sitecore 8 page items sub folder for a specific item type e.g. "/sitecore/content/ISC/Waikato V2/Home/Page Items/Button Groups"
        /// </summary>
        /// <param name="item"></param>
        /// <param name="folderNameForThisDataItemType"></param>
        /// <returns></returns>
        protected string GetPageItemsSubFolderPathForItemType(SitecoreItem item, string folderNameForThisDataItemType)
        {
            return $"{item.ItemPath}/{Sitecore8Paths.PageItemsFolderName}/{folderNameForThisDataItemType}";
        }

        /// <summary>
        /// Returns the full path to the Sitecore 8 page items sub folder for a specific item type e.g. "/sitecore/content/ISC/Waikato V2/Home/Page Items/Button Groups"
        /// </summary>
        /// <param name="item"></param>
        /// <param name="folderNameForThisDataItemType"></param>
        /// <returns></returns>
        protected string GetPageItemsSubFolder(SitecoreItem item)
        {
            return $"{item.ItemPath}/{Sitecore8Paths.PageItemsFolderName}";
        }

        /// <summary>
        /// For page data items, get the equivent folder of the Sitecore 9
        /// </summary>
        /// <param name="dataSourceFolderPath"></param>
        /// <param name="pageItemsSubFolderForThisTemplateType"></param>
        /// <returns></returns>
        protected string GetSitecore9TargetPath(string dataSourceFolderPath, string pageItemsSubFolderForThisTemplateType)
        {
            string sitecore9TargetPathRelativeToHome = String.Empty;

            string sitecore8PathRelativeToHome = dataSourceFolderPath.Replace($"{_sitecore8Website.HomePagePath}", "");
            //string sitecore8PageItemsAndTemplateSpecificFolder = $"{Sitecore8Paths.PageItemsFolderName}/";                                             // e.g. "Page Items/"
            string sitecore8PageItemsAndTemplateSpecificFolder = $"{Sitecore8Paths.PageItemsFolderName}/{pageItemsSubFolderForThisTemplateType}";        // e.g. "Page Items/Content Boxes"

            int postionOfPageItemsSubFolderForThisTemplateType = sitecore8PathRelativeToHome.LastIndexOf(sitecore8PageItemsAndTemplateSpecificFolder);
            if (sitecore8PathRelativeToHome.Length > postionOfPageItemsSubFolderForThisTemplateType)
            {
                sitecore9TargetPathRelativeToHome = sitecore8PathRelativeToHome.Substring(0, postionOfPageItemsSubFolderForThisTemplateType - 1);
            }

            if (sitecore9TargetPathRelativeToHome?.Length == 0)
            {
                // this must be the home page
                return $"{_sitecore9Website.HomePagePath}/{_sitecore9Website.DataFolderName}";
            }

            return $"{_sitecore9Website.HomePagePath}{sitecore9TargetPathRelativeToHome}/{_sitecore9Website.DataFolderName}";
        }

        /// <summary>
        /// Retrieves sxaService from IEnumerable<ISxaService> _sxaServices. Throws exception if not found 
        /// </summary>
        /// <param name="sxaServiceType"></param>
        /// <returns></returns>
        internal ISxaService GetSxaService(Type sxaServiceType)
        {
            ISxaService sxaService = _sxaServices.FirstOrDefault(i => i.GetType() == sxaServiceType);

            if (sxaService == null)
                throw new MissingMemberException($"Unable to retrieve {sxaServiceType.Name} from sxaServices");

            return sxaService;
        }

        /// <summary>
        ///  Decides whether we should check other folders under "Page Data" items for the current page type
        ///  (Checks appsettings values 'CheckForInconsistentFolderNaming', 'DryRunMode' & 'CheckOtherFoldersIfDataItemsAlreadyFound')
        ///  The logic is as follows:
        ///   - If CheckForInconsistentFolderNaming is switched off, don't EVER check other folders
        ///   - If in dry run mode, ALWAYS check other folders, whether or not item is found in expected location
        ///   - If NOT in dry run mode, but items were NOT found in the expected location, DO check other folders
        /// </summary>
        /// <param name="itemsAreInExpectedLocation"></param>
        /// <returns></returns>
        protected bool DoCheckForAlternativeFolders(bool itemsAreInExpectedLocation)
        {
            if (!_applicationSettings.CheckForInconsistentFolderNaming)
            {
                return false;
            }

            return ((_applicationSettings.DryRunMode) || (itemsAreInExpectedLocation && _applicationSettings.CheckOtherFoldersIfDataItemsInExpectedLocation) || !itemsAreInExpectedLocation);
        }

        /// <summary>
        /// Checks for items in folders (but excludes the expected folder from the search)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageItem"></param>
        /// <param name="expectedFolderPath"></param>
        /// <param name="itemTemplateId"></param>
        /// <param name="itemDescription">Description of the widget type you are looking for e.g. "Gallery container" </param>
        /// <returns>list of items, actualFolderPath, actualFolderName</returns>
        public async Task<SitecoreItemList<T>> CheckForAlternativeFolders<T>(SitecoreItem pageItem,
                                                                            string expectedFolderPath,
                                                                            string expectedFolderName,
                                                                            string itemTemplateId,
                                                                            string itemDescription,
                                                                            bool itemsExistInExpectedLocation) where T : SitecoreItem, new()
        {
            return await CheckForAlternativeFolders<T>(pageItem,
                                                        expectedFolderPath,
                                                        expectedFolderName,
                                                        new List<string> { itemTemplateId },
                                                        itemDescription,
                                                        itemsExistInExpectedLocation);
        }

        /// <summary>
        /// Checks for items in Sitecore 8 Page Item sub folders (but excludes the expected folder from the search)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageItem"></param>
        /// <param name="expectedFolderPath"></param>
        /// <param name="expectedFolderName"></param>
        /// <param name="itemTemplateIds">list of template ids to match on (for widgets, you will have a set of templates, but for most other items, it will just be a single template)</param>
        /// <param name="itemDescription">Description of the widget type you are looking for e.g. "Gallery container"</param>
        /// <param name="itemsExistInExpectedLocation"></param>
        /// <returns></returns>
        public async Task<SitecoreItemList<T>> CheckForAlternativeFolders<T>(SitecoreItem pageItem,
                                                                            string expectedFolderPath,
                                                                            string expectedFolderName,
                                                                            List<string> itemTemplateIds,
                                                                            string itemDescription,
                                                                            bool itemsExistInExpectedLocation) where T : SitecoreItem, new()
        {
            SitecoreItemList<T> sitecoreItemList = null;
            List<string> locationsContainingCurrentItemType = new List<string>();
            List<T> items;

            var pageItemsFolder = GetPageItemsSubFolder(pageItem);

            migrationLogger.LogTrace($"Checking alternative folders for {itemDescription} under {pageItemsFolder}");

            var children = await _sitecore8Repository.GetItemChildrenByPath<SitecoreItem>(pageItemsFolder);

            foreach (SitecoreItem widgetsV2Folder in children)
            {
                if (widgetsV2Folder.ItemPath != expectedFolderPath && widgetsV2Folder.HasChildren)
                {
                    items = await _sitecore8Repository.GetChildrenById<T>(widgetsV2Folder.ItemID, itemTemplateIds);

                    if (items?.Count > 0)
                    {
                        sitecoreItemList = new SitecoreItemList<T>()
                        {
                            SitecoreItems = items,
                            FolderName = widgetsV2Folder.ItemName,
                            FolderPath = widgetsV2Folder.ItemPath
                        };

                        locationsContainingCurrentItemType.Add(sitecoreItemList.FolderName);
                    }
                }
            }

            if (itemsExistInExpectedLocation)
            {
                // include the "expected" folder, as this was excluded from the above search because we already know that it contains items
                locationsContainingCurrentItemType.Add(expectedFolderName);
            }

            if (locationsContainingCurrentItemType.Count > 1)
            {
                string allLocations = String.Join(",", locationsContainingCurrentItemType);
                string warningMessage = $" {itemDescription} items will not all be migrated as they have been placed in multiple folders under {pageItemsFolder}: {allLocations}.";
                migrationLogger.LogError(warningMessage);
            }
            else if (locationsContainingCurrentItemType.Count == 1 && !itemsExistInExpectedLocation)
            {
                // if 1 matching folder found and it's NOT the expected location, log a warning! (if it IS the expected location, this is not an issue!)
                string warningMessage = $"Expected to find {itemDescription} items in folder: {expectedFolderPath}, but they will actually be migrated from '{sitecoreItemList.FolderPath}'";
                if (_applicationSettings.DryRunMode)
                {
                    warningMessage += " CheckForInconsistentFolderNaming appsetting must be set to 'true' for the real migration if the folder is not renamed, or these items will not be migrated";
                }
                migrationLogger.LogWarning(warningMessage);
            }

            return sitecoreItemList != null ? sitecoreItemList : new SitecoreItemList<T>();
        }

        /// <summary>
        /// Indication of whether a migration item has a parent-child relationship or just a simple list of non-hierarchical items.
        /// This is used by the method which logs the update stats, so it doesn't log child stats for non-hierarchical structures
        /// </summary>
        public bool HasHierarchicalItemStructure { get; set; }
    }
}