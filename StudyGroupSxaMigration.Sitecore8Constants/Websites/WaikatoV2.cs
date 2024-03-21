using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    /// <summary>
    /// This holds all the paths and template ids required for the migration tool
    /// </summary>
    public class WaikatoV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public WaikatoV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Waikato V2/";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Waikato V2";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
        }

        private PageDataItemSubFolders SetPageItemSubFolders()
        {
            // no need to set any values as just using defaults. 
            return new PageDataItemSubFolders();
        }

        private PageTemplates SetPageTemplates()
        {
            return new PageTemplates()
            {
                HomePage = "{C7F69506-5297-4574-BF09-B52751A80B26}",
                HubPage = "{4FCA988D-FBC9-40F9-8F41-C371FFE63256}",
                InternalPage = "{6A56684B-EB1E-41BB-9DFF-07F10DC9C97F}",
                BlogHomePage = "{71285F51-6B0B-4262-BE13-88DD165AB9FF}",
                BlogCategoryPage = "{454A0DB9-856C-4DB7-B47C-619340ADBAB6}",
                BlogEntryPage = "{DEABE4D3-5FE6-44EE-9105-50A16C9EFCAA}",
                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
                CampaignPage = "{188F5E6D-E7E4-428B-962F-F2757FE00DC8}",
                NewsArticlePage = "{70E027DA-10F7-4DC8-B64A-61A968BA5F03}",
                NewsListingPage = "{4E14D10B-6098-4B90-8DAB-633D9FF0293A}"// "{43938C41-7110-4227-B500-3662CBCFACF6}"
            };
        }

        private SharedItemPaths SetSharedItemsPaths()
        {
            string sharedItemPath = $"{RootPath}{Sitecore8Paths.SharedItemFolderName}";

            return new SharedItemPaths(sharedItemPath)
            {
                FolderPath = sharedItemPath,
                Accordions = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Accordions}",
                ButtonGroups = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ButtonGroups}",
                Carousels = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Carousels}",
                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
                HeroContent = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeroContent}",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                LiveChat = $"{sharedItemPath}/{SharedItemDefaultFolderNames.LiveChat}",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
                SharedComboMenus = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SharedComboMenus}",
                SocialMedia = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SocialMedia}"
            };
        }

        private WebsiteTemplates SetTemplateIds()
        {
            return new WebsiteTemplates()
            {
                AccordionItem = "{17A50E41-6415-4F58-B2B4-07BFC720F058}",
                AccordionContainer = "{ABB8FEB2-8C10-4A5E-8E32-DA9ECE02BC44}",
                ButtonGroupContainer = "{4112CA41-15C4-471F-834D-572475874E97}",
                CarouselContainer = "{E435D32F-4DDD-4563-A0BC-AEA270FDC136}",
                CarouselSlide = "{5A876983-A019-4EBF-B670-380A46CA5436}",
                ContentBox = "{E987CE2C-0C12-4026-8623-74A76E7701D7}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{F0D2B21B-CD17-4301-AF3A-874B03FF948E}",
                GalleryContainer = "{95B6593C-140F-4D3D-B86F-6D01377B9950}",
                GalleryItem = "{BA4282FD-CB0C-4D56-83EB-13C8323578F6}",
                Hero = "{57459736-8D05-4D51-8A13-D873387A6C8B}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "{EEBBDF01-8946-4DB6-BD87-5232E9B8F0C7}",
                Map = "{742296AB-46DC-4801-B20C-119677A6B8DF}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{D4957786-03B4-4E50-BD0D-410C45CA924C}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{DA499C18-D3F8-4F97-8963-2FA64E27B072}",
                TabContainer = "{D0E8CB40-7EFB-4A60-B8BF-153DE87FCE53}",
                Testimonial = "{6199F0A4-3C19-4B12-B883-9B0BE793A3F3}",
                Video = "{B83A2880-BA28-4B38-9753-D25D1B589D6E}",
                Widgets = new List<string> {
                    "{AF294AEC-47DF-41BF-ADE6-FFBBEC89DF27}",
                    "{3581A25A-DBC0-46F4-A387-0F589D3A37AF}",
                    "{88750DA3-55CE-47DE-9308-34C0E827EEB5}",
                    "{6AF460F2-FA83-4BB5-A334-4D227A97AFF8}",
                    "{40AF16E5-DA88-425A-BD29-65DD0E4E531F}",
                    "{DE606AA2-9D33-48F7-B3E7-69C0F2F25FE6}"
                }
            };
        }
    }
}
