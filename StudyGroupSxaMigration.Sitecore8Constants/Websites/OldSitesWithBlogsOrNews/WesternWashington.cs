using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites.OldSitesWithBlogsOrNews
{
    public class WesternWashington : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public WesternWashington()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Western Washington/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/WesternWashingtonV2";
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
                HomePage = "{71040F31-29C4-419D-BA9C-BFEDF379E9EA}",
                HubPage = "{CB52D076-A78A-4D11-AB10-E72DC96F958E}",
                InternalPage = "{D06447D8-8AF3-4465-989A-402006678621}",
                NewsArticlePage = "{13718976-B130-46A2-8A3F-524A5BF9DAB3}",
                NewsListingPage = "{9B6CE7D3-CA56-4DA4-89E6-8D0F5F2D2B6D}",
                CampaignPage = "{216586B2-CDDD-46C4-AB2C-037BFF620AFF}",
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
                Accordions = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Accordions}",
                ButtonGroups = $"{sharedItemPath}/Shared Botton Groups",
                Carousels = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Carousels}",
                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
                HeroContent = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeroContent}",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
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
                AccordionItem = "{EED3D830-BF7D-4925-A1FB-BD226B0C32E8}",
                AccordionContainer = "{49770C25-8595-444A-B44A-64E0B207067B}",
                ButtonGroupContainer = "{5DCEE937-E8B7-4C44-BEB9-AD8FA6561B16}",
                CarouselContainer = "{6D6C549E-2ED9-4D64-B288-39E77950B3C5}",
                CarouselSlide = "{B14FB0A9-388D-49AF-A77A-036911A38578}",
                ContentBox = "{88986B90-7B5A-459A-BCE5-D975A95BDE69}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{F3C97FA7-02E0-4651-98A2-B251B2E92471}",
                GalleryContainer = "{558B9052-6AF8-4705-BD67-22E6F10B733B}",
                GalleryItem = "{16DE55AF-D662-407C-BC3E-8201EEADCC5C}",
                Hero = "{4ECDA6DE-E3D4-47B4-A61F-7F125F06C9AC}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{47F990FA-9ECC-4B3A-98E0-F94814E3F89C}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{F19E8B70-0650-43BF-8BAF-C22BCD55BAD2}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{B342808A-6ADC-4D5F-99B5-FD7AE8D3239F}",
                TabContainer = "{A4DC2E8E-096F-4B49-BBB4-006464103D35}",
                Testimonial = "{5F06B980-CA37-4528-8F93-999833CA4248}",
                Video = "{02208642-AC60-45EA-9470-325B51299C4D}",
                Widgets = new List<string>
                {
                    "{CC3DF477-1CAF-4EBE-8B25-F6BFEA02510A}",
                    "{EE5F0712-52A3-4F82-BDB9-7F90BA0FFC29}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}"
                }
            };
        }
    }
}
