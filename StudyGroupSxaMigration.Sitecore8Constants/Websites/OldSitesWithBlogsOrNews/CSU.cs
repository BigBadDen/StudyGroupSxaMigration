using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites.OldSitesWithBlogsOrNews
{
    public class CSU : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public CSU()
        {
            RootPath = "/sitecore/content/CSU/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/CSU";
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
                HomePage = "{E37EE7C8-2D36-4614-B049-C9FB10BE5FA0}",
                HubPage = "{43961C62-CEB9-4C92-BA2D-6E7A7E0F9244}",
                ContentPage = "{8D3A990A-F460-47C7-A1E5-ECD5E050B6A2}",
                NewsArticlePage = "{1C673942-E496-44DC-A4A2-57A679ED2014}",
                NewsListingPage = "{62C3B0C0-4126-47FB-9B0D-3B43AFA9DBCC}",
                SearchPage = "{89E776B3-4E66-451A-AF7D-86CA6C782CAF}",
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
            string sharedItemPath = $"{RootPath}Shared";

            return new SharedItemPaths(sharedItemPath)
            {
                FolderPath = sharedItemPath,
                Accordions = $"{sharedItemPath}/Accordion Main Content",
                ButtonGroups = $"{sharedItemPath}/Call To Action Buttons",
                Carousels = $"{sharedItemPath}/Carousels",
                ContentBoxes = $"{sharedItemPath}/Home Content Boxes",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                LiveChat = $"{sharedItemPath}/Live Agent",
                Maps = $"{sharedItemPath}/Side Column/Maps",
                ScriptSnippet = $"{sharedItemPath}/Script Snippet Folder",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                Testimonials = $"{sharedItemPath}/Side Column/Testimonials",
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
                AccordionItem = "{97DB2EA6-A27F-4BC3-AE1B-F20FB0006208}",
                AccordionContainer = "{D3CE0A7B-FF03-4222-85A7-E822B0D1BE2C}",
                ButtonGroupContainer = "{3501DFAC-7CE4-4139-AEDE-F76475DDF24F}",
                CarouselContainer = "{2D8F0CF7-8120-4048-8544-C12247E8BE8F}",
                CarouselSlide = "{EEEB93F1-923D-40A6-A405-8A1048840B1C}",
                ContentBox = "{9980C3D2-4F05-4249-818F-A322C9772EA1}",
                CTA = "{AEA965BE-4515-4679-B4A0-5E778730AAFA}",
                GalleryContainer = "",
                GalleryItem = "",
                Hero = "",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "{D74A351F-2A06-499F-BDAB-9EAA01A14486}",
                Map = "{4AA1E500-33B1-4ADB-81C4-83C5996B0547}",
                MenuLinks = "",
                PageItems = "",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
                SidebarBoxes = "",
                SocialMediaContainer = "",
                SocialMediaLinks = "{2A3538CF-FAC0-4741-8B74-C47EAF8374D1}",
                Tab = "",
                TabContainer = "",
                Testimonial = "{B3874631-B0DB-45FF-8758-E51C932DFE5A}",
                Video = "{2FD141EA-4C73-4D0A-BBBB-3667E1F38433}"
            };
        }
    }
}
