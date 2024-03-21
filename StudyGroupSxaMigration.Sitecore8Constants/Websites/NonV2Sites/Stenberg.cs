//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class Stenberg : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public Stenberg()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/Stenberg/Home/LP/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Landing Page";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/GlobalLandingPages/Images/Stenberg";
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
//                HomePage = "{59D5E46E-306E-4BF1-81DD-63D13CD68AAF}",
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
//                AccordionItem = "",
//                AccordionContainer = "",
//                ButtonGroupContainer = "",
//                CarouselContainer = "",
//                CarouselSlide = "",
//                ContentBox = "",
//                CTA = "",
//                GalleryContainer = "",
//                GalleryItem = "",
//                Hero = "",
//                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
//                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
//                LiveChat = "",
//                Map = "",
//                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
//                PageItems = "{4DA435B0-642B-439C-AEE4-66AF7425D2C8}",
//                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
//                RelatedLinks = "",
//                RelatedLinksWithSections = "",
//                ScriptSnippet = "",
//                SidebarBoxes = "",
//                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
//                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
//                Tab = "",
//                TabContainer = "",
//                Testimonial = "",
//                Video = "",
//                Widget = ""
//            };
//        }
//    }
//}
