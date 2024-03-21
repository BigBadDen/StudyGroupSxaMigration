using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreCommon;
using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.Logging;
using static StudyGroupSxaMigration.Logging.MigrationLogger;
using StudyGroupSxaMigration.AppSettings;

namespace StudyGroupSxaMigration.Sitecore8
{
    public class Sitecore8Client : ISitecore8Client
    {
        private readonly HttpClient _client;
        private readonly ApplicationSettings _applicationSettings;
        private readonly MigrationLogger migrationLogger;
        private readonly string languageQueryString = "language=en";
        private readonly JsonSerializer _jsonSerializer;

        public Sitecore8Client(HttpClient httpClient, ApplicationSettings applicationSettings, ILogger<Sitecore8Client> logger, JsonSerializer jsonSerializer)
        {
            _client = httpClient;
            _applicationSettings = applicationSettings;
            migrationLogger = new MigrationLogger(_applicationSettings, logger);
            _jsonSerializer = jsonSerializer;
            migrationLogger.LogTrace($"Initializing httpClient for Sitecore 8. Base Address: '{_applicationSettings.WebsiteSettings.Sitecore8Uri}'");
        }

        public async Task<T> GetItem<T>(string itemId) where T : new()
        {
            migrationLogger.LogTrace($"Getting item by id from Sitecore 8. Id:'{itemId}'");

            string apiUrl = $"{_applicationSettings.WebsiteSettings.Sitecore8Uri}item/{itemId}?{languageQueryString}";

            T result = default(T);

            var response = await _client.GetAsync(apiUrl, HttpCompletionOption.ResponseHeadersRead);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var streamReader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        result = _jsonSerializer
                            .Deserialize<T>(jsonReader);
                    }
                }
                catch(Exception ex)
                {
                    migrationLogger.LogFailedItemRetrieval(SitecoreInstance.Sitecore8, apiUrl, response?.StatusCode.ToString(), response?.ReasonPhrase,
                                   itemPath: string.Empty, itemId: itemId, templateId: string.Empty, exception: ex);
                    throw;
                }
            }
            else
            {
                migrationLogger.LogFailedItemRetrieval(SitecoreInstance.Sitecore8, apiUrl, response?.StatusCode.ToString(), response?.ReasonPhrase,
                                   itemPath: string.Empty, itemId: itemId, templateId: string.Empty);
            }

            return result;
        }

        public async Task<T> GetItemByPath<T>(string itemPath, string templateId, bool? logErrorIfNotFound) where T : SitecoreItem, new()
        {
            var sitecoreItem = await GetItemByPath<T>(itemPath, logErrorIfNotFound);
            if (sitecoreItem?.TemplateIdEquals(templateId) == true)
            {
                return sitecoreItem;
            }
            if (logErrorIfNotFound == true)
            {
                var errorMessage = $"Unable to retrieve item - path'{itemPath}'";
                if (sitecoreItem != null)
                {
                    errorMessage = $"{errorMessage}, template id: '{templateId}'";
                }

                migrationLogger.LogError(errorMessage);
            }
            return default(T);
        }

        public async Task<T> GetItemByPath<T>(string itemPath, bool? logErrorIfNotFound) where T : new()
        {
            migrationLogger.LogTrace($"Getting item by path from Sitecore 8. Path:'{itemPath}'");

            string apiUrl = $"{_applicationSettings.WebsiteSettings.Sitecore8Uri}item/?path={itemPath}&{languageQueryString}";

            T result = default(T);

            var response = await _client.GetAsync(apiUrl, HttpCompletionOption.ResponseHeadersRead);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var streamReader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        result = _jsonSerializer
                            .Deserialize<T>(jsonReader);
                    }
                }
                catch (Exception ex)
                {
                    migrationLogger.LogFailedItemRetrieval(SitecoreInstance.Sitecore8, apiUrl, response?.StatusCode.ToString(), response?.ReasonPhrase,
                                   itemPath: itemPath, itemId: string.Empty, templateId: string.Empty, exception: ex);
                    throw;
                }
            }
            else
            {
                if (logErrorIfNotFound ?? false)
                {
                    migrationLogger.LogFailedItemRetrieval(SitecoreInstance.Sitecore8, apiUrl, response?.StatusCode.ToString(), response?.ReasonPhrase,
                                      itemPath: itemPath, itemId: string.Empty, templateId: string.Empty);
                }
            }

            return result;
        }

        /// <summary>
        /// Retrieve item by id and template. Is not currently used, but probably should be!!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemId"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public async Task<T> GetItem<T>(string itemId, string templateId) where T : SitecoreItem, new()
        {
            migrationLogger.LogTrace($"Getting item by id: {itemId} and template id: '{templateId}'");

            string apiUrl = $"{_applicationSettings.WebsiteSettings.Sitecore8Uri}item/{itemId}?{languageQueryString}&templateId={templateId}";

            T result = default(T);

            var response = await _client.GetAsync(apiUrl, HttpCompletionOption.ResponseHeadersRead);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var streamReader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        result = _jsonSerializer
                            .Deserialize<T>(jsonReader);
                    }
                }
                catch (Exception ex)
                {
                    migrationLogger.LogFailedItemRetrieval(SitecoreInstance.Sitecore8, apiUrl, response?.StatusCode.ToString(), response?.ReasonPhrase,
                                   itemPath: string.Empty, itemId: itemId, templateId: templateId, exception: ex);
                    throw;
                }
            }
            else
            {
                migrationLogger.LogFailedItemRetrieval(SitecoreInstance.Sitecore8, apiUrl, response?.StatusCode.ToString(), response?.ReasonPhrase,
                                    itemPath: string.Empty, itemId: itemId, templateId: templateId);
            }

            return result;
        }

        public async Task<List<T>> GetItemChildren<T>(string itemId, string templateId) where T : SitecoreItem, new()
        {
            List<T> itemList = new List<T>();

            migrationLogger.LogTrace($"Getting Children of item id: '{itemId}' with template id: '{templateId}'");

            string apiUrl = $"{_applicationSettings.WebsiteSettings.Sitecore8Uri}item/{itemId}/children?{languageQueryString}";

            var response = await _client.GetAsync(apiUrl, HttpCompletionOption.ResponseHeadersRead);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var streamReader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        itemList = _jsonSerializer
                            .Deserialize<List<T>>(jsonReader);
                    }
                    return itemList?.FindAll(i => i.TemplateIdEquals(templateId));
                }
                catch (Exception ex)
                {
                    migrationLogger.LogFailedItemRetrieval(SitecoreInstance.Sitecore8, apiUrl, response?.StatusCode.ToString(), response?.ReasonPhrase,
                                   itemPath: string.Empty, itemId: itemId, templateId: templateId, exception: ex);
                    throw;
                }
            }
            else
            {
                migrationLogger.LogTrace($"No child items found under item id: '{itemId}'");
            }

            return itemList;
        }

        public async Task<List<T>> GetItemChildren<T>(string itemId, List<string>templateIds) where T : SitecoreItem, new()
        {
            List<T> itemList = new List<T>();

            string templateIdsJoined = String.Join(",",templateIds);
            migrationLogger.LogTrace($"Getting Children of item id: '{itemId}' with template ids : '{templateIdsJoined}'");

            string apiUrl = $"{_applicationSettings.WebsiteSettings.Sitecore8Uri}item/{itemId}/children?{languageQueryString}";

            var response = await _client.GetAsync(apiUrl, HttpCompletionOption.ResponseHeadersRead);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var streamReader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        itemList = _jsonSerializer
                            .Deserialize<List<T>>(jsonReader);
                    }

                    return itemList?.FindAll(i => i.TemplateIdMatches(templateIds));
                }
                catch (Exception ex)
                {
                    migrationLogger.LogFailedItemRetrieval(SitecoreInstance.Sitecore8, apiUrl, response?.StatusCode.ToString(), response?.ReasonPhrase,
                                                           itemPath: string.Empty, 
                                                           itemId: itemId, 
                                                           templateId: templateIdsJoined, 
                                                           exception: ex);
                    throw;
                }
            }
            else
            {
                migrationLogger.LogTrace($"No child items found under item id: '{itemId}'");
            }

            return itemList;
        }

        public async Task<List<T>> GetItemChildren<T>(string itemId) where T : SitecoreItem, new()
        {
            List<T> itemList = new List<T>();

            migrationLogger.LogTrace($"Getting Children of item id: '{itemId}' without template id");

            string apiUrl = $"{_applicationSettings.WebsiteSettings.Sitecore8Uri}item/{itemId}/children?{languageQueryString}";

            var response = await _client.GetAsync(apiUrl, HttpCompletionOption.ResponseHeadersRead);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var streamReader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        itemList = _jsonSerializer
                            .Deserialize<List<T>>(jsonReader);
                    }
                }
                catch (Exception ex)
                {
                    migrationLogger.LogWarning($"Some items under '{itemId}' cannot be converted into the {typeof(T)} class");

                    migrationLogger.LogFailedItemRetrieval(SitecoreInstance.Sitecore8, apiUrl, response?.StatusCode.ToString(), response?.ReasonPhrase,
                                   itemPath: string.Empty, itemId: itemId, templateId: "empty", exception: ex);
                    throw;
                }
            }
            else
            {
                migrationLogger.LogTrace($"No child items found under item id: '{itemId}'");
            }

            return itemList;
        }

        /// <summary>
        /// Get all items from all levels by templateId. Accepts a second template id to allow for a hierarchy which includes additional items in between the item id and template id
        /// e.g. blog home > categories > category > blogItem
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemId"></param>
        /// <param name="templateId"></param>
        /// <param name="intermediateItemsInTreeTemplateId">Only child items from parent items based on this template</param>
        /// <param name="isIncludeParentItems">The result list will include items bases on intermediateItemsInTreeTemplateId or not</param>
        /// <returns></returns>
        public async Task<List<T>> GetAllChildrenRecursivelyById<T>(string itemId, string templateId, string intermediateItemsInTreeTemplateId = "", bool isIncludeParentItems = false) where T : SitecoreItem, new()
        {
            List<T> items = new List<T>();
            await GetChildrenItemsRecursively<T>(itemId, items, templateId, intermediateItemsInTreeTemplateId);

            if (isIncludeParentItems)
            {
                return items;
            }

            return items.FindAll(i => i.TemplateIdEquals(templateId));
        }

        /// <summary>
        /// Retrieve ALL items below itemId, matching EITHER templateId or parentTemplateId recursively.
        /// Example of use is for retrieving all WeBlog entries and categories, because the expected hierarchy is two layers of categories, then the blog entries reside below the second layer of category 
        /// e.g. blog home > categories > category > blogItem
        /// NB. Items retrieved are appended to the list object passed into this method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemId"></param>
        /// <param name="list"></param>
        /// <param name="templateId"></param>
        /// <param name="intermediateItemsInTreeTemplateId"></param>
        /// <returns></returns>
        private async Task GetChildrenItemsRecursively<T>(string itemId, List<T> list, string templateId, string intermediateItemsInTreeTemplateId = "") where T : SitecoreItem, new()
        {
            migrationLogger.LogTrace($"Getting Children of item id: '{itemId}'");

            string apiUrl = $"{_applicationSettings.WebsiteSettings.Sitecore8Uri}item/{itemId}/children?{languageQueryString}";

            var response = await _client.GetAsync(apiUrl, HttpCompletionOption.ResponseHeadersRead);

            var serialiser = new JsonSerializer();

            List<T> itemList = null;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var streamReader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        itemList = serialiser
                            .Deserialize<List<T>>(jsonReader);
                    }
                    if (!string.IsNullOrEmpty(intermediateItemsInTreeTemplateId))
                    {
                        itemList = itemList.FindAll(i => i.TemplateIdEquals(templateId) || i.TemplateIdEquals(intermediateItemsInTreeTemplateId));
                    }
                }
                catch (Exception ex)
                {
                    migrationLogger.LogFailedItemRetrieval(SitecoreInstance.Sitecore8, apiUrl, response?.StatusCode.ToString(), response?.ReasonPhrase,
                                   itemPath: string.Empty, itemId: itemId, templateId: templateId, exception: ex);
                    throw;
                }
            }
            else
            {
                migrationLogger.LogTrace($"No child items found under item id: '{itemId}'");
            }

            if (itemList?.Count > 0)
            {
                list.AddRange(itemList);
                foreach (var item in itemList)
                {
                    if (item.TemplateID != templateId)
                    {
                        await GetChildrenItemsRecursively<T>(item.ItemID, list, templateId, intermediateItemsInTreeTemplateId);
                    }
                }
            }
        }
    }
}