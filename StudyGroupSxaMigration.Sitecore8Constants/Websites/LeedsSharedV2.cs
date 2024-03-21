using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.Sitecore8Constants.Websites
{
    public class LeedsSharedV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public LeedsSharedV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Leeds University Shared V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Leeds University Shared V2";
        }

        /// <summary>
        /// The names of sub-folders under "Page Items" folder. If default folder names are used e.g. "Accordions" etc.,
        /// just return a new PageDataItemSubFolders instance without setting any values. Otherwise, return a new PageDataItemSubFolders 
        /// object with the correct values for the folder names
        /// </summary>
        /// <returns></returns>
        private PageDataItemSubFolders SetPageItemSubFolders()
        {
            return new PageDataItemSubFolders()
            {
                Accordions = "Page Accordions",
                ButtonGroups = "Page Button Groups",
                Carousels = "Page Carousels",
                ContentBoxes = "Page Content Boxes",
                Galleries = "Page Galleries",
                Heroes = "Page Heroes",
                Maps = "Page Maps",
                Tabs = "Page Tabs",
                Testimonials = "Page Testimonials",
                Videos = "Page Videos",
                Widgets = "Page Widgets"
            };
        }

        /// <summary>
        /// Template ids for the main page templates. Only return values for the pages that are used for the site
        /// </summary>
        /// <returns></returns>
        private PageTemplates SetPageTemplates()
        {
            return new PageTemplates()
            {
                HomePage = "{65DC9375-8A6C-4C47-8429-D8AA82362FB7}",
                HubPage = "{929C2729-799B-483E-8B1B-A9BF27A23C78}",
                InternalPage = "{87EE5F4B-3374-44CB-AFC6-0A0038ADC762}",
                NewsArticlePage = "{1F45667E-9248-49A8-A4F7-4FD02B4ACDA4}",
                NewsListingPage = "{92A71E47-6621-4B5D-B56F-1983B81DFA2D}"
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
                ButtonGroups = $"{sharedItemPath}/Shared Botton Groups",
                Carousels = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Carousels}",
                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
                HeroContent = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeroContent}",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
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
                AccordionItem = "{53092196-D87E-496C-8118-92A9232B3783}",
                AccordionContainer = "{F99AFDE4-F436-4B79-99E0-480F512C288D}",
                ButtonGroupContainer = "{47FBC9E5-B7AD-4D82-8BA4-B1EFAEB56090}",
                CarouselContainer = "{E9ED8766-08BF-4CC0-839D-7CB53F5EE49C}",
                CarouselSlide = "{E141C3BF-E81C-498E-AE6B-7FDE797B8608}",
                ContentBox = "{48F67886-2F82-4EDA-8056-153314138420}",
                CTA = "{C747CB54-6535-4272-A2DF-20876BFD32A7}",
                GalleryContainer = "{41CB8643-9115-4B7C-9465-F38B584D1946}",
                GalleryItem = "{96A1C077-8CEF-4ADB-9D72-2839FC89FD63}",
                Hero = "{A3704479-0D89-4C36-9FD7-831DFE6A035D}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{95915019-644E-46F5-84FB-6229640F3AD1}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{194B66DD-A284-4C77-9E1D-F7F3D3EE335C}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{35660F04-03DA-42A5-A5C1-F064A976F6F0}",
                TabContainer = "{3877F066-D163-4D3D-8503-4E805EEAC4DE}",
                Testimonial = "{E5A11A18-B6B5-48AB-8119-73DA9C5DA174}",
                Video = "{F62ABD91-B7E8-4148-A70E-D5EC937ED70A}",
                ComboMenuItem = "",
                Widgets = new List<string>
                {
                    "{5E5290D7-8348-4797-A448-297F0748A2BB}",
                    "{730ACF23-BB11-4680-A44F-11BD332E8856}",
                    "{48D3C564-BA23-430D-87C0-C1B4652E2F02}",
                    "{9D9ECE3F-C672-431E-8A0A-8162D0B6CA23}",
                    "{0A907102-A1B7-4F36-A7E4-55509E6EFF9C}"
                }
            };
        }
    }
}
