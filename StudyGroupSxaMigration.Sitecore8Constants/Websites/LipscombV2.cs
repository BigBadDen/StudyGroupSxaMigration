using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class LipscombV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public LipscombV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Lipscomb V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Lipscomb V2";
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
                HomePage = "{2CD681BA-2994-4C7E-A24F-5C9A2D924FA0}",
                HubPage = "{F9E66F57-745A-43CC-ADB3-2B1A9F2F34D2}",
                InternalPage = "{C3E15E05-B7ED-45FB-8F67-B08831D52F9D}",
                NewsArticlePage = "{A39AF57B-9DA4-4EED-AF6B-BA305C2C9FCA}",
                NewsListingPage = "{FAC3E6F3-AC18-44A1-83E4-8A21AEE8BB08}",
                LandingPage = "{672D235E-A259-41A3-8AD1-756D893592CF}",
                ThanksPage = "{596ABC77-BC16-41FF-811D-907346AE1AD3}",
                CampaignPage = "{F8677AD5-092B-4236-B27E-9C66BDD5D281}"
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
                AccordionItem = "{9700CD7A-6B32-48AF-8A71-BAF08FE58412}",
                AccordionContainer = "{66FC0705-050C-4781-A8E0-D5D29C97743B}",
                ButtonGroupContainer = "{F09C1854-EB7E-4DC3-8942-6C8CE1D788D3}",
                CarouselContainer = "{A4FAFFB4-6B9B-4451-BE98-39E60085E698}",
                CarouselSlide = "{16308C24-5004-4297-BC1D-FF2B6BC92FE6}",
                ContentBox = "{80933142-5604-44C5-AF24-59FE82407C15}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{262D8332-E2E3-4CA6-9F78-15ADE5CA1637}",
                GalleryContainer = "{ED7CF458-98C7-4032-A789-B8C8A1BFADB1}",
                GalleryItem = "{ED63A10B-AD4E-4CAF-B859-8DAECD3F4A41}",
                Hero = "{8D69A07D-6B92-4BF0-9125-DECF1786C117}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{C5A0004D-DFBF-4D1C-BFB1-D21EA1D48453}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{834D0695-EA04-459B-AE54-B29B31D67333}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{136E0833-BA9F-4D80-82C0-56200165AA4D}",
                TabContainer = "{6B96D18A-758D-4F13-BF3B-6D0A8B07F3BF}",
                Testimonial = "{B03B1EB7-ACD7-4A8F-86C5-090AF371B3D8}",
                Video = "{ADB19E95-2E7C-47D2-B826-1CF8B42F13E3}",
                Widgets = new List<string>
                {
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}",
                    "{9D52B2E4-06D1-4D49-8E23-CAE4446299A9}",
                    "{918913A7-CCE2-4001-A44E-A2FD39C597DE}"
                }
            };
        }
    }
}
