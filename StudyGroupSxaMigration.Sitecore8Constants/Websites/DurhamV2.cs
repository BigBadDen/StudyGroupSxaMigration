using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class DurhamV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public DurhamV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Durham V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Durham";
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
                HomePage = "{8ECAA1A3-7CF3-4F90-A07F-AEEB8DB0AB63}",
                HubPage = "{4FEFA7B7-EFFF-463A-BF9C-004E0FA4220D}",
                InternalPage = "{AF4C9673-8B80-41CF-9DBC-230E193C5E47}",
                BlogEntryPage = "{D43233FF-4A31-4906-98F3-52B1846CE24D}",
                BlogCategoryPage = "{BDAF95E7-4A5A-407C-B500-BB9189008941}",
                BlogHomePage = "{DB3DCCB4-96F4-434E-A0BE-8E2EC91E5F28}",
                NewsArticlePage = "{B6CC0D4C-69E2-4FD9-8322-461685A9234E}",
                NewsListingPage = "{5BB93E3C-D28B-4785-924E-528064E76B37}",
                CampaignPage = "{EDE00362-BDB1-4A68-AB8F-AADB10FDE63D}",
                DirectApplicationForm = "{0F1F11C8-64AB-4B7F-AAAD-B66C34A0D7C5}",
                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
                SearchPage = "{E1CCCF32-C2AA-4ADF-8E0C-00789364A576}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
                CallBackLandingPage = "{5D79575B-B346-47BF-AAA7-C0E6F671AB05}"
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
                ButtonGroups = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ButtonGroups}",
                Carousels = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Carousels}",
                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
                HeroContent = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeroContent}",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                LiveChat = $"{sharedItemPath}/Live Agent",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
                SharedComboMenus = $"{sharedItemPath}/Footer menu combo items",
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
                AccordionItem = "{9B5978FC-CB92-4D1F-BA93-B13F19A24F21}",
                AccordionContainer = "{C8160EF5-107D-44BB-AE0D-D0C76B9F3E72}",
                ButtonGroupContainer = "{11E26703-ED56-44DA-9749-34D8EC1B462C}",
                CarouselContainer = "{86A39856-57AF-401A-A70B-5E6995E96FE2}",
                CarouselSlide = "{0C004E9E-0BE6-47E1-A10D-3F59B6B7E7B5}",
                ContentBox = "{1A89E082-9042-4E9B-B567-DAE6D9BE4557}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{C44A94E6-8C1D-4E48-AD5A-EFD70DA3AA5E}",
                GalleryContainer = "{E5C1E9B7-FAE9-4375-8458-0F01A12A9765}",
                GalleryItem = "{F678CECA-0483-4EFD-B591-033EB3F7B1BA}",
                Hero = "{ECD950DC-EA82-4B8D-82BD-9358692C1DFF}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "{7AC125B4-F87F-46B4-87B7-FC1689F81326}",
                Map = "{71EEB8AC-3232-4715-8CA9-6E21593C1A12}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{1087F762-DB6C-458B-9307-79C692A543BC}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{3964E6A8-653D-47E7-8E72-49EE1A89F279}",
                TabContainer = "{09BC4260-BA16-4FE7-8829-6925BEAC5453}",
                Testimonial = "{08714F6D-A858-4648-B262-A7EE6A6B5E18}",
                Video = "{D946B654-09DC-4596-8731-B47149467B0B}",
                Widgets = new List<string> { "{29420280-0F05-4BAB-8968-BC7BE7381B15}",
                                            "{C96A7072-D769-4841-9855-AB91CBF4388C}",
                                            "{57387932-8BED-4E09-8533-E90DDE48AF0C}",
                                            "{00ABF7F3-A359-407B-A7E9-376E9E988E74}" }
            };
        }
    }
}
