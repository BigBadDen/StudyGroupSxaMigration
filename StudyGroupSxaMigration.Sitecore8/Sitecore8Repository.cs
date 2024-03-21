using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8
{
    public class Sitecore8Repository : ISitecore8Repository
    {
        private readonly ISitecore8Client _sitecore8Client;
        private readonly ILogger<Sitecore8Repository> _logger;

        public Sitecore8Repository(ISitecore8Client sitecore8Client, ILogger<Sitecore8Repository> logger)
        {
            _sitecore8Client = sitecore8Client;
            _logger = logger;
        }

        public async Task<List<T>> GetItemChildrenByPath<T>(string itemPath, string templateId) where T : SitecoreItem, new()
        {
            try
            {
                SitecoreItem parentItem = await _sitecore8Client.GetItemByPath<SitecoreItem>(itemPath, false);

                if (parentItem != null && !String.IsNullOrEmpty(parentItem.ItemID))
                {
                    return await _sitecore8Client.GetItemChildren<T>(parentItem.ItemID, templateId);
                }
                return new List<T>();
            }
            catch (Exception)
            {
                _logger.LogError($"Unexpected error occurred during retrival of sitecore 8 child items  by id and template. Item path: '{itemPath}', template id: {templateId}");
                throw;
            }
        }

        public async Task<List<T>> GetItemChildrenByPath<T>(string itemPath, List<string> templateIds) where T : SitecoreItem, new()
        {
            try
            {
                if (templateIds?.Count >= 1)
                {
                    SitecoreItem parentItem = await _sitecore8Client.GetItemByPath<SitecoreItem>(itemPath, false);

                    if (parentItem != null && !String.IsNullOrEmpty(parentItem.ItemID))
                    {
                        return await _sitecore8Client.GetItemChildren<T>(parentItem.ItemID, templateIds);
                    }
                }
                return new List<T>();
            }
            catch (Exception)
            {
                string templateIdsJoined = String.Join(",", templateIds);
                _logger.LogError($"Unexpected error occurred during retrival of sitecore 8 child items  by id and templates. Item path: '{itemPath}', template ids: {templateIdsJoined}");
                throw;
            }
        }

        public async Task<List<T>> GetItemChildrenByPath<T>(string itemPath) where T : SitecoreItem, new()
        {
            try
            {
                SitecoreItem parentItem = await _sitecore8Client.GetItemByPath<SitecoreItem>(itemPath, false);

                if (parentItem != null && !String.IsNullOrEmpty(parentItem.ItemID))
                {
                    return await _sitecore8Client.GetItemChildren<T>(parentItem.ItemID);
                }
                return new List<T>();
            }
            catch (Exception)
            {
                _logger.LogError($"Unexpected error occurred during retrieval of sitecore 8 child items by id (without template id). Item path: '{itemPath}'");
                throw;
            }
        }

        public async Task<List<T>> GetChildrenById<T>(string itemId, List<string> templateIds) where T : SitecoreItem, new()
        {
            try
            {
                return await _sitecore8Client.GetItemChildren<T>(itemId, templateIds);
            }
            catch (Exception)
            {
                string templateIdsJoined = (templateIds?.Count >= 1 ? String.Join(",", templateIds) : String.Empty);
                _logger.LogError($"Unexpected error occurred during retrival of sitecore 8 child items by id and templates. itemId: '{itemId}', template ids: {templateIdsJoined}");
                throw;
            }
        }
        public async Task<List<T>> GetChildrenById<T>(string itemId, string templateId) where T : SitecoreItem, new()
        {
            try
            {
                return await _sitecore8Client.GetItemChildren<T>(itemId, templateId);
            }
            catch (Exception)
            {
                _logger.LogError($"Unexpected error occurred during retrival of sitecore 8 child items by id and template. itemId: '{itemId}', template id: {templateId}");
                throw;
            }
        }

        public async Task<T> GetItemById<T>(string itemId, string templateId) where T : SitecoreItem, new()
        {
            try
            {
                return await _sitecore8Client.GetItem<T>(itemId, templateId);
            }
            catch (Exception)
            {
                _logger.LogError($"Unexpected error occurred during retrival of sitecore 8 item by id and template. itemId: '{itemId}', template id: {templateId}");
                throw;
            }
        }

        public async Task<T> GetItemById<T>(string itemId) where T : new()
        {
            try
            {
                return await _sitecore8Client.GetItem<T>(itemId);
            }
            catch (Exception)
            {
                _logger.LogError($"Unexpected error occurred during retrival of sitecore 8 item by id. itemId: '{itemId}'");
                throw;
            }
        }

        public async Task<T> GetItemByPath<T>(string itemPath, bool? logErrorIfNotFound) where T : new()
        {
            try
            {
                return await _sitecore8Client.GetItemByPath<T>(itemPath, logErrorIfNotFound);
            }
            catch (Exception)
            {
                _logger.LogError($"Unexpected error occurred during retrival of sitecore 8 item by path. itemPath: '{itemPath}'");
                throw;
            }
        }

        public async Task<T> GetItemByPath<T>(string itemPath, string templateId, bool? logErrorIfNotFound) where T : SitecoreItem, new()
        {
            try
            {
                return await _sitecore8Client.GetItemByPath<T>(itemPath, templateId, logErrorIfNotFound);
            }
            catch (Exception)
            {
                _logger.LogError($"Unexpected error occurred during retrival of sitecore 8 item by path and template id. itemPath: '{itemPath}', template id: '{templateId}'");
                throw;
            }
        }

        /// <summary>
        /// Get all items inside by templateId
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemId"></param>
        /// <param name="templateId"></param>
        /// <param name="parentItemTemplateId">Only child items from parent items based on this template</param>
        /// <param name="isIncludeParentItems">The result list will include items bases on intermediateItemsInTreeTemplateId or not</param>
        /// <returns></returns>
        public async Task<List<T>> GetAllChildrenRecursivelyById<T>(string itemId, string templateId, string parentItemTemplateId = "", bool isIncludeParentItems = false) where T : SitecoreItem, new()
        {
            try
            {
                return await _sitecore8Client.GetAllChildrenRecursivelyById<T>(itemId, templateId, parentItemTemplateId, isIncludeParentItems);
            }
            catch (Exception)
            {
                _logger.LogError($"Unexpected error occurred during retrival of all sitecore 8 children by id and template. itemId: '{itemId}', template id: {templateId}");
                throw;
            }
        }

        /// <summary>
        /// Get all sub-items of direct children which match the given template id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemId"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        //public async Task<List<T>> GetAllGrandchildItemsByTemplateId<T>(string itemId, string templateId) where T : SitecoreItem, new()
        //{
        //    try
        //    {
        //        return await _sitecore8Client.GetAllGrandchildItemsByTemplateId<T>(itemId, templateId);
        //    }
        //    catch (Exception)
        //    {
        //        _logger.LogError($"Unexpected error occurred during retrival of all sitecore 8 grandchild items by id and template. itemId: '{itemId}', template id: {templateId}");
        //        throw;
        //    }
        //}
    }
}
