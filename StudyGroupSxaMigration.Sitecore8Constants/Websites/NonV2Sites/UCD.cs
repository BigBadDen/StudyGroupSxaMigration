//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class UCD : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public UCD()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/UCD v2/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/UCD";
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
//                HomePage = "{6DD34B81-F27E-4AA3-9BEF-22984B51D6A2}",
//                NewsArticlePage = "{2FFA24B7-CC11-4C0D-8CFE-6C66B3365A47}",
//                NewsListingPage = "{AC17F30F-3982-4B04-A84A-511884B881FB}",
//                SearchPage = "{7EA0D09C-494F-44A1-B13B-1638C8F48290}",
//                ContentPage = "{BA284D2E-7707-43A8-BA54-DAE9AB154FAB}",
//                LandingPage = "{672D235E-A259-41A3-8AD1-756D893592CF}",
//                ThanksPage = "{596ABC77-BC16-41FF-811D-907346AE1AD3}",
//                DirectApplicationForm = "{269BCA97-7B5F-4AEA-8509-11BAAFEFFAD7}"
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
//                ButtonGroups = $"{sharedItemPath}/CallToAction",
//                ContentBoxes = $"{sharedItemPath}/ContentBoxes",
//                Galleries = $"{sharedItemPath}/Galleries",
//                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
//                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
//                Maps = $"{sharedItemPath}/Maps",
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
//                AccordionItem = "{4D260C87-5B69-4764-961B-3E947CA027D2}",
//                AccordionContainer = "",
//                ButtonGroupContainer = "{7871550F-7DD2-4122-855B-F854F33D44A1}",
//                CarouselContainer = "{2A499AA1-F954-4671-A4E0-4CD15DD7B215}",
//                CarouselSlide = "{6EF9DE37-962B-40FE-AC5E-E285B25FA724}",
//                ContentBox = "{578A8A8C-6B56-41A1-86CE-D8F56B37108A}",
//                CTA = "{069145A4-4AFD-45CD-B147-F70E0734A0DF}",
//                GalleryContainer = "{FDD18B00-F1C9-439F-B544-07AE9F434562}",
//                GalleryItem = "{F53A476A-BA5E-413E-A038-40837E4A5C50}",
//                Hero = "{A572E796-53B5-4F6E-B4B6-7220DC2FA1E3}",
//                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
//                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
//                LiveChat = "",
//                Map = "{11843DEF-02D1-41E6-B6AF-8078430D5EAA}",
//                MenuLinks = "",
//                PageItems = "{4DA435B0-642B-439C-AEE4-66AF7425D2C8}",
//                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
//                RelatedLinks = "",
//                RelatedLinksWithSections = "",
//                ScriptSnippet = "",
//                SidebarBoxes = "",
//                SocialMediaContainer = "{3D850D49-A9CF-4F45-AC94-0372408D4A13}",
//                SocialMediaLinks = "{1503C31C-8504-4104-A3C8-6A4A84594CBB}",
//                Tab = "{B2A8E0CE-F3C0-4A40-8924-864A00CE988C}",
//                TabContainer = "{C7DD4AC8-F1CD-487A-BF78-3F408FB2B911}",
//                Testimonial = "{8CAF0ACB-B0F0-4D96-859D-8F841D957EEA}",
//                Video = "{B5D76766-62EE-4B8A-8C54-2F48E4DEAE62}",
//                Widget = "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}"
//            };
//        }
//    }
//}
