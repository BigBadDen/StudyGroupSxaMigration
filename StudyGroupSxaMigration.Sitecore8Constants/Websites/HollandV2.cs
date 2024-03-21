using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class HollandV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public HollandV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Holland V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/HollandV2";
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
                Accordions = "Page Accordions",
                ButtonGroups = "Buttons",
                ContentBoxes = "Page Content Boxes",
                Heroes = "Page Heroes",
                Maps = "Page Maps",
                Tabs = "Page Tabs",
                Testimonials = "Page Testimonials",
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
                HomePage = "{B29D4B4A-4162-4A96-8E6C-704B79C14626}",
                HubPage = "{B43DA9D0-368D-4612-AEB0-F1D18735B8BE}",
                ContentPage = "{73711C35-47ED-4CB1-A73E-79CD881EFB81}",
                BlogEntryPage = "{FF1C56D9-BFFE-4150-9191-594AEFF71BE5}",
                BlogCategoryPage = "{489CAD25-896E-43F2-A510-708BEE64E740}",
                BlogHomePage = "{A6CE3FAC-1B29-41BD-8F94-199DFDC203B0}",
                NewsArticlePage = "{CC244D44-9851-4AA0-A9B3-5CF29438CAD0}",
                NewsListingPage = "{DE9E6CDB-0D7B-4604-A14D-BE82F80F9F82}",
                GenericPage = "{7C3AD827-13CC-4979-BCA7-938B78336B4A}",
                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
                SearchPage = "{72C1A240-057E-4A45-8F5B-91D1C1B48ABA}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
                CampaignPage = "{DEDE7339-23D1-42FD-875C-BB75D608A520}"
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
                ButtonGroups = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ButtonGroups}",
                Carousels = $"{sharedItemPath}/Shared Carousel",
                ContentBoxes = $"{sharedItemPath}/Shared Content Box",
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
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
                AccordionItem = "{0D547539-9364-4E6B-B7F7-98684912985E}",
                AccordionContainer = "{B345E40F-9803-4637-ADE4-06A63896819A}",
                ButtonGroupContainer = "{3E627FEA-4392-4F89-B1EA-027D9F1CD9BC}",
                CarouselContainer = "{DCA2ED7F-6EDF-4DF3-966D-CDEF69B24733}",
                CarouselSlide = "{D68C2181-B9D7-45D1-A67F-F2BECC73B3A1}",
                ContentBox = "{99EA0382-5BCB-436E-9359-A8D11D36BF87}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{8C81FDAB-CC90-4C9D-A088-19392317846F}",
                GalleryContainer = "{846E03A8-4208-46F8-9DA4-38B0BFB01C11}",
                GalleryItem = "{61470705-9726-4818-9B8E-39AC36A98E2D}",
                Hero = "{9FF581CA-8DCD-4DAF-9AAC-4EBFA7F36F30}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{0E1318EB-54A2-4E2D-9B79-C13A7C6741CE}",
                MenuLinks = "{1E96A086-0CB6-4316-9811-042F9A7FD9E4}",
                PageItems = "{4E739A5D-D12F-4E92-9E00-EE384CB700AC}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{838B372C-2C77-48C3-B262-12B0B47048B5}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{2E991B16-7752-45ED-A8AA-2EB9DCCD36BD}",
                TabContainer = "{6AE5AE0D-51CE-4E28-A4F2-6D9A81BD6FE8}",
                Testimonial = "{A9F48B69-3D2B-426C-8BCD-AD810776CAE2}",
                Video = "{031197A0-6C02-45F5-B6C4-3B119C80A731}",
                Widgets = new List<string> {
                    "{8C75B035-C544-4E72-90BA-95238568BE4A}",
                    "{C8CC09A7-DE31-47E6-8E5F-66103AE298BD}",
                    "{3FEF07D4-0857-4548-8B3E-C3E8A81026DF}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}"
                }
            };
        }
    }
}
