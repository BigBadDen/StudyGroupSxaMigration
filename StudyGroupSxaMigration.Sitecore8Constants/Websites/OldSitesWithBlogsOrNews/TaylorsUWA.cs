using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.Sitecore8Constants.Websites.OldSitesWithBlogsOrNews
{
    public class TaylorsUWA : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public TaylorsUWA()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Taylors UWA/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/UWA";
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
                HomePage = "{562478EC-975F-42F7-8129-7CF3C9640F8C}",
                HubPage = "{B87C7DD1-621A-4D29-94E7-84523B5EB628}",
                ContentPage = "{336A0103-791A-4105-9D72-9A8A9333C6BA}",
                BlogEntryPage = "{C6FBBBD0-3799-4BB1-90F5-3E3053F88726}",
                BlogCategoryPage = "{AD4D6A87-5F83-4B74-9BC0-A2604D399598}",
                BlogHomePage = "{E83D68EF-0A57-457E-955E-9FAB1422336D}",
                NewsArticlePage = "{CF55EDC5-A57B-4D07-BAB2-A5B5E4859F3C}",
                NewsListingPage = "{D261F76B-8812-4411-B38A-8F446AB5312D}",
                SearchPage = "{A6CA7A30-C857-4136-9AA5-73E737B01B5F}",
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
                Accordions = $"{sharedItemPath}/Accordians",
                ButtonGroups = $"{sharedItemPath}/Call to Action Panels",
                Carousels = $"{sharedItemPath}/Carousels",
                Galleries = $"{sharedItemPath}/Gallery",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Maps = $"{sharedItemPath}/Maps",
                RelatedLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinks}",
                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
                ScriptSnippet = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ScriptSnippet}",
                Tabs = $"{sharedItemPath}/Tabbed Content",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
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
                AccordionItem = "{168ADFAA-BB7B-437F-ABFE-59953D1F23F2}",
                AccordionContainer = "{65859E54-E617-446B-AD52-444B2FD72D12}",
                ButtonGroupContainer = "{F0F365AF-096C-4DCC-B786-00E5F4EE98AF}",
                CarouselContainer = "{FA64353F-14A1-4ABA-AE49-0AACE224A108}",
                CarouselSlide = "{3A68EC27-EA41-4846-B58D-CF66279E76FD}",
                ContentBox = "",
                CTA = "{8C6E3D17-F7FE-42F8-BF3C-721881570739}",
                GalleryContainer = "",
                GalleryItem = "{183E20F9-3E98-4B5F-8C0F-28B99EDF1EC9}",
                Hero = "",
                LanguageLinkItem = "",
                LanguageLinks = "",
                LiveChat = "",
                Map = "{8E59BC6A-2EEB-45CE-93DC-79FA72094FDF}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
                SidebarBoxes = "",
                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
                Tab = "{4B12DAFF-2867-4728-A54A-6F6809D098D3}",
                TabContainer = "{C03C9BD6-3092-4203-9D6E-78F0DBC3A9A2}",
                Testimonial = "{5F5E1742-662E-4400-AFE0-2584B3190374}",
                Video = "{A4A9EDE0-5574-44A9-AF7F-A5CE0CEB9BF5}"
            };
        }
    }
}
