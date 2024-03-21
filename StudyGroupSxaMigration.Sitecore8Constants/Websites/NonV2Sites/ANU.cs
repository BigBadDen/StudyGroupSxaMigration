//using StudyGroupSxaMigration.Sitecore8Constants.Constants;
//using StudyGroupSxaMigration.SitecoreConstants;

//namespace StudyGroupSxaMigration.SitecoreConstants.Websites
//{
//    public class ANU : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
//    {
//        public ANU()
//        {
//            RootPath = $"{Sitecore8Paths.IcsPath}/ANU College/";
//            WebsiteTemplateIds = SetTemplateIds();
//            SharedItemFolderPaths = SetSharedItemsPaths();
//            PageTemplates = SetPageTemplates();
//            PageItemSubFolders = SetPageItemSubFolders();
//            HomePagePath = $"{RootPath}Home";
//            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/ANU";
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
//                HomePage = "{DC3CB5D8-B95C-401A-BCA6-279643D88C1C}",
//                HubPage = "{42A7EC25-5F10-4A91-A2BA-C3D094B61867}",
//                ContentPage = "{FE0A21BC-E387-42AE-AA8D-F2A26701307D}",
//                FormPage = "{401C7A15-67C2-49A3-BA8F-61B362D9EBC3}",
//                SearchPage = "{54A06548-8F11-4B42-9FDD-E6C28577D9EE}",
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
//                ContentBoxes = $"{sharedItemPath}/Homepage Content Boxes",
//                Maps = $"{sharedItemPath}/Maps",
//                RelatedLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinks}",
//                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
//                ScriptSnippet = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ScriptSnippet}",
//                Testimonials = $"{sharedItemPath}/Testimonials",
//                Widgets = $"{sharedItemPath}/Widgets",
//                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
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
//                CarouselSlide = "{3A68EC27-EA41-4846-B58D-CF66279E76FD}",
//                ContentBox = "{031336C4-A1A3-440B-AFED-85549D7CE808}",
//                CTA = "",
//                GalleryContainer = "{73B494C4-8A59-4125-B4F6-272BDFC9E6FE}",
//                GalleryItem = "{938ED6F2-76A0-4BCB-82BC-308DD1188621}",
//                Hero = "{A572E796-53B5-4F6E-B4B6-7220DC2FA1E3}",
//                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
//                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
//                LiveChat = "",
//                Map = "{5232EA98-57D4-46C7-AA57-040112924A79}",
//                MenuLinks = "",
//                PageItems = "{4DA435B0-642B-439C-AEE4-66AF7425D2C8}",
//                ProgressionRoutes = "",
//                RelatedLinks = "",
//                RelatedLinksWithSections = "",
//                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
//                SidebarBoxes = "",
//                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
//                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
//                Tab = "{B2A8E0CE-F3C0-4A40-8924-864A00CE988C}",
//                TabContainer = "{C7DD4AC8-F1CD-487A-BF78-3F408FB2B911}",
//                Testimonial = "{5F5E1742-662E-4400-AFE0-2584B3190374}",
//                Video = "{8631CF73-90C1-4D07-AA2A-F4646F418BAA}",
//                Widget = "{AF441934-A0AE-4EFB-8ECD-2EC97229A661}"
//            };
//        }
//    }
//}
