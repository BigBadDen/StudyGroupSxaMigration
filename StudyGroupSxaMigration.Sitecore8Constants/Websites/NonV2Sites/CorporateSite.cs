//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class CorporateSite : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public CorporateSite()
//        {
//            RootPath = "/sitecore/content/Corporate Site/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/Corporate Site";
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
//                HomePage = "{0AA652C7-D6AF-4A12-95B0-F6B88954E812}",
//                HubPage = "{14AFCCB0-DB36-4FDE-BA6F-316D8A388577}",
//                ContentPage = "{16AD65CD-CC24-4CCC-A9D4-2A4373837B28}",
//                ProgrammePage = "{BE7617AC-9DD1-4A87-B950-09BD94E8BF38}",
//                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
//                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
//                NewsListingPage = "{46B3FEA7-0A4B-4D9C-93B3-AFB45199DA47}",
//                NewsArticlePage = "{52B062F7-44DA-4FFA-8E73-9A8E9A50E9D5}",
//                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
//                SearchPage = "{46B3FEA7-0A4B-4D9C-93B3-AFB45199DA47}"
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
//                ButtonGroups = $"{sharedItemPath}/Call To Actions",
//                Carousels = $"{sharedItemPath}/Carousel Items",
//                ContentBoxes = $"{sharedItemPath}/Content Box Folder",
//                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
//                Testimonials = $"{sharedItemPath}/Testimonials",
//                Videos = $"{sharedItemPath}/Videos",
//                ScriptSnippet = $"/sitecore/content/Corporate Site/Global/Script Snippet Folder"
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
//                CarouselSlide = "{9EAD5B80-DC81-48F9-8BBC-410D0CA39C68}",
//                ContentBox = "{95385F04-8E1F-4027-B739-1F0B7BFBD391}",
//                CTA = "{928C9BE2-CEDC-488A-973E-5D52FBF18A9A}",
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
//                RelatedLinks = "{F188D6C2-3008-42C7-B63C-A14A19561132}",
//                RelatedLinksWithSections = "",
//                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
//                SidebarBoxes = "{6BAFB2F5-1049-41D4-B837-F519C8E21144}",
//                SocialMediaContainer = "",
//                SocialMediaLinks = "",
//                Tab = "",
//                TabContainer = "",
//                Testimonial = "{3EDBCF0F-82D8-4CD0-9D13-DA29B5FFC31D}",
//                Video = "{D74DC65C-1BDE-4BB2-8520-E7A58E056672}",
//                Widget = ""
//            };
//        }
//    }
//}
