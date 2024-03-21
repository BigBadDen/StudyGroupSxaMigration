using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class SurreyV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public SurreyV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Surrey V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MiscellaneousSharedItemsFolders = SetMiscellaneousSharedItemsFolders();
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Surrey V2";
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
                HomePage = "{FD523F29-A1C3-4163-835C-50B77B3564DF}",
                HubPage = "{2217298D-6B11-4890-AAB9-C82F6E2689B4}",
                InternalPage = "{DF50C175-30B9-4448-A1AA-750FC5898A55}",
                NewsArticlePage = "{98969859-807C-4070-932C-DE14190C0310}",
                NewsListingPage = "{3DA31D1F-2E2F-413B-ACD2-A2C3AFF47ACF}",
                BlogHomePage = "{68474545-F684-45E4-BEEC-6F5B2E207B96}",
                BlogCategoryPage = "{BBF7DCE5-A729-490C-AF52-BF0EED5657E3}",
                BlogEntryPage = "{D7535E9E-E140-42CB-A284-663F4D4A517B}",
                GenericPage = "{1F77E050-D95F-4ADF-AD54-23F52801A6AC}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
                CampaignPage = "{4F7EA351-1076-4BE0-B1E0-3477ED35174B}",
                DirectApplicationForm = "{4580E10A-E5A4-406E-A103-F93F5E20A194}",
                CallBackLandingPage = "{5D79575B-B346-47BF-AAA7-C0E6F671AB05}"
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
                ButtonGroups = $"{sharedItemPath}/Button Groups",
                ContentBoxes = $"{sharedItemPath}/Content box",
                Galleries = $"{sharedItemPath}/Galleries",
                HeroContent = $"{sharedItemPath}/Hero",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/Language Links",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                SidebarBoxes = $"{sharedItemPath}/Side boxes",
                SharedComboMenus = $"{sharedItemPath}/Combo Menu Items",
                Tabs = $"{sharedItemPath}/Tabs",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Testimonials = $"{sharedItemPath}/Testimonials",
                Widgets = $"{sharedItemPath}/Bottom widgets",
                SocialMedia = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SocialMedia}"
            };
        }

        private List<MiscellaneousSharedItemsFolders> SetMiscellaneousSharedItemsFolders()
        {
            string sharedItemPath = $"{RootPath}{Sitecore8Paths.SharedItemFolderName}";

            List<MiscellaneousSharedItemsFolders> miscSharedFolders = new List<MiscellaneousSharedItemsFolders>();
            miscSharedFolders.Add(new MiscellaneousSharedItemsFolders()
            {
                Sitecore8TemplateId = "{FC68BA49-908F-4587-825D-A21A8BB55A3D}",
                SharedFolderPath = $"{sharedItemPath}/Bottom widgets",
                Sitecore9SharedFolderName = "Bottom widgets"
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
                AccordionItem = "{3A0670BF-A59D-42AD-8448-6F79D457C12D}",
                AccordionContainer = "{CB872ED6-D255-42F6-B6E8-A620D051399E}",
                ButtonGroupContainer = "{407F3462-D21B-4401-8677-9A00B68986FC}",
                CarouselContainer = "{706B26C0-B9D0-42AB-B798-A57F07B42BA8}",
                CarouselSlide = "{D4335FB5-7C3E-4421-B598-49CD4DB184AE}",
                ContentBox = "{76BEC0D2-B788-4401-B3BA-07E45F18D7AF}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{75B78C30-7886-4759-AFF4-EB37739FD219}",
                GalleryContainer = "{DABAB22D-5130-4838-9177-39F582685167}",
                GalleryItem = "{9B255DD8-A196-4F2D-87DC-9BA54D5B748E}",
                Hero = "{D291FA14-0A2F-46F1-A92D-8B66BA0E25B8}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{324139D5-7B5E-4880-970A-11DA6E2F5737}",
                MenuLinks = "{B11492B5-3564-460D-A72D-C296D7CDB8D2}",
                PageItems = "",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{1F358632-9D60-404A-A014-3C0FE0692972}",
                SocialMediaLinks = "{08309868-DEB5-4E86-BA10-0350E9A5CF45}",
                Tab = "{07B5AE11-B211-4959-A7DC-7648AC57501B}",
                TabContainer = "{481B26F6-78E4-4048-8831-6129FBD05EE2}",
                Testimonial = "{D6D912DB-8681-45ED-941E-C6C96D11DDC5}",
                Video = "{24AE4B7A-018A-4A3F-8398-2C7DA9E9E130}",
                Widgets = new List<string> {
                    "{FC68BA49-908F-4587-825D-A21A8BB55A3D}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{3FEF07D4-0857-4548-8B3E-C3E8A81026DF}"
                }
            };
        }
    }
}
