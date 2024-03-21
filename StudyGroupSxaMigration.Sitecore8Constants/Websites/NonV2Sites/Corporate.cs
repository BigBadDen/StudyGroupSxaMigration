//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class Corporate : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public Corporate()
//        {
//            RootPath = "/sitecore/content/Corporate/";
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
//                HomePage = "{0B0C1899-BB0C-435C-968D-4ABA871B65A3}",
//                LandingPage = "{672D235E-A259-41A3-8AD1-756D893592CF}",
//                ThanksPage = "{596ABC77-BC16-41FF-811D-907346AE1AD3}",
//                FormPage = "{B9415E48-A525-4F36-AF21-BAB2DC1D6510}",
//                ContentPage = "{93C68DB6-DB14-4D27-8ADB-647157294791}",
//                CallBackLandingPage = "{5D79575B-B346-47BF-AAA7-C0E6F671AB05}"
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
//            string sharedItemPath = $"{RootPath}Shared";

//            return new SharedItemPaths(sharedItemPath)
//            {
//                FolderPath = sharedItemPath,
//                Carousels = $"{sharedItemPath}/Carousels",
//                Testimonials = $"{sharedItemPath}/Testimonials",
//                Videos = $"{sharedItemPath}/Videos",
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
//                CarouselContainer = "{2C005A36-AAE2-45DC-9F59-8C8E19B6174B}",
//                CarouselSlide = "{CA8C031D-B8E5-4546-8CE7-01445011A14C}",
//                ContentBox = "{031336C4-A1A3-440B-AFED-85549D7CE808}",
//                CTA = "",
//                GalleryContainer = "{73B494C4-8A59-4125-B4F6-272BDFC9E6FE}",
//                GalleryItem = "{938ED6F2-76A0-4BCB-82BC-308DD1188621}",
//                Hero = "{A572E796-53B5-4F6E-B4B6-7220DC2FA1E3}",
//                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
//                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
//                LiveChat = "",
//                Map = "{5232EA98-57D4-46C7-AA57-040112924A79}",
//                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
//                PageItems = "{4DA435B0-642B-439C-AEE4-66AF7425D2C8}",
//                ProgressionRoutes = "",
//                RelatedLinks = "",
//                RelatedLinksWithSections = "",
//                ScriptSnippet = "",
//                SidebarBoxes = "",
//                SocialMediaContainer = "{9467AA9F-7D44-4103-B563-5F65941E63B7}",
//                SocialMediaLinks = "{694A4390-C276-40E7-8A52-16FB0F775DB6}",
//                Tab = "{B2A8E0CE-F3C0-4A40-8924-864A00CE988C}",
//                TabContainer = "",
//                Testimonial = "{7344812D-1C4D-4614-B908-63667FBEEEA4}",
//                Video = "{D9B52EEB-B453-48C5-98E4-4711CC8FAD2F}",
//                Widget = "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}"
//            };
//        }
//    }
//}
