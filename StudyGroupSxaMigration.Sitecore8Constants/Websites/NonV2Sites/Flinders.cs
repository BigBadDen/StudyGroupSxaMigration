//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class Flinders : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public Flinders()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/Flinders/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Flinders";
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
//                HomePage = "{18DD3BEF-531E-4629-BFDF-C6516F0B6832}",
//                HubPage = "{16492FB6-A8AD-4B03-AA71-14F373667067}",
//                ContentPage = "{C17150A7-7787-435D-8C39-6EBD699DFF74}",
//                ProgrammePage = "{4FB5DDCE-0927-4340-A586-886FCAB611EF}",
//                SearchPage = "{35C2ACB0-9BA7-481C-AA6F-406A5D949FB9}",
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
//                Accordions = $"{sharedItemPath}/Accordions",
//                Carousels = $"{sharedItemPath}/Carousels",
//                ContentBoxes = $"{sharedItemPath}/Homepage Content Boxes",
//                Languages = $"{sharedItemPath}/Language Links",
//                Maps = $"{sharedItemPath}/Maps",
//                RelatedLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinks}",
//                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
//                ScriptSnippet = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ScriptSnippet}",
//                Testimonials = $"{sharedItemPath}/Testimonials",
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
//                AccordionItem = "{02B93F8C-AC67-4FAE-AB0C-0D385A79B799}",
//                AccordionContainer = "{8B40CAB4-D805-4025-9CAA-08C4F2F5F7E8}",
//                ButtonGroupContainer = "",
//                CarouselContainer = "{FA64353F-14A1-4ABA-AE49-0AACE224A108}",
//                CarouselSlide = "{3A68EC27-EA41-4846-B58D-CF66279E76FD}",
//                ContentBox = "{F81B1F37-4725-412C-848B-64F026A1EDF5}",
//                CTA = "",
//                GalleryContainer = "",
//                GalleryItem = "",
//                Hero = "",
//                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
//                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
//                LiveChat = "",
//                Map = "{8E59BC6A-2EEB-45CE-93DC-79FA72094FDF}",
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
//                Video = "{A4A9EDE0-5574-44A9-AF7F-A5CE0CEB9BF5}",
//                Widget = ""
//            };
//        }
//    }
//}
