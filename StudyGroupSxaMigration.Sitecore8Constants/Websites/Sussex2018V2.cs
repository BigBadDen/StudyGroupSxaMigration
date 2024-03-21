using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class Sussex2018V2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public Sussex2018V2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Sussex 2018 V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Sussex 2018 V2";
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
                HomePage = "{F3628818-24B9-4340-98CD-A172BC6C1D8A}",
                HubPage = "{25DC0E7D-DB81-4F11-AF6B-EF5102383626}",
                InternalPage = "{45AB779D-0098-44BF-94E8-93FE1401C981}",
                BlogEntryPage = "{2F54D604-CD0B-462E-9D19-14DF8075D20F}",
                BlogCategoryPage = "{E4D8029C-BC6D-4895-82B3-8871C179EE21}",
                BlogHomePage = "{18F044B7-3CDA-4F87-B16F-01129CE0537B}",
                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
                LandingPage = "{672D235E-A259-41A3-8AD1-756D893592CF}",
                ThanksPage = "{596ABC77-BC16-41FF-811D-907346AE1AD3}",
                CampaignPage = "{5E671D09-BE0D-4A01-8A0A-A2E63ABA95CC}",
                DirectApplicationForm = "{84946653-E2A1-4155-AE09-A27B44B34A6C}",
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
                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                LiveChat = $"{sharedItemPath}/Live Agent",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
                SharedComboMenus = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SharedComboMenus}",
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
                AccordionItem = "{45B8B02B-DF30-47A6-BB79-80ADD54D7DAA}",
                AccordionContainer = "{D6E20AFD-6AC2-45FE-A92A-6E6272F06DF6}",
                ButtonGroupContainer = "{3340FCDB-81D1-4567-BAA6-CAB664FE12AA}",
                CarouselContainer = "{F73DE33C-8DE4-4EAF-B486-4390355E81FA}",
                CarouselSlide = "{641D95D4-3EB7-4E53-A979-673134E048C6}",
                ContentBox = "{03C458D9-1A69-450B-970C-D8CA114BD355}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{0E38BA6E-18AD-4546-BFC9-7F913B303D13}",
                GalleryContainer = "{CF26E0E3-F785-49B9-A434-E8F7FDDF215B}",
                GalleryItem = "{77B8F7ED-9924-4B24-AFCA-DAF55E78436D}",
                Hero = "{17830AC3-2B4D-495D-88B5-B875A0688BA7}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "{66D12138-143E-49BE-B7B0-C803165016E9}",
                Map = "{0CCFA1FC-8EDB-4C53-BFC0-7B7BD34F0CDD}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{991B3A5C-CD6E-42B3-A776-8F17FE651384}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{4E47201A-6C54-4315-A558-9D178306578D}",
                TabContainer = "{DDF1AE1E-652F-498D-837D-B27C892A2B3F}",
                Testimonial = "{7B8DE3AE-2AE2-4A19-99B6-976213E89220}",
                Video = "{0DC17214-E5F7-4955-8C0B-6ACB2A6A65E6}",
                Widgets = new List<string> {
                    "{96E56758-7232-4E0B-9A36-EAEF02C919F5}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}",
                    "{3FEF07D4-0857-4548-8B3E-C3E8A81026DF}"
                }
            };
        }
    }
}
