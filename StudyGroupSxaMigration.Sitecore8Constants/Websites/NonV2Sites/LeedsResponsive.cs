//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class LeedsResponsive : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public LeedsResponsive()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/Leeds Responsive/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Leeds";
//        }

//        /// <summary>
//        /// The names of sub-folders under "Page Items" folder. If default folder names are used e.g. "Accordions" etc.,
//        /// just return a new PageDataItemSubFolders instance without setting any values. Otherwise, return a new PageDataItemSubFolders 
//        /// object with the correct values for the folder names
//        /// </summary>
//        /// <returns></returns>
//        private PageDataItemSubFolders SetPageItemSubFolders()
//        {
//            return new PageDataItemSubFolders();
//        }

//        /// <summary>
//        /// Template ids for the main page templates. Only return values for the pages that are used for the site
//        /// </summary>
//        /// <returns></returns>
//        private PageTemplates SetPageTemplates()
//        {
//            return new PageTemplates()
//            {
//                HomePage = "{F7AA6840-73CD-478F-B96C-74367AC6DA12}",
//                HubPage = "{32BC2027-933D-4A62-AD88-FDCE23E0237C}",
//                ContentPage = "{CEEA2BDA-56D6-43D9-AE53-B21767021EEF}",
//                NewsArticlePage = "{9CC8C6E5-B2F5-457A-89F8-DBCCA8625238}",
//                NewsListingPage = "{32993FED-4C51-48D9-A1C4-5DE76396E0D1}",
//                ProgrammePage = "{95A113F3-9324-4775-9800-807C7C8BCB90}",
//                FormPage = "{833F3054-6498-4AAF-8984-C1FCFFDA4595}",
//                SearchPage = "{32993FED-4C51-48D9-A1C4-5DE76396E0D1}"
//            };
//        }

//        /// <summary>
//        /// Set a value for each shared item path. Defaults are provided in the SharedItemDefaultFolderNames constants, but note that some sites 
//        /// use slightly different naming conventions 
//        /// Also, many sites do not contain all folders below; only set the folder names if they exist in the Sitecore 8 website
//        /// </summary>
//        /// <returns></returns>
//        private SharedItemPaths SetSharedItemsPaths()
//        {
//            string sharedItemPath = $"{RootPath}{Sitecore8Paths.SharedItemFolderName}";

//            return new SharedItemPaths(sharedItemPath)
//            {
//                FolderPath = sharedItemPath,
//                ButtonGroups = $"{sharedItemPath}/Call to Action Panels",
//                Carousels = $"{sharedItemPath}/Carousels",
//                Galleries = $"{sharedItemPath}/Gallery",
//                Maps = $"{sharedItemPath}/Maps",
//                RelatedLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinks}",
//                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
//                Testimonials = $"{sharedItemPath}/Testimonials",
//                Tabs = $"{sharedItemPath}/Tabbed Content",
//                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
//                Videos = $"{sharedItemPath}/Videos",
//                SocialMedia = $"{sharedItemPath}/Social Media Buttons"
//            };
//        }

//        /// <summary>
//        /// Ids of templates used by the website
//        /// </summary>
//        /// <returns></returns>
//        private WebsiteTemplates SetTemplateIds()
//        {
//            return new WebsiteTemplates()
//            {
//                AccordionItem = "",
//                AccordionContainer = "",
//                ButtonGroupContainer = "{F0F365AF-096C-4DCC-B786-00E5F4EE98AF}",
//                CarouselContainer = "{FA64353F-14A1-4ABA-AE49-0AACE224A108}",
//                CarouselSlide = "{43F78EAD-AE71-4A94-A5FD-A8B6B57D2241}",
//                ContentBox = "",
//                CTA = "{8C6E3D17-F7FE-42F8-BF3C-721881570739}",
//                GalleryContainer = "",
//                GalleryItem = "{183E20F9-3E98-4B5F-8C0F-28B99EDF1EC9}",
//                Hero = "",
//                LanguageLinkItem = "",
//                LanguageLinks = "",
//                LiveChat = "",
//                Map = "{8E59BC6A-2EEB-45CE-93DC-79FA72094FDF}",
//                MenuLinks = "",
//                PageItems = "",
//                ProgressionRoutes = "{343197CA-2C64-45DD-82AC-FEAAF7284AC7}",
//                RelatedLinks = "{8EC6BC1D-C1EE-4C30-95E5-AAE5E0C9BB9B}",
//                RelatedLinksWithSections = "{24CCCB08-BCA2-413A-A724-A0FFC22A01D0}",
//                ScriptSnippet = "",
//                SidebarBoxes = "{4D7ACF5F-89FD-4367-AC85-8BBA093C950D}",
//                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
//                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
//                Tab = "{4B12DAFF-2867-4728-A54A-6F6809D098D3}",
//                TabContainer = "{C03C9BD6-3092-4203-9D6E-78F0DBC3A9A2}",
//                Testimonial = "{5F5E1742-662E-4400-AFE0-2584B3190374}",
//                Video = "",
//                Widget = ""
//            };
//        }
//    }
//}
