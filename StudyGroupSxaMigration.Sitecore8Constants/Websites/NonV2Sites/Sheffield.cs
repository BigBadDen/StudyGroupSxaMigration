//using System;
//using System.Collections.Generic;
//using System.Text;
//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class Sheffield : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public Sheffield()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/Sheffield/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Sheffield";
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
//                HomePage = "{D6DF066E-AE65-4236-BFCE-F0068816D654}",
//                HubPage = "{AD396951-5AE2-4D5D-830B-879B7B434003}",
//                ContentPage = "{AFCDFB76-58EC-4B4B-8718-A9CF905B8647}",
//                BlogEntryPage = "{AA2EE336-3289-408F-B89A-BDA0FF614717}",
//                BlogCategoryPage = "{8092FB30-16D8-4CD6-82AE-A705D1D0B00C}",
//                BlogPage = "{5CA2F847-253D-4819-A33F-349492516134}",
//                NewsArticlePage = "{265B9EF0-7D36-436E-8FAD-320E4D1FC76D}",
//                NewsListingPage = "{E6A0358F-E126-42DC-A41C-E88F15D1553C}",
//                LandingPage = "{672D235E-A259-41A3-8AD1-756D893592CF}",
//                ThanksPage = "{596ABC77-BC16-41FF-811D-907346AE1AD3}",
//                FormPage = "{252CE94A-03DC-44B7-8905-568287C46FAC}",
//                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
//                SearchPage = "{40870235-715C-4197-ADAF-B8B87E281D98}",
//                DirectApplicationForm = "{4C72F9F7-450A-411E-AB5D-36BB720F968D}"
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
//                Carousels = $"{sharedItemPath}/Carousels",
//                ContentBoxes = $"{sharedItemPath}/Content Highlights",
//                Galleries = $"{sharedItemPath}/Gallery",
//                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
//                LiveChat = $"{sharedItemPath}/Live Agent",
//                Maps = $"{sharedItemPath}/Maps",
//                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
//                ScriptSnippet = $"{sharedItemPath}/ScriptSnippet",
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
//                AccordionItem = "{55F1EAC4-855A-4C11-BFCD-F362D034A3DF}",
//                AccordionContainer = "{520545F6-0E28-4556-8500-C6E84BF7A28D}",
//                ButtonGroupContainer = "{85C47BD0-826F-4452-831D-5BCED58B9876}",
//                CarouselContainer = "{71036AFB-F25D-41AD-8800-1681ECD479EC}",
//                CarouselSlide = "{607CA24F-FA5C-4E58-A04F-BFC7DBECFA10}",
//                ContentBox = "{EAD39C26-C54E-4AA9-B7A9-BF36A1DFD479}",
//                CTA = "{419FE956-2208-4DAA-BB14-B8A29C2E808E}",
//                GalleryContainer = "",
//                GalleryItem = "{183E20F9-3E98-4B5F-8C0F-28B99EDF1EC9}",
//                Hero = "",
//                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
//                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
//                LiveChat = "{41DCEC4D-C4D5-4811-BACC-1776E3FDDC4B}",
//                Map = "{1FE0DC96-7AF5-4F19-9005-5F7C7404649E}",
//                MenuLinks = "",
//                PageItems = "{4DA435B0-642B-439C-AEE4-66AF7425D2C8}",
//                ProgressionRoutes = "{343197CA-2C64-45DD-82AC-FEAAF7284AC7}",
//                RelatedLinks = "",
//                RelatedLinksWithSections = "",
//                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
//                SidebarBoxes = "",
//                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
//                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
//                Tab = "{B2A8E0CE-F3C0-4A40-8924-864A00CE988C}",
//                TabContainer = "{C7DD4AC8-F1CD-487A-BF78-3F408FB2B911}",
//                Testimonial = "{8CAF0ACB-B0F0-4D96-859D-8F841D957EEA}",
//                Video = "{01047515-6373-4CA9-BA5F-48E3C72FC794}",
//                Widget = ""
//            };
//        }
//    }
//}
