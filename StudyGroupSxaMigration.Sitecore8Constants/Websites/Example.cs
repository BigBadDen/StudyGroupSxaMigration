
using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class Example : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public Example()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Example V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MiscellaneousSharedItemsFolders = SetMiscellaneousSharedItemsFolders();
        }

        /// <summary>
        /// The names of sub-folders under "Page Items" folder. If default folder names are used e.g. "Accordions" etc.,
        /// just return a new PageDataItemSubFolders instance without setting any values. Otherwise, return a new PageDataItemSubFolders 
        /// object with the correct values for the folder names
        /// </summary>
        /// <returns></returns>
        private PageDataItemSubFolders SetPageItemSubFolders()
        {
            // no need to set any values as just using defaults. 
            return new PageDataItemSubFolders();

            //return new PageDataItemSubFolders()
            //{
            //    ButtonGroups = "My Button Groups Custom Folder Name"
            //};
        }

        /// <summary>
        /// Template ids for the main page templates. Only return values for the pages that are used for the site
        /// </summary>
        /// <returns></returns>
        private PageTemplates SetPageTemplates()
        {
            return new PageTemplates()
            {
                HomePage = "",
                HubPage = "",
                InternalPage = "",
                BlogEntryPage = "",
                BlogHomePage = "",
                NewsArticlePage = "",
                NewsListingPage = ""
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
                Accordions = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Accordions}",
                ButtonGroups = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ButtonGroups}",
                Carousels = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Carousels}",
                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
                HeroContent = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeroContent}",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                LiveChat = $"{sharedItemPath}/{SharedItemDefaultFolderNames.LiveChat}",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                RelatedLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinks}",
                RelatedLinksWithSections = $"{sharedItemPath}/{SharedItemDefaultFolderNames.RelatedLinksWithSections}",
                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
                ScriptSnippet = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ScriptSnippet}",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
                SocialMedia = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SocialMedia}"
            };
        }

        private List<MiscellaneousSharedItemsFolders> SetMiscellaneousSharedItemsFolders()
        {
            string sharedItemPath = $"{RootPath}{Sitecore8Paths.SharedItemFolderName}";

            List<MiscellaneousSharedItemsFolders> miscSharedFolders = new List<MiscellaneousSharedItemsFolders>();
            miscSharedFolders.Add(new MiscellaneousSharedItemsFolders()
            {
                Sitecore8TemplateId = this.WebsiteTemplateIds.ContentBox,
                SharedFolderPath = $"{sharedItemPath}/Random Content Boxes",
                Sitecore9SharedFolderName = "Random Content Boxes"
            });

            return miscSharedFolders;
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
                CarouselContainer = "",
                CarouselSlide = "",
                ContentBox = "",
                CTA = "",
                GalleryContainer = "",
                GalleryItem = "",
                Hero = "",
                LanguageLinkItem = "",
                LanguageLinks = "",
                LiveChat = "",
                Map = "",
                MenuLinks = "",
                PageItems = "",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "",
                SocialMediaLinks = "",
                Tab = "",
                TabContainer = "",
                Testimonial = "",
                Video = ""
            };
        }
    }
}
