//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class HeriotWatt : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public HeriotWatt()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/Heriot Watt/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Heriot Watt";
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
//                HomePage = "{850F4316-0A93-4CE1-B00D-EC7F1E360C36}",
//                HubPage = "{049AB72E-E7A8-46A2-8F3B-0F40A13845BC}",
//                ContentPage = "{A1EDCE85-B0A9-4792-BB49-AEABCB6AF6BD}",
//                FormPage = "{768CDB9C-2078-4E33-8C1C-956D7B967B0D}",
//                SearchPage = "{0014F4E7-8A85-4C6A-AECE-42398A4A49FD}"
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
//                Carousels = $"{sharedItemPath}/Carousels",
//                Maps = $"{sharedItemPath}/Maps",
//                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
//                RelatedLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinks}",
//                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
//                Testimonials = $"{sharedItemPath}/Testimonials",
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
//                ContentBox = "",
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
//                ProgressionRoutes = "{343197CA-2C64-45DD-82AC-FEAAF7284AC7}",
//                RelatedLinks = "{8EC6BC1D-C1EE-4C30-95E5-AAE5E0C9BB9B}",
//                RelatedLinksWithSections = "{24CCCB08-BCA2-413A-A724-A0FFC22A01D0}",
//                ScriptSnippet = "",
//                SidebarBoxes = "{4D7ACF5F-89FD-4367-AC85-8BBA093C950D}",
//                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
//                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
//                Tab = "",
//                TabContainer = "",
//                Testimonial = "",
//                Video = "",
//                Widget = ""
//            };
//        }
//    }
//}
