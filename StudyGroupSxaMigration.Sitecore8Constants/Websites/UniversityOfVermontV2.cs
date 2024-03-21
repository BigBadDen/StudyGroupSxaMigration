using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class UniversityOfVermontV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public UniversityOfVermontV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/University of Vermont V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/VermontV2";
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
                Accordions = "Page Accordians",
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
                HomePage = "{CD59F19E-B627-4183-979B-CF154692FDDA}",
                HubPage = "{1A3981A9-0F9F-46AA-B2FC-8A10AF9122F5}",
                InternalPage = "{4D2B3CD9-C9BB-466D-8C2D-E67B0F78A1A0}",
                NewsArticlePage = "{AE15B6DD-BE6C-4C26-B54D-9274E11BD88F}",
                NewsListingPage = "{926004D3-0593-4CE2-8758-E1DFDB82C450}",
                CampaignPage = "{90A88C11-3E5C-45F6-8DF2-AD2B0F6CA490}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                GenericPage = "{90A88C11-3E5C-45F6-8DF2-AD2B0F6CA490}"
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
                ProgressionRoutes = $"{sharedItemPath}/Progression routes",
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
                AccordionItem = "{A54FBE32-F2A2-4DE4-B873-82A242247676}",
                AccordionContainer = "{20D78584-E8E9-455A-B375-4236C8B1F276}",
                ButtonGroupContainer = "{73400A5D-1C8A-4F19-9138-1BCE6C326F96}",
                CarouselContainer = "{9377A87A-273F-4023-88D7-F5EFEAA2BE2D}",
                CarouselSlide = "{CF93E7CB-CC1F-4B20-980E-9364E3421308}",
                ContentBox = "{BF3B0518-A622-46AE-806D-86A09496D9B1}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{2640FA43-DCAA-4ED7-AD64-D43C0607F9BD}",
                GalleryContainer = "{E2F885F3-CAE0-4428-A82B-89F6BDD6CC6A}",
                GalleryItem = "{85D76FA0-5E59-4607-BA23-428E2AAD0B17}",
                Hero = "{A078CD67-E084-4253-AB00-6D59D0727B3A}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{9FB6D692-A760-4FD8-8C03-FDF716A818DE}",
                MenuLinks = "{AC3298D8-8C0A-46F9-B163-E575FA97DC9E}",
                PageItems = "{53B6487D-9128-4A8F-AF5E-C2D121B095FA}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
                SidebarBoxes = "",
                SocialMediaContainer = "{AA310DCF-E82B-4EF2-A033-95EA6BE76E6A}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{6D24EAB9-306F-4E06-80B2-2522C8AE0778}",
                TabContainer = "{FA37D505-36BD-4D4A-86EE-7F223802B230}",
                Testimonial = "{35B2404A-34B2-4253-B4AE-D4B3541B041A}",
                Video = "{F2C0A868-228A-4914-AD6A-0F66BE044F83}",
                Widgets = new List<string> {
                    "{E45648FC-5876-41F8-BA96-9E746B1B7E80}",
                    "{0EB91170-C1C7-441A-8B6E-955DF6E379BE}",
                    "{3E40B081-7275-470D-AA85-0C4607888407}",
                    "{37E55DC6-29F6-44D9-B305-6C574FEC1401}",
                    "{49EA2EDE-4430-4277-9D2C-402FEBEA52C0}",
                    "{FB5CD631-BDE2-4F54-AF63-9D770EF88F8D}",
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
