using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.Sitecore8Constants.Websites
{
    public class LincolnWBDLV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public LincolnWBDLV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Lincoln WBDL V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/LincolnWBDLV2";
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
                HomePage = "{50D37A21-69BC-45A9-8764-DACF4B61F616}",
                HubPage = "{4FCA7E69-0830-488F-ABA7-1AA6F75DDC64}",
                InternalPage = "{2769C9E9-3C41-468A-87B9-3230B1272747}",
                NewsArticlePage = "{9C79BFA9-39D1-45C1-AC9E-4E690565E3A6}",
                NewsListingPage = "{8356F331-1A65-4A3E-AE4E-E9ABC765EA14}",
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
                Galleries = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Galleries}",
                HeroContent = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeroContent}",
                HeaderAndFooterLinks = $"{sharedItemPath}/{SharedItemDefaultFolderNames.HeaderAndFooterLinks}",
                Languages = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Languages}",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
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
                AccordionItem = "{F0CD47F5-B7B2-41E3-9616-5FB7FA6EFC48}",
                AccordionContainer = "{61A5AB75-B639-4A3F-95E9-4B1499B63F03}",
                ButtonGroupContainer = "{2AEF7217-492B-4864-859B-29B7FAB89E84}",
                CarouselContainer = "{A26E4222-1859-4780-BE7F-13A5B62105D2}",
                CarouselSlide = "{32DE8399-1CDC-4109-BFD8-EE014AD80572}",
                ContentBox = "{98343164-F034-46FD-81EB-4408BBEC4E3B}",
                CTA = "{1903610B-DFFA-4A1D-A77A-1CE9725BA8CC}",
                GalleryContainer = "{943AD2F1-EB01-44BE-AC22-098697AEF54A}",
                GalleryItem = "{E39CB9DB-1A77-44CF-9408-E538FB1A6927}",
                Hero = "{F5CA9B9B-E3B2-4E42-9E19-3C2236CBF6B4}",
                LanguageLinkItem = "{33F9CF77-7956-48E9-AB8C-C27F8BED1D35}",
                LanguageLinks = "",
                LiveChat = "",
                Map = "{F11A8E57-84B8-4C53-BE21-5C99C66A62FD}",
                MenuLinks = "{78173C43-93C5-48BE-BE9C-A79878EEA2B8}",
                PageItems = "{EC8EF81F-7C38-4DAD-8697-E06CB31EAF89}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{4ACB1F5A-AA1A-4983-85BB-9BAF21C54E38}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{8DBFB5C1-3E20-4EB5-B85E-91E2C138446A}",
                TabContainer = "{5481A010-8225-4A0B-823A-AEBA3BD1085A}",
                Testimonial = "{A01368FD-D5B2-47F6-8243-0B4FA67A81D5}",
                Video = "{2EF64D60-78A2-44D1-888F-C674E9F8A6A9}",
                Widgets = new List<string>
                {
                    "{DE206068-9126-4F0A-A0B1-D75FCE89E148}",
                    "{CBBAA88D-0BD2-470B-BDA6-635C8D2CA196}",
                    "{F2B9EB33-D4ED-419F-AAF8-FC5BDA3F638B}",
                    "{CE4DFC59-B577-4C2A-AE71-E120EE2931C1}",
                    "{3FEF07D4-0857-4548-8B3E-C3E8A81026DF}"
                }
            };
        }
    }
}
