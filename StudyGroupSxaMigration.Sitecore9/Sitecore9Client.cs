using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.Logging.Exceptions;

namespace StudyGroupSxaMigration.Sitecore9
{
    public class Sitecore9Client : ISitecore9Client
    {
        private readonly HttpClient _client;
        private readonly ApplicationSettings _applicationSettings;
        private readonly MigrationLogger migrationLogger;
        private readonly string languageQueryString = "language=en";
        private readonly JsonSerializer _jsonSerializer;

        public Sitecore9Client(HttpClient httpClient, ILogger<Sitecore9Client> logger, ApplicationSettings applicationSettings, JsonSerializer jsonSerializer)
        {
            _client = httpClient;
            _applicationSettings = applicationSettings;
            migrationLogger = new MigrationLogger(applicationSettings, logger);
            _jsonSerializer = jsonSerializer;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            migrationLogger.LogTrace($"Initializing httpClient for Sitecore 9. Base Address: '{_applicationSettings.WebsiteSettings.Sitecore9Uri}'");
        }

        /// <summary>
        /// Update an item in Sitecore 9. Used for blog & news items and Content Page updates (i.e. metadata fields)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="genericSitecoreItem"></param>
        /// <param name="insertPath"></param>
        /// <returns></returns>
        public async Task<bool> UpdateItem<T>(T genericSitecoreItem, string insertPath) where T : ISitecoreItem
        {
            string typeOfSitecoreItemToCreate = genericSitecoreItem?.GetType()?.ToString();

            string itemName = genericSitecoreItem.ItemName;
            string objectAsJson = JsonConvert.SerializeObject(genericSitecoreItem);

            string apiUrl = $"{_applicationSettings.WebsiteSettings.Sitecore9Uri}item/{genericSitecoreItem.ItemID}?database=master&{languageQueryString}";

            if (!_applicationSettings.DryRunMode)
            {
                var request = new HttpRequestMessage(HttpMethod.Patch, apiUrl)
                {
                    Content = new StringContent(objectAsJson)
                };

                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _client.SendAsync(request);

                if (response?.StatusCode != System.Net.HttpStatusCode.NoContent)
                {
                    migrationLogger.LogFailedInsert(insertPath, typeOfSitecoreItemToCreate, objectAsJson, request, response);
                    throw new FailedUpdateException($"Failed to update {typeOfSitecoreItemToCreate} item, itemName:'{itemName}'. Status code: {response.ReasonPhrase}");
                }
                else
                {
                    migrationLogger.LogDebug($"{itemName} update successful");
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> CreateItem<T>(T genericSitecoreItem, string insertPath) where T : ISitecoreItem
        {
            return await CreateItem<T>(genericSitecoreItem, insertPath, true);
        }

        /// <summary>
        /// Creates an item in sitecore 9. If error occurs, throws exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="genericSitecoreItem"></param>
        /// <param name="insertPath"></param>
        /// <typeparam name="T"></typeparam>
        /// <param name="genericSitecoreItem"></param>
        /// <param name="insertPath"></param>
        /// <returns>If successful, returns true. If item already exists in target location, returns false </returns>
        public async Task<bool> CreateItem<T>(T genericSitecoreItem, string insertPath, bool warnIfAlreadyExists) where T : ISitecoreItem
        {
            string typeOfSitecoreItemToCreate = genericSitecoreItem?.GetType()?.ToString();

            string itemName = genericSitecoreItem.ItemName;
            string objectAsJson = JsonConvert.SerializeObject(genericSitecoreItem);
            string targetPathIncludingItemName = $"{insertPath}/{itemName}";

            var itemAlreadyInTargetLocation = await GetItemByPath<SitecoreItem>(targetPathIncludingItemName);
            if (itemAlreadyInTargetLocation != null)
            {
                string message = $"Item '{itemName}' will not be inserted because it already exists in the target location: '{insertPath}'";
                if (warnIfAlreadyExists)
                {
                    migrationLogger.LogItemAlreadyExistsWarning(message);
                }
                else
                {
                    migrationLogger.LogItemAlreadyExists(message);
                }
                return false;
            }

            if (!_applicationSettings.DryRunMode)
            {
                string apiUrl = $"{_applicationSettings.WebsiteSettings.Sitecore9Uri}item/{insertPath}?database=master&{languageQueryString}";

                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                {
                    Content = new StringContent(objectAsJson)
                };

                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _client.SendAsync(request);

                if (response?.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    migrationLogger.LogFailedInsert(insertPath, typeOfSitecoreItemToCreate, objectAsJson, request, response);
                    throw new FailedInsertException($"Failed to insert {typeOfSitecoreItemToCreate} item. Status code: {response.ReasonPhrase}");
                }
                else
                {
                    migrationLogger.LogDebug($"insert successful");
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Retrieve sitecore 9 item by path. Returns null if not found. Does not create a log entry if the item is not found, so should be logged by calling methods if necessary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemPath"></param>
        /// <returns></returns>
        public async Task<T> GetItemByPath<T>(string itemPath) where T : ISitecoreItem, new()
        {
            migrationLogger.LogTrace($"Getting Sitecore 9 item by path:'{itemPath}'");
            return await GetItem<T>($"?path={itemPath}&{languageQueryString}");
        }

        /// <summary>
        ///  Retrieve sitecore 9 item by ID. Returns null if not found. Does not create a log entry if the item is not found, so should be logged by calling methods if necessary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<T> GetItemById<T>(string itemId) where T : ISitecoreItem, new()
        {
            migrationLogger.LogTrace($"Getting  Sitecore 9 by item id: '{itemId}'");
            return await GetItem<T>($"{itemId}?{languageQueryString}");
        }

        private async Task<T> GetItem<T>(string getString) where T : ISitecoreItem, new()
        {
            T result;

            var response = await _client.GetAsync(_applicationSettings.WebsiteSettings.Sitecore9Uri + "item/" + getString, HttpCompletionOption.ResponseHeadersRead);

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

                    return result;
                }
                catch(Exception ex)
                {
                    throw new ApplicationException($"Unexpected error during retrieval of Sitecore 9 item |Exception: {ex.Message}| request uri: {getString}");
                }
            }
            else if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                throw new ApplicationException($"Unexpected error during retrieval of Sitecore 9 item |Status Code: {response.StatusCode}| reason: {response.ReasonPhrase} request uri: {getString}");
            }

            return default(T);
        }
    }
}
