using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class BellerbysV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public BellerbysV2()
        {
            RootPath = "/sitecore/content/Bellerbys V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/BellerbysV2";
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
                ContentBoxes = "Page Content Boxes",
                Galleries = "Page Galleries",
                Heroes = "Page Heroes"
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
                HomePage = "{BA1D9B5C-4C43-4114-A876-084D4D626657}",
                HubPage = "{06789E89-42BB-4786-8D51-E53C52C1E586}",
                InternalPage = "{F845FB71-6250-4812-A257-32FAE2A65E0B}",
                BlogEntryPage = "{4B7C2928-610F-4891-A835-2800B0E9D483}",
                BlogCategoryPage = "{845FF57A-E4B3-4403-A9D4-0B2037881944}",
                BlogHomePage = "{1CD528A1-4B3D-486C-A6FC-17278658D3ED}",
                DirectApplicationForm = "{3D88C719-CD13-4C36-BE0B-A232D630BAD8}",
                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
                CampaignPage = "{0D053B87-D449-4443-9709-98B54A8DA604}",
                LandingPage = "{672D235E-A259-41A3-8AD1-756D893592CF}",
                ThanksPage = "{596ABC77-BC16-41FF-811D-907346AE1AD3}"
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
                ButtonGroups = $"{sharedItemPath}/Button Groups",
                Carousels = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Carousels}",
                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
                HeroContent = $"{sharedItemPath}/Hero",
                HeaderAndFooterLinks = $"{sharedItemPath}/Links",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                LiveChat = $"{sharedItemPath}/Live Agent",
                Maps = $"{sharedItemPath}/Maps",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                Testimonials = $"{sharedItemPath}/Testimonials",
                Videos = $"{sharedItemPath}/Videos",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
                SocialMedia = $"{sharedItemPath}/Social Links"
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
                AccordionItem = "{CF70F199-C6FB-4BDF-88D6-5A2D2B13AAE1}",
                AccordionContainer = "{8160E4E9-C47A-499D-BABE-078AF7EB9549}",
                ButtonGroupContainer = "{FC8CB398-813C-4685-A734-30D44E79BC02}",
                CarouselContainer = "{CB72B270-197B-4B96-AAE3-EFB8CA08115C}",
                CarouselSlide = "{DE1E5DF7-EB14-4583-9CB6-81FC15DAC3C7}",
                ContentBox = "{3F47B6EC-7D7A-432D-AF09-01C077E50F5F}",
                CTA = "{29776F58-95AA-4533-AC85-6D1E3B494C1B}",
                GalleryContainer = "{2AEDC460-070E-4556-BEE0-A843909B5AB5}",
                GalleryItem = "{765EA526-828E-4BFF-9B40-752649F37B2D}",
                Hero = "{CB421824-F5D7-443A-A2B1-3C737838D547}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "{D74A351F-2A06-499F-BDAB-9EAA01A14486}",
                Map = "{94D8E0E2-206A-4BD8-99B5-D50596497078}",
                MenuLinks = "{9FE10699-1EBE-4E68-AB08-D14F0BE10697}",
                PageItems = "{054891E0-FA1B-450A-83A1-BA1A79E59A22}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{E8D91CC8-C530-4598-B3A8-3F1AC042689C}",
                TabContainer = "{0F8B1BF8-F97D-425E-B763-CFDC4BDE13E0}",
                Testimonial = "{09818D4D-C0B1-4A17-8BE0-064E9D151A26}",
                Video = "{71D7AB59-DBCF-4A9B-95DC-045E5A1446BF}",
                Widgets = new List<string> {
                    "{BE8FD83F-5020-4CA7-A64A-3F1B0AA9CFA1}",
                    "{1FDF3CF7-4F3D-4F62-9341-1B6944344854}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}"
                }
            };
        }
    }
}
