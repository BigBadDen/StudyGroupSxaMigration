using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class TaylorsAfyV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public TaylorsAfyV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Taylors AFY V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Taylors AFY V2";
        }

        /// <summary>
        /// The names of sub-folders under "Page Items" folder. If default folder names are used e.g. "Accordions" etc.,
        /// just return a new PageDataItemSubFolders instance without setting any values. Otherwise, return a new PageDataItemSubFolders 
        /// object with the correct values for the folder names
        /// </summary>
        /// <returns></returns>
        private PageDataItemSubFolders SetPageItemSubFolders()
        {
            return new PageDataItemSubFolders()
            {
                Carousels = "Page Carousels",
                ContentBoxes = "Page Content Boxes",
                Heroes = "Page Heroes",
                Maps = "Page Maps",
                Tabs = "Page Tabs",
                Videos = "Page Videos",
                Widgets = "Page Widgets"
            };
        }

        /// <summary>
        /// Template ids for the main page templates. Only return values for the pages that are used for the site
        /// </summary>
        /// <returns></returns>
        private PageTemplates SetPageTemplates()
        {
            return new PageTemplates()
            {
                HomePage = "{C6260E35-4B4B-4497-824B-043D270C68BF}",
                HubPage = "{ACCCA8F3-DB88-4AC8-B978-85C794C5B29C}",
                InternalPage = "{8F8D1140-E7B4-434B-9A84-331B40CEAFCC}",
                NewsArticlePage = "{1E91A3D0-7F94-4970-B7BB-F567A10CA075}",
                NewsListingPage = "{06BC4678-AFD9-4653-97A9-2668B70F1180}",
                SearchPage = "{70AB3B50-182B-4C2D-87AD-4C9615FAE009}",
                CampaignPage = "{15F3F65F-A3B2-438D-9F6D-4F94876AD7E9}",
                LandingPage = "{672D235E-A259-41A3-8AD1-756D893592CF}",
                ThanksPage = "{672D235E-A259-41A3-8AD1-756D893592CF}"
            };
        }

        /// <summary>
        /// Set a value for each shared item path. Defaults are provided in the SharedItemDefaultFolderNames constants, but note that some sites 
        /// use slightly different naming conventions 
        /// Also, many sites do not contain all folders below; only set the folder names if they exist in the Sitecore 8 website
        /// </summary>
        /// <returns></returns>
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
                RelatedLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinks}",
                RelatedLinksWithSections = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinksWithSections}",
                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
                ScriptSnippet = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ScriptSnippet}",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
                SharedComboMenus = $"{sharedItemPath}/Footer menu combo items",
                SocialMedia = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SocialMedia}"
            };
        }

        /// <summary>
        /// Ids of templates used by the website
        /// </summary>
        /// <returns></returns>
        private WebsiteTemplates SetTemplateIds()
        {
            return new WebsiteTemplates()
            {
                AccordionItem = "{46AD6392-5C44-4FE7-8C68-36DD2D98EFD0}",
                AccordionContainer = "{19CDB06A-0020-467E-AE87-BEADF824A450}",
                ButtonGroupContainer = "{8268B934-49DC-4F5E-A2D5-E92B4849BD34}",
                CarouselContainer = "{263EE782-CDAB-46E9-8E5B-53B633F3684C}",
                CarouselSlide = "{92C71831-37CB-4780-AAA0-1B766C734808}",
                ContentBox = "{EC97807E-5AF6-44EB-9DF6-43F0D511F61F}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{409D8925-CBCD-4D49-9B2E-27A94CFBD554}",
                GalleryContainer = "{9F105237-BFDD-4EDC-AC23-E5CDBF5F7255}",
                GalleryItem = "{485BC7C6-97E4-41C1-BB12-E46116143362}",
                Hero = "{7EC501E6-308C-40DE-ADAE-4BFE80F900A2}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{13ECA6D7-7503-4E08-BE6C-29592A200A5C}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{95BDCD3D-73D5-4C88-9C67-A8F35A028F10}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{1821C313-6BF1-4D17-A3E8-CDB47C92C2BE}",
                TabContainer = "{7FB81BCB-1F57-432B-B667-0EAED035A6AC}",
                Testimonial = "{B944419A-6B0C-48AF-BAEC-5B9E6353A051}",
                Video = "{1ABCF513-54D8-45BA-9B7E-33B822C85EED}",
                Widgets = new List<string> {
                    "{4098C550-5435-4ECD-8A63-B0CD4CD93A21}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}"
                }
            };
        }
    }
}
