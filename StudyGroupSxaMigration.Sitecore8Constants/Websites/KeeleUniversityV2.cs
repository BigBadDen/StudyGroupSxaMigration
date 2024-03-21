using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class KeeleUniversityV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public KeeleUniversityV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Keele University V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Keele V2";
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
                HomePage = "{4E818A95-5B34-4A24-AC35-1CFECA2013D5}",
                HubPage = "{80871ECA-7A03-4AA3-BE62-8FE8C06D1F93}",
                InternalPage = "{493C8082-C88E-4923-BD51-03197025C8F2}",
                BlogCategoryPage = "{949C8707-7DB9-40CB-9342-62E59D7C3B70}",
                BlogEntryPage = "{A8BC3BA1-E90A-4A96-8513-0DFD5ED09362}",
                BlogHomePage = "{D44CBBE0-8FA1-40C3-8E59-3933134B4D27}",
                DirectApplicationForm = "{8AB5D6C3-602B-47FD-BEDD-2824E06A27EB}",
                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
                CampaignPage = "{9F0D1660-768F-4F98-B629-004A99F61ED2}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}"
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
                AccordionItem = "{6A32AED9-3D9E-4EA8-9E87-283EEC21ED3F}",
                AccordionContainer = "{1A76098D-0565-48B2-A14B-A865E73CBCB7}",
                ButtonGroupContainer = "{2AA103ED-D032-4878-8DA3-EDC496ECC5C8}",
                CarouselContainer = "{16E7D5DC-2EE1-42DA-959C-FB112C795792}",
                CarouselSlide = "{E8A700CA-51D4-41D8-AE99-2AF1CCE02B73}",
                ContentBox = "{F192C429-6BF7-4DAE-A8D1-888EE1D595FF}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{46023D7D-02BB-4B63-A910-68B91D9A2793}",
                GalleryContainer = "{6B47F339-4F2A-4770-820B-FCFAA5D3DF2C}",
                GalleryItem = "{7A15409E-0C44-463F-A1D1-562990D17A86}",
                Hero = "{77B2E5BC-5052-41F5-BDDD-CF5BC0A4020E}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{AA5B9790-5BF7-42DB-8962-28EE6BFF0F59}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{98B0BA0F-34D1-4FFE-B82C-2D4D151B5718}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{44E92830-D3A3-4CA5-911F-B460359D497E}",
                TabContainer = "{9FFFFAA9-DAC5-44D8-B4A8-21C6696CC118}",
                Testimonial = "{084FB215-4DA1-4BD6-9A39-2CBD6F8DA0F6}",
                Video = "{1BA39C58-D7B1-48EE-933B-64C1E1FF8C49}",
                Widgets = new List<string>
                {
                    "{C9C69ABB-708B-4E9D-B2CE-F9ACF2D774AB}",
                    "{51120EA7-81DB-4F4C-A3AB-B123444BAAAE}",
                    "{00BEDF49-E9A3-4FB2-930B-699BC3BE5C27}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}",
                    "{3FEF07D4-0857-4548-8B3E-C3E8A81026DF}"
                }
            };
        }
    }
}
