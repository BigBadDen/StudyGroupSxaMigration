using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.Sitecore8Constants.Websites.OldSitesWithBlogsOrNews
{
    public class JamesMadisonUniversity : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public JamesMadisonUniversity()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/James Madison University/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/JMU";
        }

        /// <summary>
        /// The names of sub-folders under "Page Items" folder. If default folder names are used e.g. "Accordions" etc.,
        /// just return a new PageDataItemSubFolders instance without setting any values. Otherwise, return a new PageDataItemSubFolders 
        /// object with the correct values for the folder names
        /// </summary>
        /// <returns></returns>
        private PageDataItemSubFolders SetPageItemSubFolders()
        {
            return new PageDataItemSubFolders();
        }

        /// <summary>
        /// Template ids for the main page templates. Only return values for the pages that are used for the site
        /// </summary>
        /// <returns></returns>
        private PageTemplates SetPageTemplates()
        {
            return new PageTemplates()
            {
                HomePage = "{1A0E16E7-0421-4D42-99F7-2B7C115B8D1D}",
                HubPage = "{5076BCA8-A8DF-49EB-ABBD-A3748BFE5BAD}",
                BlogEntryPage = "{4B7F0CF6-3A6F-4053-B73F-E2B55FA6E675}",
                BlogCategoryPage = "{EFFB9D9B-9326-4775-A5CC-83574B405316}",
                BlogHomePage = "{1BC65F24-B6F7-41C7-99FB-7F7064F101F2}",
                SearchPage = "{CF9E0B6D-84E1-4962-A57D-FDB521E8A3B4}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}"
            };
        }

        /// <summary>
        /// Set a value for each shared item path. Defaults are provided in the SharedItemDefaultFolderNames constants, but note that some sites 
        /// use slightly different naming conventions 
        /// Also, many sites do not contain all folders below; only set the folder names if they exist in the Sitecore 8 website
        /// </summary>
        /// <returns></returns>
        private SharedItemPaths SetSharedItemsPaths()
        {
            string sharedItemPath = $"{RootPath}{Sitecore8Paths.SharedItemFolderName}";

            return new SharedItemPaths(sharedItemPath)
            {
                FolderPath = sharedItemPath,
                Accordions = $"{sharedItemPath}/Accordions",
                ButtonGroups = $"{sharedItemPath}/Call to Action Panels",
                Carousels = $"{sharedItemPath}/Carousels",
                Galleries = $"{sharedItemPath}/Galleries",
                Languages = $"{sharedItemPath}/Language Links",
                Maps = $"{sharedItemPath}/Maps",
                RelatedLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinks}",
                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
                ScriptSnippet = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ScriptSnippet}",
                Testimonials = $"{sharedItemPath}/Testimonials",
                Videos = $"{sharedItemPath}/Videos",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                SocialMedia = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SocialMedia}"
            };
        }

        /// <summary>
        /// Ids of templates used by the website
        /// </summary>
        /// <returns></returns>
        private WebsiteTemplates SetTemplateIds()
        {
            return new WebsiteTemplates()
            {
                AccordionItem = "{2FD5B353-EB6F-42A3-9ECC-B95CC464BC80}",
                AccordionContainer = "{40278432-E6A4-4F96-9BA7-71B93D150865}",
                ButtonGroupContainer = "{1CB3819D-6A1E-4EA4-8484-AEEFE54F428D}",
                CarouselContainer = "",
                CarouselSlide = "{E002AAB8-63EC-4B25-8E25-7335C1BC0209}",
                ContentBox = "{790ACFC3-199A-4581-8DB9-31ED6B0C98C3}",
                CTA = "{1629071B-7914-4713-9E3F-E1DE1B2EE7BA}",
                GalleryContainer = "{4D2D183D-E322-40B7-B3CA-224027CDB144}",
                GalleryItem = "{57B6B69E-9D61-4496-99FA-90E5C7F006B1}",
                Hero = "{A572E796-53B5-4F6E-B4B6-7220DC2FA1E3}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{F92C3D98-C84F-4A6B-B979-B9690D859E74}",
                MenuLinks = "",
                PageItems = "{4DA435B0-642B-439C-AEE4-66AF7425D2C8}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
                SidebarBoxes = "{7AEE771F-1440-4B1B-89BD-27BDA33564FE}",
                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
                Tab = "{B2A8E0CE-F3C0-4A40-8924-864A00CE988C}",
                TabContainer = "{C7DD4AC8-F1CD-487A-BF78-3F408FB2B911}",
                Testimonial = "{5F5E1742-662E-4400-AFE0-2584B3190374}",
                Video = "{25FFA46A-1D5A-45CC-B61E-C54A091A1282}",
                Widgets = new List<string> { "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}" }
            };
        }
    }
}
