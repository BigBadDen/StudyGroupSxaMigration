using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class RhulV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public RhulV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/RHUL V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/RHUL V2";
        }

        /// <summary>
        /// The names of sub-folders under "Page Items" folder. If default folder names are used e.g. "Accordions" etc.,
        /// just return a new PageDataItemSubFolders instance without setting any values. Otherwise, return a new PageDataItemSubFolders 
        /// object with the correct values for the folder names
        /// </summary>
        /// <returns></returns>
        private PageDataItemSubFolders SetPageItemSubFolders()
        {
            return new PageDataItemSubFolders();
        }

        /// <summary>
        /// Template ids for the main page templates. Only return values for the pages that are used for the site
        /// </summary>
        /// <returns></returns>
        private PageTemplates SetPageTemplates()
        {
            return new PageTemplates()
            {
                HomePage = "{195860B0-1978-464E-944B-20B5F5638059}",
                HubPage = "{200C920C-5B16-495B-A280-3D97F32AF48C}",
                InternalPage = "{58BE0BD9-8CD2-44B9-AC27-75822FA8A1F2}",
                NewsArticlePage = "{BCEA0BEA-F5CA-4B09-BEC7-AA701751827A}",
                NewsListingPage = "{CE4BF509-18F5-493C-8CFB-2A9B15A2439B}",
                DirectApplicationForm = "{5A22EA8A-1EA0-4360-9873-E7C5188DDA8B}",
                CampaignPage = "{A2B008E7-F3AE-4D7D-829C-80E914FF6467}",
                LandingPage = "{672D235E-A259-41A3-8AD1-756D893592CF}",
                ThanksPage = "{596ABC77-BC16-41FF-811D-907346AE1AD3}"
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
                ButtonGroups = $"{sharedItemPath}/Shared Botton Groups",
                Carousels = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Carousels}",
                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
                HeroContent = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeroContent}",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
                SharedComboMenus = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SharedComboMenus}",
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
                AccordionItem = "{A5184579-0B69-4106-8182-B95314520956}",
                AccordionContainer = "{A50DF0C5-3534-48D2-B702-9FC42146CB6A}",
                ButtonGroupContainer = "{10700A85-5753-482B-BE65-B3E906F175A0}",
                CarouselContainer = "{82525B41-E5D6-45CF-8382-04981DB16C61}",
                CarouselSlide = "{16340A5A-488E-4CE8-BF73-A656D68B4419}",
                ContentBox = "{99D3FCD3-8B8B-4515-9896-413719393177}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{B91E3672-B5B3-407B-8844-A8BB5489D364}",
                GalleryContainer = "{1FDE7679-6358-4135-B335-6902AA6FDFBC}",
                GalleryItem = "{1F4B8CF7-69F4-48B1-8EBB-AABB603CC535}",
                Hero = "{FF177B99-881E-42B8-8EEA-A3B53F7EB28C}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{D4796CC2-D171-4239-BA22-103F9CF465A3}",
                MenuLinks = "",
                PageItems = "{C4049A03-5556-4099-82BC-CA7BF9969B5B}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{B309FCF6-CB91-4A5D-8594-51FE6257C4F9}",
                TabContainer = "{D79B854F-A432-495A-A503-677FF93CC8DC}",
                Testimonial = "{9EC1EA3F-FF24-4730-A6C5-875BF51BFBAF}",
                Video = "{88EEA28A-2D9B-4227-AE70-80643751E820}",
                Widgets = new List<string>
                {
                    "313F7CD5-BC1B-43D9-894F-6D14D4238D40}",
                    "{0063E0AF-7AEF-4EE7-9AA1-2D98D0004E7C}",
                    "{CF239C35-7A3D-4154-A802-93E487DF4D6E}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}",
                    "{FC68BB74-953C-4BE5-B21C-96FC04C32CCF}"
                }
            };
        }
    }
}
