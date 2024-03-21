using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class OglethorpeV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public OglethorpeV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Oglethorpe V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Oglethorpe V2";
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
                HomePage = "{45EC461B-84F9-4259-99D4-46DBFDB79177}",
                HubPage = "{2EBB63BD-B1CD-468F-9317-63917DE6B5D2}",
                InternalPage = "{E3774B40-DD73-4407-871D-2B4262292ED6}",
                NewsArticlePage = "{761A0BCF-44FC-481C-AF27-37142BB7CB77}",
                NewsListingPage = "{24B0C4C1-33F0-40DD-9A95-9ABF701FCF72}",
                SearchPage = "{AFCD35BF-5D99-4769-B81F-8C8A4C8D30D2}",
                LandingPage = "{672D235E-A259-41A3-8AD1-756D893592CF}",
                ThanksPage = "{596ABC77-BC16-41FF-811D-907346AE1AD3}",
                CampaignPage = "{C6BB7E52-F00A-4966-A5DF-D31D6A4DF98C}"
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
                AccordionItem = "{8BE098C4-4D3D-40CE-A385-AE751245B8AA}",
                AccordionContainer = "{B462FB3F-67CC-4C9A-81F4-6A013F7B7E60}",
                ButtonGroupContainer = "{1186B76C-40B9-4252-87C1-30C9B8724EC3}",
                CarouselContainer = "{F3F6881E-8BDF-455A-99E2-FC7B99A94878}",
                CarouselSlide = "{4DCFA809-F731-48A0-84E1-E4E06FA16EBA}",
                ContentBox = "{94BE7ECF-4086-42ED-B569-1F8ACC4611DA}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{E6B42E4E-AF04-4131-969D-BC0A41D40E9F}",
                GalleryContainer = "{D444BD84-2301-41CB-A968-0106D2643C1E}",
                GalleryItem = "{0C685AE7-3CD9-4C4F-8EB4-DDB9E24BB86E}",
                Hero = "{7B657C33-77B2-45BB-9830-A14CA72B97AE}",
                LanguageLinkItem = "{33F9CF77-7956-48E9-AB8C-C27F8BED1D35}",
                LanguageLinks = "",
                LiveChat = "",
                Map = "{459F3356-50B4-4D5B-BF01-B4962F5431EC}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{0C1D84C4-5C37-41B4-8C50-0257269F5593}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{3BD61F3A-E0C6-463B-A5B5-1B2DE63DE7BF}",
                TabContainer = "{3A65DEBF-B632-4250-AD44-2406D64D5EAD}",
                Testimonial = "{478EF5B9-B37E-4C26-955E-DD18025F4335}",
                Video = "{BC40D5C1-351C-4AD6-96B5-0A8F4B50694E}",
                Widgets = new List<string>
                {
                    "{446A3B2F-EEBB-46D2-8870-AAAF39C515DF}",
                    "{CC0E2D9B-F717-4ABA-A2D5-EE4EB354B6E8}",
                    "{EA044665-DC24-4AF7-AE01-76A57312E0FD}",
                    "{B6B1FCBE-38F5-4289-9468-8957561D9A22}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}",
                    "{3FEF07D4-0857-4548-8B3E-C3E8A81026DF}"
                }
            };
        }
    }
}
