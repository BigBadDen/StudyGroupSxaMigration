//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class Roosevelt : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public Roosevelt()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/Roosevelt/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Roosvelt";
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
//                HomePage = "{2435D919-31D4-43BD-B19A-067C1266739F}",
//                HubPage = "{476E889A-C5EC-4E67-8B12-90BF80BFB639}",
//                ContentPage = "{463160E3-E41C-478A-9828-0B380FD14B11}",
//                NewsArticlePage = "{B366EF97-C9D5-421B-A8AE-E0BDE4C954B1}",
//                NewsListingPage = "{1BB73674-1277-4F20-BCF1-D1B54EC7A945}",
//                ProgrammePage = "{E4AA201C-6E5B-4D94-89C6-247123A35B94}",
//                FormPage = "{AAB7224D-A46E-41F3-BE74-12B194C406F4}",
//                SearchPage = "{1BB73674-1277-4F20-BCF1-D1B54EC7A945}",
//                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
//                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}"
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
//                Maps = $"{sharedItemPath}/Maps",
//                RelatedLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinks}",
//                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
//                Testimonials = $"{sharedItemPath}/Testimonials"
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
//                CarouselSlide = "{3A68EC27-EA41-4846-B58D-CF66279E76FD}",
//                ContentBox = "",
//                CTA = "{8C6E3D17-F7FE-42F8-BF3C-721881570739}",
//                GalleryContainer = "",
//                GalleryItem = "",
//                Hero = "",
//                LanguageLinkItem = "",
//                LanguageLinks = "",
//                LiveChat = "",
//                Map = "{3BEC00F6-87F0-4B4A-9107-E2FB0EE85720}",
//                MenuLinks = "",
//                PageItems = "",
//                ProgressionRoutes = "",
//                RelatedLinks = "{8EC6BC1D-C1EE-4C30-95E5-AAE5E0C9BB9B}",
//                RelatedLinksWithSections = "{24CCCB08-BCA2-413A-A724-A0FFC22A01D0}",
//                ScriptSnippet = "",
//                SidebarBoxes = "{4D7ACF5F-89FD-4367-AC85-8BBA093C950D}",
//                SocialMediaContainer = "{96D66E0F-3F77-4FEE-BB4F-E933C9E7905D}",
//                SocialMediaLinks = "{CD005425-DF5E-4813-BE2E-2FC084A87119}",
//                Tab = "{4865DB5E-535D-4624-BD5D-62677CA90A83}",
//                TabContainer = "{771119FF-2123-49C0-8772-5D5A0B96030A}",
//                Testimonial = "{5F5E1742-662E-4400-AFE0-2584B3190374}",
//                Video = "{21075F0D-9F89-46CC-A5F2-5BB99473E6CF}",
//                Widget = "{3FEF07D4-0857-4548-8B3E-C3E8A81026DF}"
//            };
//        }
//    }
//}
