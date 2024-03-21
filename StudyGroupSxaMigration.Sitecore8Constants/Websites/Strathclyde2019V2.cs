using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class Strathclyde2019V2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public Strathclyde2019V2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Strathclyde 2019 V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Strathclyde 2019 V2";
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
                HomePage = "{00D9E4D1-70A9-4836-A3F1-4E601569AEA6}",
                HubPage = "{8BFB50B6-0A52-4838-90C7-D04FE379FB77}",
                InternalPage = "{A0552B78-0C85-4799-9654-7FDF6C93CB9A}",
                BlogEntryPage = "{6D6A71B0-D470-407C-81FD-6341EF266519}",
                BlogCategoryPage = "{2390E5DB-42C9-4CA3-BCDE-E63078169484}",
                BlogHomePage = "{69E0C621-5C6C-477A-B486-0215ABD9306B}",
                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
                DirectApplicationForm = "{B3BBFBA3-C18C-413F-B4CF-BFBE12C84265}"
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
                AccordionItem = "",
                AccordionContainer = "",
                ButtonGroupContainer = "{ED92EA4A-0EF1-4B2C-9F3A-FAFEC1C93D36}",
                CarouselContainer = "{5B0ADB92-168A-463C-8AFE-A97A19D32F54}",
                CarouselSlide = "{513AFED6-DF40-4279-985B-4DE0C6D0D68F}",
                ContentBox = "{A4BA13CC-BE63-4915-A33F-449D58AF91F7}",
                CTA = "{CEF1ECFE-37B5-4614-8E24-9A16AA35C883}",
                GalleryContainer = "{AC4D3F1B-489C-4F95-A2EC-012D7BAC65D0}",
                GalleryItem = "{B98FA204-2316-4EF4-971B-7592A3AD54F9}",
                Hero = "{D21E5C14-3624-409C-BD1F-AD82907A91F9}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{5F2569E4-D2BB-4E5E-81AA-E9136903DAD5}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{4F76C71A-532D-4411-A5D8-9844B4E4F340}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{321B9332-A87A-4ECC-912F-5D757C711FBB}",
                TabContainer = "{15474772-0170-433D-8CA7-D502911F3232}",
                Testimonial = "{906A240F-C4A9-4698-8985-0A7A1443714B}",
                Video = "{EB9B1048-D90E-4FB4-8EE8-D9BE4F729766}",
                Widgets = new List<string> {
                    "{4E5E1BD8-BB82-43B3-B4F6-E77D71ECA457}",
                    "{5E030CF5-6849-42DA-A51D-52D9B0EEA337}",
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
