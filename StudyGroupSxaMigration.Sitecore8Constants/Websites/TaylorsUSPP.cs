using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class TaylorsUSPP : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public TaylorsUSPP()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Taylors USPP/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Taylors USPP";
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
                HomePage = "{9B605C06-DEC8-483A-80CB-12131A6B7EAC}",
                HubPage = "{5576C5EF-3952-4F41-9868-E4D4707F2369}",
                InternalPage = "{EB8F22DB-7745-4CC7-8FDC-9162520AD5F7}",
                NewsArticlePage = "{CAE5CFB6-547C-4C5A-92EC-769D09874A7A}",
                NewsListingPage = "{34E4F5FC-1846-47D9-9840-A11240BA573A}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
                SearchPage = "{51D0E395-1EA0-443E-BF5B-6163055550E9}",
                CampaignPage = "{2E4A5702-B1CE-4A4D-9C47-4A4391B9F8FC}"
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
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                LiveChat = $"{sharedItemPath}/Live Agent",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                ScriptSnippet = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ScriptSnippet}",
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
                AccordionItem = "{54B25E1A-7D2C-46EC-BD2F-A6408D7E50B0}",
                AccordionContainer = "{BB235A45-645E-4760-A73C-68C4DA559D43}",
                ButtonGroupContainer = "{8268B934-49DC-4F5E-A2D5-E92B4849BD34}",
                CarouselContainer = "{DAD26C2C-95A5-4BF0-A38B-68D250E2C7A6}",
                CarouselSlide = "{83FEBE7F-31CF-4B51-BFC2-0964FD5DCBEB}",
                ContentBox = "{94BE7ECF-4086-42ED-B569-1F8ACC4611DA}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{409D8925-CBCD-4D49-9B2E-27A94CFBD554}",
                GalleryContainer = "{368C58E2-A52A-48FE-A644-92D6D0B92890}",
                GalleryItem = "{B2D28D61-574E-476A-8822-87D2261399F8}",
                Hero = "{5D38405F-E85F-4442-83B6-E8DE66685356}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "{D74A351F-2A06-499F-BDAB-9EAA01A14486}",
                Map = "{2930E11B-2C3E-4A8B-A2C0-3A4FCD5D7455}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{0644BCD8-027C-499A-B24D-183F49732171}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{B706365D-7EC2-4328-BB0D-F2E3150C3F88}",
                TabContainer = "{36B1BE05-DC90-44C2-AAC5-D3BBFF19FDF3}",
                Testimonial = "{D5F61103-2B70-4AD1-8DE0-823F9934E461}",
                Video = "{44BB0BC3-14D2-4FB6-BBCA-51EDF506CD11}",
                Widgets = new List<string> {
                    "{AF441934-A0AE-4EFB-8ECD-2EC97229A661}",
                    "{903B7953-D9EF-41A2-ABCF-8179C17F9633}",
                    "{3FEF07D4-0857-4548-8B3E-C3E8A81026DF}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}"
                }
            };
        }
    }
}
