using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.Sitecore8Constants.Websites
{
    public class Baylor : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public Baylor()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Baylor V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/BaylorV2";
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
                HomePage = "{A383437E-2D20-4D7D-8698-4A44C643397F}",
                HubPage = "{79785929-27C3-439F-AB05-DA9D8BA18008}",
                InternalPage = "{7E85A1C6-F0AC-410C-AB12-17247124B030}",
                NewsListingPage = "{EB8D3036-5CEA-4439-B4EB-5BC2A22CFAAC}",
                NewsArticlePage = "{239DEAC0-17D5-4333-A924-3ED87C480F7B}",
                CampaignPage = "{2685B633-EC3A-4BCD-91E4-9A5F24250FA7}",
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
                ButtonGroups = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ButtonGroups}",
                Carousels = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Carousels}",
                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
                HeroContent = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeroContent}",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
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
                AccordionItem = "{F23A3C49-DF6B-43D5-95E1-A1FCB9898039}",
                AccordionContainer = "{C3F599F6-8BA6-46E8-9C91-67DB824BA1AB}",
                ButtonGroupContainer = "{508E4D19-53F5-4ED2-AE40-760FB20307C9}",
                CarouselContainer = "{22AE35BA-C19D-4BA1-8295-4D6FFC089A8A}",
                CarouselSlide = "{E9B7136E-19A9-4201-BC09-D0C2F4FF885C}",
                ContentBox = "{DAD44AEB-9A7B-4924-AA4A-D225386B6742}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{21E7DBED-3B1D-4694-B02E-E00079E59AE9}",
                GalleryContainer = "{0F1E3D11-D84E-44E0-A4B6-DDBEA7E6F4ED}",
                GalleryItem = "{B5C05880-8341-477D-9968-E8A57D9D4EA7}",
                Hero = "{194BE082-7CF4-455F-B0E2-9AC82EC96465}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{78C94B8B-0CC0-4963-814A-AC84E2B1A3F5}",
                MenuLinks = "",
                PageItems = "{75FF3D65-CF8D-47CB-B8E1-2C8388EF3BE2}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{4F40772B-EF98-461B-BA3F-492E25DCD90D}",
                TabContainer = "{6C2384EA-B83C-48D7-B36A-5C92494383F1}",
                Testimonial = "{2869CB3C-2C1A-48DE-8BB2-F9CF39D50F00}",
                Video = "{32982E04-E390-4586-9E8A-C81CF6A56CA6}",
                Widgets = new List<string> {
                    "{DB4F8080-E9CE-4A35-9124-2EC25BE41556}",
                    "{89D27D70-1A35-4605-B59B-3A7D640CF43F}",
                    "{08CEEACC-B59C-4BA2-B31C-237D3A3C5918}",
                    "{C9DAF413-BA1A-4796-9A27-136469FCC12F}",
                    "{F37244B6-F362-4402-B89B-913608998B81}",
                    "{172761A1-30FE-41E6-B5CA-0E0D661340E3}"
                }
            };
        }
    }
}
