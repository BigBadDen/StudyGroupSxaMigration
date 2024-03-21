using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.Sitecore8Constants.Websites.OldSitesWithBlogsOrNews
{
    public class RoyalRoads : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public RoyalRoads()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Royal Roads University v2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/RoyalRoadsV2";
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
                HomePage = "{348A220A-0884-40DA-9780-F0FCD3D05B96}",
                HubPage = "{A8D71C29-9EA1-4EFC-9342-EEA0F028924D}",
                BlogEntryPage = "{A746B2F3-1E6D-47CB-A5D5-F5F44F6C3A34}",
                BlogCategoryPage = "{B66B1D3E-FE0C-4669-8D40-78DFF724D2C8}",
                BlogHomePage = "{D00A5555-EE03-4E27-BD59-37809AB70F84}",
                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
                NewsArticlePage = "{420A6261-7602-4925-87D1-1C951F7E3919}",
                SearchPage = "{EF482F64-378C-49B9-95AD-3353C2D3A967}",
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
                Carousels = $"{sharedItemPath}/Carousels",
                ContentBoxes = $"{sharedItemPath}/Homepage Content Boxes",
                Galleries = $"{sharedItemPath}/Gallery",
                Languages = $"{sharedItemPath}/Languages",
                Maps = $"{sharedItemPath}/Maps",
                RelatedLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinks}",
                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
                ScriptSnippet = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ScriptSnippet}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Testimonials = $"{sharedItemPath}/Testimonials",
                Videos = $"{sharedItemPath}/Videos",
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
                AccordionItem = "{FD8E0696-04B5-4DE6-A5AA-C5B5C6783B99}",
                AccordionContainer = "{F7405B2A-32A6-4781-B8F4-B47A10B89235}",
                ButtonGroupContainer = "",
                CarouselContainer = "",
                CarouselSlide = "",
                ContentBox = "{AACE16C8-5D4E-4D53-B620-2315DF96B895}",
                CTA = "{8C6E3D17-F7FE-42F8-BF3C-721881570739}",
                GalleryContainer = "",
                GalleryItem = "",
                Hero = "",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "{D74A351F-2A06-499F-BDAB-9EAA01A14486}",
                Map = "",
                MenuLinks = "",
                PageItems = "{4DA435B0-642B-439C-AEE4-66AF7425D2C8}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
                SidebarBoxes = "",
                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
                Tab = "{B2A8E0CE-F3C0-4A40-8924-864A00CE988C}",
                TabContainer = "{C7DD4AC8-F1CD-487A-BF78-3F408FB2B911}",
                Testimonial = "{E2AEB054-DE89-4A88-9BF6-7730E8F24534}",
                Video = "{279E8FDE-960A-4C47-AA22-3D2CA38A8C58}",
                Widgets = new List<string> { "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}" }
            };
        }
    }
}
