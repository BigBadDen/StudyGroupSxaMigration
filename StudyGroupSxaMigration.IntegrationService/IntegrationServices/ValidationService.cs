using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore8Constants;
using StudyGroupSxaMigration.IntegrationService.Migration;
using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.IntegrationService.ItemMigration;
using StudyGroupSxaMigration.SitecoreConstants;
using StudyGroupSxaMigration.Sitecore9Constants;
using StudyGroupSxaMigration.AppSettings;
using System.Linq;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using StudyGroupSxaMigration.SitecoreCommon;

namespace StudyGroupSxaMigration.IntegrationService.IntegrationServices
{
    public class ValidationService : IntegrationServiceBase, IIntegrationService
    {
        private SitecoreItem sitecore8HomeItem;
        private List<SitecoreItem> hubPages;

        public ValidationService(
                                ISitecore8Client sitecore8Client,
                                ISitecore9Client sitecore9Client,
                                ISitecore8Repository sitecore8Repository,
                                ILogger<ValidationService> logger,
                                IEnumerable<IItemMigration> migrations,
                                ISitecore8WebsiteConfiguration sitecore8Website,
                                Sitecore9Website sitecore9Website,
                                ApplicationSettings applicationSettings) :
                    base(sitecore8Client,
                        sitecore9Client,
                        sitecore8Repository,
                        logger,
                        migrations,
                        sitecore8Website,
                        sitecore9Website,
                        applicationSettings)
        {
        }

        public async Task Run()
        {
            await CheckSitecore9HomePagePath();
            await CheckSitecore8HomePageTemplateAndPath();
            await CheckSitecore8HubTemplate();
            await CheckSitecore8InternalPageTemplate();
            await CheckSitecore8TemplateIds();
        }

        /// <summary>
        ///  Throw an exception if sitecore 9 home page is not found.
        ///  If it is found, check that it's template name is "Home"
        /// </summary>
        /// <returns></returns>
        private async Task CheckSitecore9HomePagePath()
        {
            migrationLogger.LogInfo("Validating Sitecore9 HomePagePath...");

            SitecoreItem sitecore9HomeItem = await _sitecore9Client.GetItemByPath<SitecoreItem>(_sitecore9Website?.HomePagePath);
            if (sitecore9HomeItem == null)
            {
               throw new Exception($"Sitecore 9 Home page item not found. Check {_sitecore9Website?.GetType()?.Name}.HomePagePath: '{_sitecore9Website?.HomePagePath}' and also Sitecore9WebsiteRoot in appsettings");
            }

            migrationLogger.LogInfo("Verifying the Sitecore9 HomePage template name - shoud be 'Home'...");

            if (!String.Equals(sitecore9HomeItem.TemplateName, "Home", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Sitecore 9 Home page item does not appear to be of correct type. Template name should be 'Home' but it is actually '{sitecore9HomeItem.TemplateName}'. Check {_sitecore9Website?.GetType()?.Name}.HomePagePath: '{_sitecore9Website?.HomePagePath}'");
            }

            migrationLogger.LogInfo("Done!");
        }

        /// <summary>
        /// There should be at least one hub page item under the home page. If not, just log a warning
        /// </summary>
        /// <returns></returns>
        private async Task CheckSitecore8HubTemplate()
        {
            migrationLogger.LogInfo("Validating hub page template id...");

            hubPages = await _sitecore8Repository.GetItemChildrenByPath<SitecoreItem>(_sitecore8Website?.HomePagePath, _sitecore8Website.PageTemplates.HubPage);

            if (hubPages == null || hubPages?.Count == 0)
            {
                migrationLogger.LogError($"No hub pages found for the {_sitecore8Website?.GetType()?.Name} hub page template id. Check {_sitecore8Website?.GetType()?.Name}.PagesTemplates.HubPage: '{_sitecore8Website?.PageTemplates?.HubPage}'");
            }
            else
            {
                migrationLogger.LogInfo("Done!");
            }
        }

        /// <summary>
        /// There should be at least one internal page item under the home page. If not, throw an exception. 
        /// </summary>
        /// <returns></returns>
        private async Task CheckSitecore8InternalPageTemplate()
        {
            migrationLogger.LogInfo("Validating internal page template id...");

            if (await DoesItemContainChildrenOfGivenTemplateType(_sitecore8Website.HomePagePath, _sitecore8Website?.PageTemplates?.InternalPage))
            {
                migrationLogger.LogInfo("Done!");
                return;
            }
            foreach (SitecoreItem pageItem in hubPages)
            {
                if (await DoesItemContainChildrenOfGivenTemplateType(pageItem.ItemPath, _sitecore8Website?.PageTemplates?.InternalPage))
                {
                    migrationLogger.LogInfo("Done!");
                    return;
                }
            }
            throw new Exception($"No internal pages found for the {_sitecore8Website?.GetType()?.Name} hub page template id. Check {_sitecore8Website?.GetType()?.Name}.PagesTemplates.HubPage: '{_sitecore8Website?.PageTemplates?.HubPage}'");
        }

        private async Task<bool> DoesItemContainChildrenOfGivenTemplateType(string searchPath, string templateId)
        {
            List<SitecoreItem> sitecorePages = await _sitecore8Repository.GetItemChildrenByPath<SitecoreItem>(searchPath, templateId);
            return !(sitecorePages == null || hubPages?.Count == 0);
        }

        private async Task CheckSitecore8HomePageTemplateAndPath()
        {
            migrationLogger.LogInfo("Validating home page path and template id...");

            sitecore8HomeItem = await _sitecore8Repository.GetItemByPath<SitecoreItem>(_sitecore8Website?.HomePagePath, false);
            if (sitecore8HomeItem == null)
            {
                throw new Exception($"Sitecore 8 Home page not found: '{_sitecore8Website?.HomePagePath}'");
            }
            if (!sitecore8HomeItem.TemplateIdEquals(_sitecore8Website?.PageTemplates?.HomePage))
            {
                throw new Exception($"Sitecore 8 Home page '{_sitecore8Website?.HomePagePath}' does not have the expected template id - check {_sitecore8Website?.GetType()?.Name}.PagesTemplates.HomePage): '{_sitecore8Website.PageTemplates.HomePage}'. Actual template id is:'{sitecore8HomeItem.TemplateID}'");
            }
            migrationLogger.LogInfo("Done!");
        }

        private async Task ValidateSitecore8WidgetsTemplateId(string id, string description)
        {
            migrationLogger.LogInfo($"Validating {description} template id...");

            if (String.IsNullOrEmpty(id))
            {
                migrationLogger.LogWarning($"{description} template id has not been specified for the Sitecore 8 Website - see the current website class in StudyGroupSxaMigration.SitecoreConstants.Websites!");
            }
            else
            {
                var templateItem = await _sitecore8Repository.GetItemById<SitecoreItem>(id);
                if (templateItem == null)
                {
                    migrationLogger.LogWarning($"{description} template item id {id} not found in Sitecore 8");
                }
                else
                {
                    migrationLogger.LogInfo($"{description} template id found. Path is {templateItem.ItemPath}");
                }
            }
        }

        private async Task CheckSitecore8TemplateIds()
        {
            migrationLogger.LogInfo("Validating Sitecore8 Template Ids...");

            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.AccordionContainer, "Accordion Container");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.AccordionItem, "AccordionItem");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.ButtonGroupContainer, "ButtonGroupContainer");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.CarouselContainer, "CarouselContainer");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.CarouselSlide, "CarouselSlide");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.ContentBox, "ContentBox");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.ComboMenuItem, "ComboMenuItem");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.CTA, "CTA");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.GalleryContainer, "GalleryContainer");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.GalleryItem, "GalleryItem");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.Hero, "Hero");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.LiveChat, "LiveChat");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.ProgressionRoutes, "ProgressionRoutes");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.SocialMediaContainer, "SocialMediaContainer");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.SocialMediaLinks, "SocialMediaLinks");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.Tab, "Tab");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.TabContainer, "TabContainer");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.SocialMediaLinks, "SocialMediaLinks");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.Testimonial, "Testimonial");
            await ValidateSitecore8WidgetsTemplateId(_sitecore8Website.WebsiteTemplateIds?.Video, "Video");
        }
    }
}
