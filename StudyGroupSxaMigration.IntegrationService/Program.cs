using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using StudyGroupSxaMigration.IntegrationService.IntegrationServices;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.SitecoreConstants;
using StudyGroupSxaMigration.Sitecore9Constants;

namespace StudyGroupSxaMigration.IntegrationService.Services
{
    internal class Program
    {
        private static ILogger<Program> logger = null;
        private static ApplicationSettings applicationSettings;

        private const string _logSeparator = "--------------------------------------------------------------------------------------------------------------------";

        static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            var serviceCollection = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(serviceCollection);
            applicationSettings = startup.ApplicationSettings;

            var serviceProvider = serviceCollection.BuildServiceProvider();

            try
            {
                logger = serviceProvider.GetService<ILogger<Program>>();

                if (applicationSettings.DryRunMode)
                {
                    LogInfo("********************************************************************************");
                    LogInfo("********************************************************************************");
                    LogInfo(" Migration is in DRY-RUN mode - no Sitecore 9 items will be updated or inserted");
                    LogInfo("********************************************************************************");
                    LogInfo("********************************************************************************");
                }

                if (!DisplayMigrationDetainsAndPromptToContinue(serviceProvider))
                {
                    LogInfo(_logSeparator);
                    LogInfo(_logSeparator);
                    LogInfo(_logSeparator);
                    LogInfo($"Migration cancelled!!");
                    LogInfo(_logSeparator);
                    LogInfo(_logSeparator);
                    LogInfo(_logSeparator);
                    return;
                }

                if (applicationSettings.IntegrationServiceSettings.ValidationService)
                {
                    await RunService(serviceProvider.GetService<ValidationService>());
                }
                if (applicationSettings.IntegrationServiceSettings.PageDataSourceIntegrationServiceCreateDataItems ||
                    applicationSettings.IntegrationServiceSettings.PageDataSourceIntegrationServiceUpdatePageItems)
                {
                    await RunService(serviceProvider.GetService<PageDataSourceIntegrationService>());
                }
                if (applicationSettings.IntegrationServiceSettings.WeBlogIntegrationService)
                {
                    await RunService(serviceProvider.GetService<WeBlogIntegrationService>());
                }
                if (applicationSettings.IntegrationServiceSettings.NewsIntegrationService)
                {
                    await RunService(serviceProvider.GetService<NewsIntegrationService>());
                }
                if (applicationSettings.IntegrationServiceSettings.SharedItemIntegrationService)
                {
                    await RunService(serviceProvider.GetService<SharedItemIntegrationService>());
                }
            }
            catch (Exception generalException)
            {
                Console.WriteLine(generalException.ToString());
                var logger = serviceProvider.GetService<ILogger<Program>>();
                logger.LogError(generalException, "An exception occurred while running the integration service.");
            }

            LogInfo(_logSeparator);
            LogInfo("Migration is complete!");
            LogInfo(_logSeparator);

            Console.ReadKey();
        }

        private static bool DisplayMigrationDetainsAndPromptToContinue(ServiceProvider serviceProvider)
        {
            ISitecore8WebsiteConfiguration sitecore8Website = serviceProvider.GetService<ISitecore8WebsiteConfiguration>();
            Sitecore9Website sitecore9Website = serviceProvider.GetService<Sitecore9Website>();

            if (sitecore8Website == null) throw new Exception("Sitecore8 website not found in servicecollection!");
            if (sitecore9Website == null) throw new Exception("sitecore9Website website not found in servicecollection!");

            LogInfo(_logSeparator);
            LogInfo(_logSeparator);
            LogInfo(_logSeparator);
            LogInfo("Starting migration....");
            LogInfo(_logSeparator);
            LogInfo(_logSeparator);
            LogInfo(_logSeparator);

            LogInfo($"Migrating from: {applicationSettings?.WebsiteSettings?.Sitecore8Uri}{applicationSettings?.WebsiteSettings?.Sitecore8WebsiteClassName}");
            LogInfo($"Sitecore 8 RootPath: {sitecore8Website.RootPath}");
            LogInfo(_logSeparator);
            LogInfo($"Migrating to: {applicationSettings?.WebsiteSettings?.Sitecore9Uri}{applicationSettings?.WebsiteSettings?.Sitecore9WebsiteRoot}");
            LogInfo($"Sitecore 9 RootPath: {sitecore9Website.RootPath}");
            LogInfo(_logSeparator);

            Console.WriteLine("\r\n\r\nIMPORTANT: The target Sitecore 9 site MUST be PUBLISHED before running this, to prevent duplicate items being migrated.\r\n\r\n");
            Console.WriteLine("Press Y to continue or any other key to exit\r\n\r\n");

            var key = Console.ReadKey();

            Console.WriteLine("");

            return string.Equals(key.Key.ToString(), "Y", StringComparison.OrdinalIgnoreCase);
        }

        private static async Task RunService(IIntegrationService integrationService)
        {
            LogInfo($"Running {integrationService.GetType().Name}");
            await integrationService.Run();
        }

        // This class has it's own logging methods as the migrationLogger class can't be instantiated from here (because DI isn't set up yet)
        // All other classes must use the MigrationLogger class, for consistency

        private static void LogInfo(string info)
        {
            logger.LogInformation(info);
            Console.WriteLine(info);
        }

        private static void LogDebug(string info)
        {
            logger.LogDebug(info);
            Console.WriteLine(info);
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
