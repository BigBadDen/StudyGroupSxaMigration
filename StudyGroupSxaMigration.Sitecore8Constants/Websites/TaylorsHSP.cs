using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class TaylorsHSP : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public TaylorsHSP()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Taylors HSP/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Taylors HSP";
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
                HomePage = "{DF0D055A-F581-4CB4-AD1E-E4F1BF6A035D}",
                HubPage = "{B577F137-9CF9-4570-93B3-6C923543B138}",
                InternalPage = "{B7EA7612-9BF6-45F1-937E-B47A48DA170C}",
                NewsArticlePage = "{7EDFF68A-0BCD-49E5-BBB7-08B1C49E8455}",
                NewsListingPage = "{68C32323-9E06-4353-A658-943460EBE68B}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
                CampaignPage = "{11912448-6197-4944-9933-CD0172900FE2}"
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
                ScriptSnippet = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ScriptSnippet}",
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
                AccordionItem = "{CE74D721-8F35-497D-A5B9-D84DED8762E5}",
                AccordionContainer = "{A4099F9B-8EE4-43CA-BA84-AEE3E10EEFAD}",
                ButtonGroupContainer = "{DC2AB311-AB33-453C-B517-8AE0D9C72BFC}",
                CarouselContainer = "{42FFB21F-BC73-48D0-B863-69A7738DA373}",
                CarouselSlide = "{EC2AB841-E69F-475A-848B-BE02030EA1DD}",
                ContentBox = "{FDB68A57-6D1F-40BB-8529-60A415B632C1}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{A22A25F0-F7AD-4839-B9C7-0AF46B1F02A8}",
                GalleryContainer = "{34C956B5-9A04-4CBF-AB0C-55A0A065F58D}",
                GalleryItem = "{68CE383F-D5CC-421E-8272-3D2178C09A4F}",
                Hero = "{EEED210E-D063-4E43-8313-9949948165E3}",
                LanguageLinkItem = "{33F9CF77-7956-48E9-AB8C-C27F8BED1D35}",
                LanguageLinks = "",
                LiveChat = "",
                Map = "{AA20E874-EF6F-444E-88B9-342B3374D7D5}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{A1AE2520-2986-4D9F-B174-5B2B6B4CF6D3}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{A9C9C9E7-8717-4C23-B841-A8557D341F65}",
                TabContainer = "{B09A31DF-E184-4865-90B5-2BE3FCE9DCED}",
                Testimonial = "{C1FADD2C-7B0F-48BF-A64F-9E4208632711}",
                Video = "{B4EE7BCD-79DF-4CD1-822B-D5D8AC7C40EC}",
                Widgets = new List<string> {
                    "{E6B2F162-3EC0-4665-B5FD-F2A5AB079065}",
                    "{3273003E-B1EE-4F63-BB9F-4CBAA9CF6F32}",
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
