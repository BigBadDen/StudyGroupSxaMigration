//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class LUMS : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public LUMS()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/LUMS/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Landing Page";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/LUMS";
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
//                HomePage = "{1C2F1892-37C4-4BAC-AAF4-6A32530025B2}",
//                ContentPage = "{CA000135-E7F7-4A27-8BE5-F01B26CFCA7A}"
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
//                ContentBoxes = $"{sharedItemPath}/Content",
//                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
//                ScriptSnippet = $"{sharedItemPath}/JS Snippets",
//                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
//                SocialMedia = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SocialMedia}"
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
//                ButtonGroupContainer = "",
//                CarouselContainer = "",
//                CarouselSlide = "",
//                ContentBox = "{BE829051-FD1D-4A33-8BA5-C0F4860574D0}",
//                CTA = "",
//                GalleryContainer = "",
//                GalleryItem = "",
//                Hero = "",
//                LanguageLinkItem = "",
//                LanguageLinks = "",
//                LiveChat = "",
//                Map = "",
//                MenuLinks = "",
//                PageItems = "",
//                ProgressionRoutes = "",
//                RelatedLinks = "",
//                RelatedLinksWithSections = "",
//                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
//                SidebarBoxes = "{4D7ACF5F-89FD-4367-AC85-8BBA093C950D}",
//                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
//                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
//                Tab = "",
//                TabContainer = "",
//                Testimonial = "{5F5E1742-662E-4400-AFE0-2584B3190374}",
//                Video = "",
//                Widget = ""
//            };
//        }
//    }
//}
