//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class Aberdeen : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public Aberdeen()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/Aberdeen/Home/LP/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Landing Page";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/GlobalLandingPages/Images/Aberdeen";
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
//                HomePage = "{05590B47-38D6-451B-B080-43FDC654EFF1}",
//                LandingPage = "{672D235E-A259-41A3-8AD1-756D893592CF}",
//                ThanksPage = "{596ABC77-BC16-41FF-811D-907346AE1AD3}"
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
//                Accordions = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Accordions}",
//                ButtonGroups = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ButtonGroups}",
//                Carousels = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Carousels}",
//                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
//                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
//                HeroContent = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeroContent}",
//                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
//                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
//                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
//                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
//                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
//                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
//                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
//                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
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
//                CarouselContainer = "{2A499AA1-F954-4671-A4E0-4CD15DD7B215}",
//                CarouselSlide = "{6EF9DE37-962B-40FE-AC5E-E285B25FA724}",
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
//                Video = "{8631CF73-90C1-4D07-AA2A-F4646F418BAA}",
//                Widget = "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}"
//            };
//        }
//    }
//}
