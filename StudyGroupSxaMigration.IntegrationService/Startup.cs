using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.SitecoreConstants;
using StudyGroupSxaMigration.Sitecore9Constants;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;
using StudyGroupSxaMigration.IntegrationService.ItemMigration;
using StudyGroupSxaMigration.IntegrationService.Migration;
using StudyGroupSxaMigration.IntegrationService.IntegrationServices;
using StudyGroupSxaMigration.ItemServices.Services;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.IntegrationService.BlogMigration;
using System.IO;
using StudyGroupSxaMigration.IntegrationService.Security;
using Newtonsoft.Json;
using StudyGroupSxaMigration.IntegrationService.ContentPageMigration;

namespace StudyGroupSxaMigration.IntegrationService
{
    public class Startup
    {
        public void ConfigureServices(ServiceCollection services)
        {
            IConfiguration configuration;

            try
            {
                configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile($"appsettings.json", true, true)
                   .AddJsonFile($"appsettings.environment.json", true, true)
                   .Build();
            }
            catch(System.FormatException formatException)
            {
                throw new Exception("Unexpected error occurred while parsing the appsettings.json / appsettings.environment.json files", formatException);
            }

            var appSettings = new ApplicationSettings();

            configuration.Bind(appSettings);

            services.AddSingleton(new LoggerFactory()
                .AddNLog()
                );
            NLog.LogManager.LoadConfiguration("nlog.config");

            services.AddLogging();

            services.AddSingleton<JsonSerializer>();

            //Sitecore authentication and site services
            RegisterSitecoreItemService(services, appSettings);

            // Migration classes - one per type of datasource item to be migrated:

            services.AddScoped<IItemMigration, AccordionMigration>();
            services.AddScoped<IItemMigration, ButtonGroupMigration>();
            services.AddScoped<IItemMigration, CarouselMigration>();
            services.AddScoped<IItemMigration, ComboMenuMigration>();
            services.AddScoped<IItemMigration, ContentBoxMigration>();
            services.AddScoped<IItemMigration, GalleryMigration>();
            services.AddScoped<IItemMigration, HeaderAndFooterLinkMigration>();
            services.AddScoped<IItemMigration, HeroContentMigration>();
            services.AddScoped<IItemMigration, LiveChatMigration>();
            services.AddScoped<IItemMigration, ProgressionRoutesMigration>();
            services.AddScoped<IItemMigration, SocialMediaMigration>();
            services.AddScoped<IItemMigration, TabMigration>();
            services.AddScoped<IItemMigration, TestimonialMigration>();
            services.AddScoped<IItemMigration, VideoMigration>();
            services.AddScoped<IItemMigration, WidgetMigration>();

            // ContentPageItem migration is a unique type, rather than IItemMigration

            services.AddScoped<ContentPageItemMigration, ContentPageItemMigration>();

            // Blog classes 

            services.AddScoped<IBlogMigration, NewsArticleMigration>();
            services.AddScoped<IBlogMigration, NewsListingMigration>();

            services.AddScoped<IBlogMigration, WeBlogHomePageMigration>();
            services.AddScoped<IBlogMigration, WeBlogEntryPageMigration>();

            // Sxa services - (NB. may be more than one service for each migration class e.g ButtonGroup = ButtonGroup & CTAs)

            services.AddScoped<ISxaService, SxaLiveChatService>();
            services.AddScoped<ISxaService, SxaAccordionContainerService>();
            services.AddScoped<ISxaService, SxaAccordionService>();
            services.AddScoped<ISxaService, SxaTabContainerService>();
            services.AddScoped<ISxaService, SxaTabService>();
            services.AddScoped<ISxaService, SxaBlogHomeService>();
            services.AddScoped<ISxaService, SxaBlogEntryService>();
            services.AddScoped<ISxaService, SgSxaButtonGroupService>();
            services.AddScoped<ISxaService, SxaCarouselService>();
            services.AddScoped<ISxaService, SxaComboMenuService>();
            services.AddScoped<ISxaService, SxaCarouselSlideService>();
            services.AddScoped<ISxaService, SxaContentBoxService>();
            services.AddScoped<ISxaService, SxaContentPageService>();
            services.AddScoped<ISxaService, SxaFolderService>();
            services.AddScoped<ISxaService, SxaLinkService>();
            services.AddScoped<ISxaService, SxaWidgetService>();
            services.AddScoped<ISxaService, SxaTestimonialService>();
            services.AddScoped<ISxaService, SxaGalleryService>();
            services.AddScoped<ISxaService, SxaGalleryImageService>();
            services.AddScoped<ISxaService, SxaHeroService>();
            services.AddScoped<ISxaService, SxaProgressionRouteService>();
            services.AddScoped<ISxaService, SxaVideoService>();
            services.AddScoped<ISxaService, SxaSocialMediaContainerService>();
            services.AddScoped<ISxaService, SxaSocialMediaService>();
            services.AddScoped<ISxaService, SxaLinkListService>();
            //etc.

            services.AddScoped<ValidationService>();
            services.AddScoped<SharedItemIntegrationService>();
            services.AddScoped<PageDataSourceIntegrationService>();
            services.AddScoped<WeBlogIntegrationService>();
            services.AddScoped<NewsIntegrationService>();

            services.AddScoped<ISitecore8Repository, Sitecore8Repository>();
            services.AddScoped<Sitecore9Website>();
            services.AddScoped<RichTextFieldMigration>();
            services.AddScoped<LinkFieldMigration>();
            services.AddScoped<ImageFieldMigration>();

            services.AddSingleton<ApplicationSettings>(appSettings);

            ApplicationSettings = appSettings;
        }

        /// <summary>
        /// Setup general authentication services
        /// We can use the cookie auth method for environments which have https connections and 
        /// have AuthenticateSitecore9Connection set in the appsettings 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="appSettings"></param>
        private static void RegisterSitecoreItemService(IServiceCollection services, ApplicationSettings appSettings)
        {
            services.AddHttpClient<ISiteCoreAuthenticationClient, SitecoreAuthenticationClient>();
            services.AddTransient<SitecoreCookieHandler>();

            if (appSettings.WebsiteSettings == null)
            {
                throw new Exception($"WebsiteSettings not found in appsettings.{ Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() }.json");
            }

            // It seems that you can't add SitecoreCookieHandler for Sitecore 8 and 9 at the same time
            // so Sitecore8 connection will not be authenticaed. NB. It's read-only anyway.
            services.AddHttpClient<ISitecore8Client, Sitecore8Client>();

            var sitecore8Website = Sitecore8Constants.Sitecore8WebsiteFactory.GetTypeOfSitecore8Website(appSettings);
            var sitecore8Site = (ISitecore8WebsiteConfiguration)Activator.CreateInstance(sitecore8Website);
            services.AddSingleton<ISitecore8WebsiteConfiguration>(sitecore8Site);

            if (appSettings.WebsiteSettings.AuthenticateSitecore9Connection)
            {
                services
                    .AddHttpClient<ISitecore9Client, Sitecore9Client>()
                    .AddHttpMessageHandler<SitecoreCookieHandler>();
            }
            else
            {
                services.AddHttpClient<ISitecore9Client, Sitecore9Client>();
            }
        }

        public ApplicationSettings ApplicationSettings { get; set; }
    }
}