//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class Leeds : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public Leeds()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/Leeds University V2/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Leeds University V2";
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
//                HomePage = "{CC43DD2D-E478-4CA7-951B-DF21E2818462}",
//                InternalPage = "{26B45667-31CD-4203-922D-5CF750F9033A}",
//                NewsArticlePage = "{1C52D9DC-63DA-4BD9-BDD5-4B7D472B96B5}",
//                NewsListingPage = "{7480FCE8-3BD7-4BFE-91AF-72F42AEE5E2F}",
//                DirectApplicationForm = "{A80EB8C8-5EED-4B6E-9DE1-D1983C52D471}",
//                SearchPage = "{26B45667-31CD-4203-922D-5CF750F9033A}",
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
//            string sharedItemPath = $"{RootPath}Data Items";

//            return new SharedItemPaths(sharedItemPath)
//            {
//                FolderPath = sharedItemPath,
//                Accordions = $"{sharedItemPath}/Accordions",
//                ButtonGroups = $"{sharedItemPath}/ButtonGroups",
//                Carousels = $"{sharedItemPath}/Carousels",
//                ContentBoxes = $"{sharedItemPath}/Content Boxes",
//                Galleries = $"{sharedItemPath}/Galleries",
//                HeroContent = $"{sharedItemPath}/Hero",
//                Languages = $"{sharedItemPath}/Language Links",
//                Maps = $"{sharedItemPath}/Maps",
//                Tabs = $"{sharedItemPath}/Tabs",
//                Testimonials = $"{sharedItemPath}/Testimonials",
//                Videos = $"{sharedItemPath}/Videos",
//                Widgets = $"{sharedItemPath}/Widgets",
//                SharedComboMenus = $"{sharedItemPath}/Footer combo menu item",
//                SocialMedia = $"{RootPath}/Configuration/Links"
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
//                AccordionItem = "{CE715D04-0092-4817-A794-5F12BB31A5B6}",
//                AccordionContainer = "",
//                ButtonGroupContainer = "",
//                CarouselContainer = "",
//                CarouselSlide = "{3FBE9966-08B9-4F5D-80AF-A651A6E3C653}",
//                ContentBox = "{5B10DCDB-D3DB-4AA4-95D7-C50476709B8E}",
//                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
//                CTA = "{ABA2DE74-BCCF-480F-999B-64B66307D51E}",
//                GalleryContainer = "",
//                GalleryItem = "{B1C816A2-259E-4AAC-8528-80BC9A3389E3}",
//                Hero = "{4C3393AF-A356-482F-9234-4B02F28E7F80}",
//                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
//                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
//                LiveChat = "",
//                Map = "{5F98CF45-E144-4F41-9F6A-6D754E39734C}",
//                MenuLinks = "",
//                PageItems = "",
//                ProgressionRoutes = "",
//                RelatedLinks = "",
//                RelatedLinksWithSections = "",
//                ScriptSnippet = "",
//                SidebarBoxes = "",
//                SocialMediaContainer = "",
//                SocialMediaLinks = "",
//                Tab = "{AFDA5BA8-2715-4578-91A1-59C9EF91D7F7}",
//                TabContainer = "",
//                Testimonial = "{034F2368-2E00-4171-AA2B-8BDB4C6D092E}",
//                Video = "{6A464B7B-57CB-49E0-9E1A-96E210588503}",
//                Widget = "{97BD6DE8-2F95-4774-82F1-2191C2026892}"
//            };
//        }
//    }
//}
