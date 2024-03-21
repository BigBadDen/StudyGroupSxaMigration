using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.Sitecore8Constants.Websites
{
    public class Sheffield2019V2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public Sheffield2019V2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Sheffield 2019 V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Sheffield 2019 V2";
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
                HomePage = "{0AD760B5-4A1E-43E7-AC48-616E07E6F230}",
                HubPage = "{9C06B4DB-8859-409B-85E7-12D2EDBC6240}",
                InternalPage = "{ACA11D89-4220-444B-8C78-81C64653A4B5}",
                BlogEntryPage = "{162AA90F-CD6B-4863-AB31-EBE746F912DA}",
                BlogCategoryPage = "{12308770-DB48-4E0B-9C9E-8E8183948867}",
                BlogHomePage = "{3B2D1CD9-086F-4D0F-A860-558D86C2E381}",
                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
                CampaignPage = "{D22DCE81-750D-4665-8098-EC5A4431CAA1}",
                LandingPage = "{672D235E-A259-41A3-8AD1-756D893592CF}",
                ThanksPage = "{596ABC77-BC16-41FF-811D-907346AE1AD3}",
                DirectApplicationForm = "{802BBE4A-9114-420C-B418-48E10C239174}"
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
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                Testimonials = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Testimonials}",
                Videos = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Videos}",
                Widgets = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Widgets}",
                SharedComboMenus = $"{sharedItemPath}/Footer Combo Menu Items",
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
                AccordionItem = "{AAEC3B1E-172B-4BBE-93AC-3957B889475B}",
                AccordionContainer = "{8778F40F-B9DE-41FB-AA2F-365906E8ED4C}",
                ButtonGroupContainer = "{279BFD63-09F8-45C9-9978-9849751C5AD1}",
                CarouselContainer = "{A6BB5CAB-AFE4-408B-8FE4-1593C0E73259}",
                CarouselSlide = "{3B523630-E7DA-4D8E-8821-44A64EEE0D32}",
                ContentBox = "{D049904F-987B-4F25-B62D-66CB56DE4218}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{B40A4DFD-9064-459C-92E2-714378A777FC}",
                GalleryContainer = "{8EB317D3-CF2E-4E1E-B127-561D0AA40E88}",
                GalleryItem = "{39DE4BEC-0186-4600-A3D6-A27EE5BA81DB}",
                Hero = "{23590EC6-AD6E-40E8-820D-C361E15F23F1}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{52DC3B09-5DDA-4A02-B3B8-A75591CC1F2D}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{30079CED-7884-442E-8FB8-6F9428431FBD}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{1D486846-E845-489B-AEBC-D31928EFD235}",
                TabContainer = "{D87C241E-DCB5-4CC0-B833-EC3A3B7B281F}",
                Testimonial = "{C3B0BF4C-70B8-4A0C-B3BC-128EEF432C70}",
                Video = "{EF7CD936-8727-4202-B999-F73C08B7C08D}",
                Widgets = new List<string>
                {
                    "{4E5E1BD8-BB82-43B3-B4F6-E77D71ECA457}",
                    "{5FF55F6A-F2C2-4CA3-882D-E1A0636EE0AB}",
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}",
                    "{14D566B0-19E1-4C53-B709-84C5249ED458}",
                    "{21454E80-AAE9-4E03-8939-05CB2ACFC0DD}",
                    "{D386BBE5-46E3-427F-A992-5A9782FF6A71}"
                }
            };
        }
    }
}
