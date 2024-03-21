using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class LjmuV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public LjmuV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/LJMUV2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/LJMU V2";
        }

        /// <summary>
        /// The names of sub-folders under "Page Items" folder. If default folder names are used e.g. "Accordions" etc.,
        /// just return a new PageDataItemSubFolders instance without setting any values. Otherwise, return a new PageDataItemSubFolders 
        /// object with the correct values for the folder names
        /// </summary>
        /// <returns></returns>
        private PageDataItemSubFolders SetPageItemSubFolders()
        {
            return new PageDataItemSubFolders() {
                ButtonGroups = "Page Button Groups",
                Carousels = "Page Carousels",
                ContentBoxes = "Page Content Boxes",
                Galleries = "Page Galleries",
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
                HomePage = "{7C3A2769-FD71-4AF9-9435-6E2AEF6AAEFF}",
                HubPage = "{3244C361-4962-472D-B0A3-7EA7611B6304}",
                InternalPage = "{387897C2-D0DB-4634-9C5B-B8F7D544D1BC}",
                NewsArticlePage = "{FD5BF408-1266-4B04-A6D4-0CDD2586A5E0}",
                NewsListingPage = "{4D387309-F4F1-4AF4-8DDF-B00773BE6085}",
                DirectApplicationForm = "{405798BA-1417-4A5E-900D-A45B66FBA346}",
                GenericPage = "{4862B7E0-E16E-47D7-B545-403E4680AC71}",
                CampaignPage = "{26D13C92-66D1-4F2C-867A-5AAC6EA85C9D}",
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
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/Shared Languages",
                LiveChat = $"{sharedItemPath}/Live Agent",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
                SharedComboMenus = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SharedComboMenus}",
                SocialMedia = $"{sharedItemPath}/Shared Social Media"
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
                AccordionItem = "{9F997E98-363C-4CE7-8F49-4BBDD1584A82}",
                AccordionContainer = "{958C07BF-3BD1-469B-AFF7-D3CEB54C7EB6}",
                ButtonGroupContainer = "{74529E77-E8F8-49D3-90CC-A53B1E94AB32}",
                CarouselContainer = "{D887D28C-8E9A-40B0-8355-0EBBC7CA049B}",
                CarouselSlide = "{29FA22B8-21F6-4819-BFE9-F984AF311B9C}",
                ContentBox = "{3D6EBBC4-35BA-418F-B6DE-30A46E90108F}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{98E0C91C-5229-4584-9941-C7AFE9DEDAB8}",
                GalleryContainer = "{86CCB605-AF30-4A33-B538-B93997135F82}",
                GalleryItem = "{ACA46AFB-A2AB-4913-AE44-D9E1D8707671}",
                Hero = "{A9299BF9-D36A-46B0-95B3-4EF7E2C6FF24}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "{D74A351F-2A06-499F-BDAB-9EAA01A14486}",
                Map = "{C641498B-32D5-4605-A9A7-CB4DCCCED9C0}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{51A35994-2C40-408F-AC7F-7CB9B2DAFCB7}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{96D255FD-2125-4557-B250-0CCDBF7268E1}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{4E6B520F-B316-4A43-BEB8-4AAC90308B3E}",
                TabContainer = "{6FE3C25B-577F-41DF-A31E-54F7739E4822}",
                Testimonial = "{1F4EA843-6384-4C25-8EF5-FF955719DA6A}",
                Video = "{EF14A4D1-1548-4DE8-BD58-44E9DA5F2B45}",
                Widgets = new List<string>
                {
                    "{4E102C3A-1B82-4FF8-9224-F5EBC3A34FB0}",
                    "{7FD9B723-88A3-40EC-8A0C-4B06A161CB1F}",
                    "{5F4E3B51-99AD-4BA4-9EFF-CB18BA42A94C}",
                    "{7464ED4C-AEF3-438E-9557-37BA45FC0D32}",
                    "{FC7DF74C-162E-4449-87C5-BF27669B9D9C}",
                    "{3FEF07D4-0857-4548-8B3E-C3E8A81026DF}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}"
                }
            };
        }
    }
}
