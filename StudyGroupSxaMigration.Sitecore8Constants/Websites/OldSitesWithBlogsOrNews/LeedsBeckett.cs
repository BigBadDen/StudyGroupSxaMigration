using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.Sitecore8Constants.Websites.OldSitesWithBlogsOrNews
{
    public class LeedsBeckett : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public LeedsBeckett()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Leeds Beckett/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Leeds";
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
                HomePage = "{1302EC8E-F609-4CE1-B874-0CA9DDA24967}",
                //HubPage = "{94E0671D-104C-4659-8A01-287C59325DDA}",
                //InternalPage = "{C4D01893-A467-4BA5-BC3B-1C3E1BE7A17A}",
                NewsArticlePage = "{58A872BF-41F8-4657-8173-6E1573F9E970}",
                NewsListingPage = "{7CF674BD-4BEB-423A-AB99-89E921A3959A}"
                //DirectApplicationForm = "{C7ECF4F9-AA40-4462-BE19-F25A9D40CEE1}",
                //SearchPage = "{D7341833-04CC-47DC-86EE-C2E5B9907DCC}",
                //LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                //ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}"
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
                ButtonGroups = $"{sharedItemPath}/ButtonGroup",
                Carousels = $"{sharedItemPath}/Carousels",
                ContentBoxes = $"{sharedItemPath}/Content Boxes",
                Galleries = $"{sharedItemPath}/Gallery",
                HeroContent = $"{sharedItemPath}/Hero",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                Maps = $"{sharedItemPath}/Maps",
                Tabs = $"{sharedItemPath}/Tabs",
                Testimonials = $"{sharedItemPath}/Testimonials",
                Videos = $"{sharedItemPath}/Videos",
                Widgets = $"{sharedItemPath}/Widgets",
                SharedComboMenus = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SharedComboMenus}",
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
                //AccordionItem = "{3F785EBA-208B-4057-87C4-6B60DE430631}",
                //AccordionContainer = "",
                //ButtonGroupContainer = "",
                //CarouselContainer = "",
                //CarouselSlide = "{40BD0D49-7E6C-4E22-BF1E-41644927869D}",
                //ContentBox = "{95146D16-E559-404B-AE88-7E0F4587ACB7}",
                //ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                //CTA = "{6B9E288F-4413-4424-B428-FF03DC52FFB3}",
                //GalleryContainer = "{B82AA07C-5D29-4736-AD83-4818C2B4CCF5}",
                //GalleryItem = "{551C92DD-3A0F-496F-BB6D-9B2928D3D0DF}",
                //Hero = "{A572E796-53B5-4F6E-B4B6-7220DC2FA1E3}",
                //LanguageLinkItem = "{7D53F312-6BC4-4BE1-B129-156A507B36C9}",
                //LanguageLinks = "",
                //LiveChat = "",
                //Map = "{F8A4343A-C5CB-43D3-B6DB-B6B295892E6E}",
                //MenuLinks = "{F10B2C2A-9041-4C2D-9000-273D863800A0}",
                //PageItems = "",
                //ProgressionRoutes = "",
                //RelatedLinks = "",
                //RelatedLinksWithSections = "",
                //ScriptSnippet = "",
                //SidebarBoxes = "",
                //SocialMediaContainer = "",
                //SocialMediaLinks = "{32344B2C-BCEE-4ECA-9B0F-1D38E6202089}",
                //Tab = "{CF3D60B3-B899-431D-901F-41BB4069A32E}",
                //TabContainer = "",
                //Testimonial = "{189F8771-0212-43BE-B965-2A8F214AAD6F}",
                //Video = "{B1B0FCEE-5DD6-4D39-9DC6-F8538B7BABA1}",
                //Widget = "{EDA69B4E-1629-448C-9BE1-C317C6A4000D}"
            };
        }
    }
}
