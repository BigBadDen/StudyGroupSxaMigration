using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class LancasterV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public LancasterV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Lancaster V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MiscellaneousSharedItemsFolders = SetMiscellaneousSharedItemsFolders();
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/LancasterV2";
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
                HomePage = "{19A37D6E-AD5C-4BD7-9A11-3D42BB74038F}",
                HubPage = "{3C060EDB-CC29-4AA2-9B02-87F431B9E39F}",
                InternalPage = "{C15E0483-12B1-4C60-A026-5BFFDEF0B13F}",
                NewsArticlePage = "{471B6B23-4859-46CD-9954-29A000B75FA5}",
                NewsListingPage = "{948EEAC5-8C3F-4DEB-909B-32402E65B916}",
                DirectApplicationForm = "{4C441713-A1EB-4FE2-BA52-27E5BA85692E}",
                GenericPage = "{729DE659-0C5E-44C9-A396-F0FC4AC7D624}",
                BlogHomePage = "{2FB6D02F-98DF-4335-B314-385446697CDF}",
                BlogCategoryPage = "{CA26517A-0B35-47B5-8E50-397E405B48FF}",
                BlogEntryPage = "{1298FD10-1965-44DF-9FA2-F3F9BB2121C7}",
                SearchPage = "{E4375EBA-753D-45DB-A5D4-4EE4912039F5}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
                CampaignPage = "{7D8971D9-9EB1-4B1B-995A-FE4FE9F3A03E}",
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
                ButtonGroups = $"{sharedItemPath}/Shared Botton Groups",
                Carousels = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Carousels}",
                ContentBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ContentBoxes}",
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
                HeroContent = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeroContent}",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                LiveChat = $"{sharedItemPath}/Live Agent",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                ScriptSnippet = $"{sharedItemPath}/ScriptSnippet",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
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
                Sitecore8TemplateId = "{AC7DF6CD-2255-43C2-8C96-0F7147EF64F9}",
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
                AccordionItem = "{FB30B435-58FB-4DA0-A5BF-AD1B989EB6F4}",
                AccordionContainer = "{26EF3A26-2C55-4CF2-8E42-F0AEE8723AF7}",
                ButtonGroupContainer = "{2B2F42C3-2566-46E2-A9A1-FC89E85CEA0B}",
                CarouselContainer = "{54291035-90A8-4212-AADF-C9CC4707D012}",
                CarouselSlide = "{CDBDB46C-95CA-4630-902A-C76F0DE172F2}",
                ContentBox = "{03A9A67A-B699-446C-947C-2C6C8D5AC9DE}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{027D0B63-2C0B-455C-9450-02625E9FC6CF}",
                GalleryContainer = "{C33A89A8-576E-447C-9F2E-274924FE0947}",
                GalleryItem = "{566DFA46-43A4-46D3-BF6D-98D6D5D0122D}",
                Hero = "{AD4CD753-6046-424C-BDE7-04AB3D49C36D}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "{3836CC3C-7293-4355-B33B-AF8F98E2B47E}",
                Map = "{7CC1A495-ADA6-4935-9B36-BA34C1623FF5}",
                MenuLinks = "{CDCC669C-DEF3-4469-A398-40F6B17F04F5}",
                PageItems = "{B0B79498-1C2B-4223-8C47-A16E685DDADE}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
                SidebarBoxes = "",
                SocialMediaContainer = "{BDF7289E-02E2-450A-ACE3-D20F907EC904}",
                SocialMediaLinks = "{94CDF550-6337-462D-971F-8229EDB50CC2}",
                Tab = "{17D5051C-9E36-4539-A405-E37E43AB6A82}",
                TabContainer = "{AEC2D0BA-EA0D-4049-8FD0-E2C8B4420CF9}",
                Testimonial = "{EBC307A2-A7BC-4246-8049-07A1C9EA9636}",
                Video = "{B27AC8A9-2B7E-4C5F-BCB6-97A5B539F750}",
                Widgets = new List<string> {
                    "{AC7DF6CD-2255-43C2-8C96-0F7147EF64F9}",
                    "{6838E4CD-43F9-48C5-803C-AC84F30B2B77}",
                    "{BE829BA1-8218-42BD-ABF7-C79416E8C1B3}",
                    "{F181C037-B482-4921-840C-888A2F0A4D75}",
                    "{B36BBAA7-4234-4A0F-BEF0-42EFC1E72D78}",
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
