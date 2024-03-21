using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using StudyGroupSxaMigration.AppSettings;

namespace StudyGroupSxaMigration.Logging
{
    /// <summary>
    /// All logging in the migration tool should be carried out from this class, to ensure consistency in the log files
    /// (with the exception of Program.cs as the DI isn't all set up when that code starts)
    /// </summary>
    public class MigrationLogger
    {
        private readonly ILogger _logger;
        private readonly ApplicationSettings _applicationSettings;
        public enum SitecoreInstance { Sitecore8, Sitecore9};
        private const string _logSeparator = "--------------------------------------------------------------------------------------------------------------------";
        private readonly string dryRunPrefix;

        public MigrationLogger(ApplicationSettings applicationSettings, ILogger logger)
        {
            _applicationSettings = applicationSettings;
            _logger = logger;

            dryRunPrefix  = (applicationSettings.DryRunMode ? "DRY RUN MODE |" : String.Empty);
        }

        public void LogDebugWithLineSeparator(string info)
        {
            LogDebug(_logSeparator);
            LogDebug(info);
            LogDebug(_logSeparator);
        }

        public void LogDebug(string info)
        {
            info = dryRunPrefix + info;
            _logger.LogDebug(info);
            if (_applicationSettings.ConsoleSettings.WriteDebugInfoToConsole)
                Console.WriteLine($"DEBUG| {info}\r\n");
        }

        public void LogTrace(string info)
        {
            info = dryRunPrefix + info;
            _logger.LogTrace(info);
            if (_applicationSettings.ConsoleSettings.WriteTraceInfoToConsole)
                Console.WriteLine($"TRACE| {info}\r\n");
        }

        public void LogInfoWithLineSeparator(string info)
        {
            LogInfo(_logSeparator);
            LogInfo(info);
            LogInfo(_logSeparator);
        }

        public void LogInfoWithUnderline(string info)
        {
            LogInfo(info);
            LogInfo(_logSeparator);
        }

        public void LogInfoLineSeparator()
        {
            LogInfo(_logSeparator);
        }

        public void LogInfo(string info)
        {
            info = dryRunPrefix + info;
            _logger.LogInformation(info);
            Console.WriteLine($"{info}\r\n");
        }

        public void LogWarningLineSeparator()
        {
            _logger.LogWarning(_logSeparator);
        }

        public void LogWarning(string info)
        {
            info = dryRunPrefix + info;
            _logger.LogWarning(info);
            Console.WriteLine($"WARN|{info}\r\n");
        }

        public void LogError(string errorDetail, Exception ex)
        {
            errorDetail = dryRunPrefix + errorDetail;
            _logger.LogError(ex, errorDetail);
            Console.WriteLine($"{errorDetail}\r\n");
            Console.WriteLine($"{ex}\r\n");
        }

        public void LogError(string errorDetail)
        {
            errorDetail = dryRunPrefix + errorDetail;
            _logger.LogError(errorDetail);
            Console.WriteLine($"ERROR|{errorDetail}\r\n");
        }

        public void LogFailedInsert(
                 string itemPath,
                 string objectType,
                 string objectAsJson,
                HttpRequestMessage request,
                HttpResponseMessage response)
        {
            string errorMessage = $"{dryRunPrefix}|FAILED INSERT|Unable to insert item. itemPath:{itemPath}|RequestUri:{request.RequestUri}|StatusCode:{response.StatusCode}|ObjectType: {objectType}| Failure reason: {response.ReasonPhrase}| objectAsJson: {objectAsJson}";
            _logger.LogError(errorMessage);
            Console.WriteLine($"{errorMessage}");
        }

        public void LogFailedInsert(
                Type sitecoreItemType,
                string itemPath,
                string itemName,
                Exception exception)
        {
            string errorMessage = $"{dryRunPrefix}|UNABLE TO CREATE ITEM|Unable to insert item. \r\n itemPath:{itemPath}|itemName:{itemName}|itemType:{sitecoreItemType?.ToString()}|\r\nexception: {exception.Message}";
            _logger.LogError(errorMessage);
            Console.WriteLine($"{errorMessage}\r\n");
        }

        public void LogFailedUpdate(
             Type sitecoreItemType,
             string itemPath,
             string itemName,
             Exception exception)
        {
            string errorMessage = $"{dryRunPrefix}|UNABLE TO UPDATE ITEM|Unable to update item. \r\n itemPath:{itemPath}|itemName:{itemName}|itemType:{sitecoreItemType?.ToString()}|\r\nexception: {exception.Message}";
            _logger.LogError(errorMessage);
            Console.WriteLine($"{errorMessage}\r\n");
        }

        /// <summary>
        /// logs details of an item that could not be retrieved. For Sitecore 8, log as an error. For sitecore 9, just log as a trace-level log entry
        /// </summary>
        /// <param name="sitecoreInstance"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="itemPath"></param>
        /// <param name="itemId"></param>
        /// <param name="templateId"></param>
        public void LogFailedItemRetrieval(SitecoreInstance sitecoreInstance,
                                            string requestUri,
                                            string responseStatusCode,
                                            string responseReasonPhrase,
                                            string itemPath,
                                            string itemId,
                                            string templateId,
                                            Exception exception = null)
        {
            string exceptionMessage = (exception == null) ? string.Empty : exception.Message;
            string errorMessage = $"{dryRunPrefix}|FAILED ITEM RETRIEVAL|Sitecore Instance:{sitecoreInstance.ToString() }|itemPath: {itemPath}|itemId: {itemId}|templateId: {templateId}|RequestUri:{requestUri}|StatusCode:{responseStatusCode}|Failure reason: {responseReasonPhrase}|Exception: {exceptionMessage}";
            if (sitecoreInstance == SitecoreInstance.Sitecore8)
            {
                _logger.LogError(errorMessage);
                if (_applicationSettings.ConsoleSettings.WriteSitecore8ItemRetrievalFailureToConsole)
                {
                    Console.WriteLine($"{errorMessage}\r\n");
                }
            }
            else
            {
                _logger.LogTrace(errorMessage);
                if (_applicationSettings.ConsoleSettings.WriteSitecore9ItemRetrievalFailureToConsole)
                {
                    Console.WriteLine($"{errorMessage}\r\n");
                }
            }
        }

        public void LogItemAlreadyExists(string info)
        {
            _logger.LogInformation(info, null);

            if (_applicationSettings.ConsoleSettings.WriteItemAlreadyExistsWarningsToConsole)
            {
                Console.WriteLine($"{dryRunPrefix}|ITEM EXISTS| {info}\r\n");
            }
        }
        public void LogItemAlreadyExistsWarning(string info)
        {
            _logger.LogWarning(info, null);

            if (_applicationSettings.ConsoleSettings.WriteItemAlreadyExistsWarningsToConsole)
            {
                Console.WriteLine($"{dryRunPrefix}|WARN|ITEM EXISTS| {info}\r\n");
            }
        }
    }
}
