//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class UniversityofLaw : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public UniversityofLaw()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/University of Law/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Unversity of Law";
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
//                HomePage = "{C1CF4FD2-95E9-4504-917B-483CD8CCF7B3}",
//                HubPage = "{2A47DFDC-5EF9-4DE3-BA06-208A418DA576}",
//                ContentPage = "{FD2CC003-9223-4B66-864C-FAA9A71D036E}",
//                FormPage = "{660D5819-87F6-49EA-BF56-7EE02D489350}",
//                ProgrammePage = "{A454F38A-7CC6-4B90-836A-81064E44C0FA}",
//                SearchPage = "{AD5B5A26-6A38-4AE0-9930-8F1C71A831CC}"
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
//                Testimonials = $"{sharedItemPath}/Testimonials",
//                Videos = $"{sharedItemPath}/Videos",
//                SocialMedia = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SocialMedia}",
//                Widgets = $"{sharedItemPath}/Widgets"
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
//                ButtonGroupContainer = "{EA3C4EF2-35E1-4983-8D13-93B2973FBCA3}",
//                CarouselContainer = "{FA64353F-14A1-4ABA-AE49-0AACE224A108}",
//                CarouselSlide = "{3A68EC27-EA41-4846-B58D-CF66279E76FD}",
//                ContentBox = "",
//                CTA = "{775D351F-4DE1-4128-AFC7-8F08857EBDAE}",
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
//                ScriptSnippet = "",
//                SidebarBoxes = "",
//                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
//                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
//                Tab = "",
//                TabContainer = "",
//                Testimonial = "{98F6EF6E-7C3B-477C-BF35-38DD2B64CE6D}",
//                Video = "{28DDA4D7-CF38-4474-AF71-F6795339F11E}",
//                Widget = "{69D757FC-B216-4BB5-99C7-3E9375DB401B}"
//            };
//        }
//    }
//}
