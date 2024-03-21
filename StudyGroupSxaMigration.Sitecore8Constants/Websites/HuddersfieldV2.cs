using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class HuddersfieldV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public HuddersfieldV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Huddersfield V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MiscellaneousSharedItemsFolders = SetMiscellaneousSharedItemsFolders();
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Huddersfield V2";
        }

        /// <summary>
        /// The names of sub-folders under "Page Items" folder. If default folder names are used e.g. "Accordions" etc.,
        /// just return a new PageDataItemSubFolders instance without setting any values. Otherwise, return a new PageDataItemSubFolders 
        /// object with the correct values for the folder names
        /// </summary>
        /// <returns></returns>
        private PageDataItemSubFolders SetPageItemSubFolders()
        {
            return new PageDataItemSubFolders() {
                Accordions = "Page Accordians",
                ButtonGroups = "Buttons",
                ContentBoxes = "Page Content Boxes",
                Galleries = "Page Galleries",
                Heroes = "Page Heroes",
                Tabs = "Page Tabs",
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
                HomePage = "{AD81F890-89A3-4A85-91B5-2DAD4421A8D9}",
                HubPage = "{347645B2-B77B-4443-97E8-2743073422A0}",
                InternalPage = "{0B524A6D-2470-4DE8-A95F-14CAC9EE2C2B}",
                NewsArticlePage = "{A1AC25D5-1EF1-40B1-8A78-57D9E22A512A}",
                NewsListingPage = "{43938C41-7110-4227-B500-3662CBCFACF6}",
                DirectApplicationForm = "{B024724B-C6BA-4E02-804C-045259E7EB7A}",
                BlogHomePage = "{B653F6B2-3DF6-435F-A92E-706F599F63FA}",
                BlogCategoryPage = "{0F066B3A-4BB0-48AB-8F36-7595286E882A}",
                BlogEntryPage = "{F04196B0-8AB0-4D9F-BE10-5996673A4B69}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
                SearchPage = "{4B96BE7A-4B72-4C6C-8D31-AF0FA337A704}"
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
                ButtonGroups = $"{sharedItemPath}/Button Groups",
                Carousels = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Carousels}",
                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
                HeroContent = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeroContent}",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                Maps = $"{sharedItemPath}/Map",
                Tabs = $"{sharedItemPath}/Tabs",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/Videos",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
                SharedComboMenus = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SharedComboMenus}",
                SocialMedia = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SocialMedia}"
            };
        }

        private List<MiscellaneousSharedItemsFolders> SetMiscellaneousSharedItemsFolders()
        {
            string sharedItemPath = $"{RootPath}{Sitecore8Paths.SharedItemFolderName}";

            List<MiscellaneousSharedItemsFolders> miscSharedFolders = new List<MiscellaneousSharedItemsFolders>();
            miscSharedFolders.Add(new MiscellaneousSharedItemsFolders()
            {
                Sitecore8TemplateId = this.WebsiteTemplateIds.ContentBox,
                SharedFolderPath = $"{sharedItemPath}/Purple widget",
                Sitecore9SharedFolderName = "Purple widget"
            });

            miscSharedFolders.Add(new MiscellaneousSharedItemsFolders()
            {
                Sitecore8TemplateId = this.WebsiteTemplateIds.ContentBox,
                SharedFolderPath = $"{sharedItemPath}/Stats",
                Sitecore9SharedFolderName = "Stats"
            });

            return miscSharedFolders;
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
                ButtonGroupContainer = "{BDCF2E21-274B-4E70-AAC0-58AD4E8CBBC9}",
                CarouselContainer = "{4A86FD11-9A0E-4258-AC27-A649FB5A7838}",
                CarouselSlide = "{DD8FE737-5F7A-4D59-B3E4-78C1BB513FD8}",
                ContentBox = "{94BE7ECF-4086-42ED-B569-1F8ACC4611DA}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{B2A0B457-8499-4B8D-BA07-DFF88F74AC92}",
                GalleryContainer = "{E753648D-6CFE-4B36-88A1-C934BDABABD1}",
                GalleryItem = "{12A3CE7B-6895-481C-9739-80861571E738}",
                Hero = "{25A5C15F-158D-4717-9CB4-7B015A063012}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{E651921C-1E22-45FC-ADFC-9D593131B393}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{1BD7F72D-7CE6-4260-B91C-D5B5DDF42216}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{DEED95B8-BC35-473F-9AFD-D68CD89D1DD8}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{165D7CC5-12A5-4E4F-9F7A-A02E8C00B034}",
                TabContainer = "{0A4A9C3B-321A-4794-9AB6-75C3DE332966}",
                Testimonial = "{7C49656B-BD98-4445-8E66-48BF46FD90C1}",
                Video = "{963F1CBA-995B-46AD-AF6E-022B495B2604}",
                Widgets = new List<string> {
                    "{078E3B0B-9231-4CBC-ACEC-F7B10ABB55D0}",
                    "{BE8FD83F-5020-4CA7-A64A-3F1B0AA9CFA1}",
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
