using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites.OldSitesWithBlogsOrNews
{
    public class Dublin : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public Dublin()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Dublin/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Dublin";
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
                HomePage = "{068A1E3E-F5D2-49F5-9FBB-129E52C7A8A6}",
                HubPage = "{34E3FB1D-0C09-489F-B3ED-5F0CCAF6F78B}",
                ContentPage = "{8D68F1EC-A4E5-40AC-A6F7-EF85E109ED50}",
                NewsArticlePage = "{91466BC6-A407-45F0-8F68-C6BF8AFA4016}",
                ProgrammePage = "{1F99E11A-014D-4264-9C02-8C1BE70D61BC}",
                SearchPage = "{A914CFD2-8E66-491C-B201-CA1C1F48EDA8}",
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
                Carousels = $"{sharedItemPath}/Carousels",
                Galleries = $"{sharedItemPath}/Gallery",
                Maps = $"{sharedItemPath}/Maps",
                SidebarBoxes = $"{sharedItemPath}/Sidebar Boxes",
                Testimonials = $"{sharedItemPath}/Testimonials",
                Videos = $"{sharedItemPath}/Videos",
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
                AccordionItem = "",
                AccordionContainer = "",
                ButtonGroupContainer = "",
                CarouselContainer = "{FA64353F-14A1-4ABA-AE49-0AACE224A108}",
                CarouselSlide = "{089F2E69-8E6B-4BE3-9E88-E8899951EF00}",
                ContentBox = "",
                CTA = "",
                GalleryContainer = "",
                GalleryItem = "{E8C878F9-791E-41D6-9EEA-6CEEA1BF1348}",
                Hero = "",
                LanguageLinkItem = "{F2150E9C-EBC6-4193-8179-5778A5A14E9A}",
                LanguageLinks = "{67EBD623-78C6-46FC-A55B-C00A07F9A335}",
                LiveChat = "",
                Map = "{8E59BC6A-2EEB-45CE-93DC-79FA72094FDF}",
                MenuLinks = "",
                PageItems = "",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "{4D7ACF5F-89FD-4367-AC85-8BBA093C950D}",
                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
                Tab = "",
                TabContainer = "",
                Testimonial = "{5F5E1742-662E-4400-AFE0-2584B3190374}",
                Video = "{A4A9EDE0-5574-44A9-AF7F-A5CE0CEB9BF5}"
            };
        }
    }
}
