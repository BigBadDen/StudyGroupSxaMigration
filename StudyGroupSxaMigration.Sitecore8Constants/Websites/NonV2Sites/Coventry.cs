//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class Coventry : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public Coventry()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/Coventry/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Coventry";
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
//                HomePage = "{3BC99A3E-32B3-4B77-90CF-F86D21BD53B7}",
//                HubPage = "{FB01951E-EFD1-4BF1-8675-DE85048CD1A5}",
//                ContentPage = "{1EA84DFF-0952-48A2-847B-306AD77AE3DE}",
//                DirectApplicationForm = "{8431AA92-B4D0-4E5C-AAA6-EC7C21CA74E2}",
//                FormPage = "{D228824C-4775-4ACF-9B96-A7F35BC0C191}",
//                SearchPage = "{2D67F9E6-D3D4-41FC-80B0-25799D575568}",
//                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
//                ThanksPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}"
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
//                ButtonGroups = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ButtonGroups}",
//                Carousels = $"{sharedItemPath}/Carousels",
//                Maps = $"{sharedItemPath}/Maps",
//                RelatedLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinks}",
//                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
//                Videos = $"{sharedItemPath}/Videos",
//                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
//                SharedComboMenus = $"{sharedItemPath}/Combo Menu Items",
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
//                AccordionItem = "{FD8E0696-04B5-4DE6-A5AA-C5B5C6783B99}",
//                AccordionContainer = "{F7405B2A-32A6-4781-B8F4-B47A10B89235}",
//                ButtonGroupContainer = "{434EE3BC-C4F0-4A61-9576-657AE0642B18}",
//                CarouselContainer = "{2A499AA1-F954-4671-A4E0-4CD15DD7B215}",
//                CarouselSlide = "{6EF9DE37-962B-40FE-AC5E-E285B25FA724}",
//                ContentBox = "{031336C4-A1A3-440B-AFED-85549D7CE808}",
//                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
//                CTA = "{97F4787F-9405-48E7-AA28-828B51704EF9}",
//                GalleryContainer = "{73B494C4-8A59-4125-B4F6-272BDFC9E6FE}",
//                GalleryItem = "{938ED6F2-76A0-4BCB-82BC-308DD1188621}",
//                Hero = "{A572E796-53B5-4F6E-B4B6-7220DC2FA1E3}",
//                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
//                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
//                LiveChat = "",
//                Map = "{5232EA98-57D4-46C7-AA57-040112924A79}",
//                MenuLinks = "",
//                PageItems = "{4DA435B0-642B-439C-AEE4-66AF7425D2C8}",
//                ProgressionRoutes = "{343197CA-2C64-45DD-82AC-FEAAF7284AC7}",
//                RelatedLinks = "",
//                RelatedLinksWithSections = "",
//                ScriptSnippet = "",
//                SidebarBoxes = "",
//                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
//                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
//                Tab = "{B2A8E0CE-F3C0-4A40-8924-864A00CE988C}",
//                TabContainer = "{C7DD4AC8-F1CD-487A-BF78-3F408FB2B911}",
//                Testimonial = "{8CAF0ACB-B0F0-4D96-859D-8F841D957EEA}",
//                Video = "{8631CF73-90C1-4D07-AA2A-F4646F418BAA}",
//                Widget = "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}"
//            };
//        }
//    }
//}
