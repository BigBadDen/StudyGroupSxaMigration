//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class Lincoln : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public Lincoln()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/Lincoln ISC/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Lincoln ISC";
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
//                HomePage = "{BC13C07F-493F-4A30-94B4-C1D9AEE0C930}",
//                HubPage = "{8C436C48-554D-4F1B-8AF4-90BE8E19E1A4}",
//                ContentPage = "{E6D6629C-0C05-450B-9695-F7B5F70C2B86}",
//                NewsArticlePage = "{376AF93C-C27E-4002-AEE7-CFE1EBAB64E8}",
//                NewsListingPage = "{C2569899-1568-4EC3-9358-05E7724436EB}",
//                DirectApplicationForm = "{F3B2B20A-FB62-4710-9C2B-7E8D7D219D97}",
//                FormPage = "{694FFA9D-ED07-48A6-8E47-BB9A76FFF1AC}",
//                SearchPage = "{1C2C5C42-8E4F-4AF0-9457-37C3586B0446}",
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
//                Carousels = $"{sharedItemPath}/Carousels",
//                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
//                LiveChat = $"{sharedItemPath}/Live Agent",
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
//                AccordionItem = "{FD8E0696-04B5-4DE6-A5AA-C5B5C6783B99}",
//                AccordionContainer = "{F7405B2A-32A6-4781-B8F4-B47A10B89235}",
//                ButtonGroupContainer = "",
//                CarouselContainer = "{FA64353F-14A1-4ABA-AE49-0AACE224A108}",
//                CarouselSlide = "{43F78EAD-AE71-4A94-A5FD-A8B6B57D2241}",
//                ContentBox = "{031336C4-A1A3-440B-AFED-85549D7CE808}",
//                CTA = "",
//                GalleryContainer = "",
//                GalleryItem = "{183E20F9-3E98-4B5F-8C0F-28B99EDF1EC9}",
//                Hero = "{A572E796-53B5-4F6E-B4B6-7220DC2FA1E3}",
//                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
//                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
//                LiveChat = "{D74A351F-2A06-499F-BDAB-9EAA01A14486}",
//                Map = "{3BEC00F6-87F0-4B4A-9107-E2FB0EE85720}",
//                MenuLinks = "",
//                PageItems = "{4DA435B0-642B-439C-AEE4-66AF7425D2C8}",
//                ProgressionRoutes = "{343197CA-2C64-45DD-82AC-FEAAF7284AC7}",
//                RelatedLinks = "{8EC6BC1D-C1EE-4C30-95E5-AAE5E0C9BB9B}",
//                RelatedLinksWithSections = "{24CCCB08-BCA2-413A-A724-A0FFC22A01D0}",
//                ScriptSnippet = "",
//                SidebarBoxes = "{4D7ACF5F-89FD-4367-AC85-8BBA093C950D}",
//                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
//                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
//                Tab = "{B2A8E0CE-F3C0-4A40-8924-864A00CE988C}",
//                TabContainer = "{C7DD4AC8-F1CD-487A-BF78-3F408FB2B911}",
//                Testimonial = "{5F5E1742-662E-4400-AFE0-2584B3190374}",
//                Video = "{8631CF73-90C1-4D07-AA2A-F4646F418BAA}",
//                Widget = "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}"
//            };
//        }
//    }
//}
