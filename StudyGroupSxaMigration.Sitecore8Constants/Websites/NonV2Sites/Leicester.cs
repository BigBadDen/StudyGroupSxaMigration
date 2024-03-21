//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class Leicester : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public Leicester()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/Leicester v2/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Leicester";
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
//                HomePage = "{6EAB0376-C362-4254-8323-BB24A0A117F0}",
//                HubPage = "{3DD90883-1B33-4278-BF2B-A3C6D43358C9}",
//                InternalPage = "{BB6D97DC-1842-49E3-B048-D492870D3FB3}",
//                NewsArticlePage = "{49112C24-1671-4574-B6BD-6FEAE1BA98B3}",
//                NewsListingPage = "{B8D9E256-1DA2-4E10-910D-ED9FFE8B23C6}",
//                ProgrammePage = "{C09DA892-3A57-4171-8B36-3C722472A1B6}",
//                SearchPage = "{F5902DA2-5963-4198-9F83-7A72BAF7DA31}",
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
//                ButtonGroups = $"{sharedItemPath}/CTAs",
//                ContentBoxes = $"{sharedItemPath}/Content Boxes",
//                Galleries = $"{sharedItemPath}/Accommodation Gallery",
//                Languages = $"{sharedItemPath}/Language Links",
//                Maps = $"{sharedItemPath}/Maps",
//                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
//                Testimonials = $"{sharedItemPath}/Testimonials",
//                Videos = $"{sharedItemPath}/Videos"
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
//                AccordionItem = "{9D4B0083-8898-44F3-8EC5-27427DEB7A86}",
//                AccordionContainer = "{03DAEB81-68EA-4D3F-A352-6DDA0E42C54F}",
//                ButtonGroupContainer = "{218642B8-2AD7-46C7-BF4A-BF29DA08473B}",
//                CarouselContainer = "",
//                CarouselSlide = "",
//                ContentBox = "{A3C2B313-EC58-48DB-9CA7-D12C8A8A4AA6}",
//                CTA = "{6AFF3BDE-74C7-4D09-A2B8-A1841E8F591E}",
//                GalleryContainer = "{5B560CEA-B2F1-46DF-89CF-FCF90C4C2F37}",
//                GalleryItem = "{0C75FEF2-AEB0-48F3-828D-8E6CEE697C55}",
//                Hero = "",
//                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
//                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
//                LiveChat = "",
//                Map = "{FEFDC4BC-C20A-489D-9834-F8193FA3F625}",
//                MenuLinks = "",
//                PageItems = "",
//                ProgressionRoutes = "{343197CA-2C64-45DD-82AC-FEAAF7284AC7}",
//                RelatedLinks = "",
//                RelatedLinksWithSections = "",
//                ScriptSnippet = "",
//                SidebarBoxes = "",
//                SocialMediaContainer = "",
//                SocialMediaLinks = "",
//                Tab = "",
//                TabContainer = "",
//                Testimonial = "{708F30B3-E665-43C9-A3BF-060E06DAB22F}",
//                Video = "{D109E79C-6DA0-49F1-AB7D-6B770ED4BD7B}",
//                Widget = ""
//            };
//        }
//    }
//}
