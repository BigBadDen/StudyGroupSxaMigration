using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.Sitecore8Constants.Websites.OldSitesWithBlogsOrNews
{
    public class Merrimack : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public Merrimack()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Merrimack v2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Merrimack";
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
                HomePage = "{8E3009C1-CF89-4EBE-81A8-E690868749B8}",
                HubPage = "{9153561B-DE44-4D2F-911B-6DD0C29C6DF8}",
                BlogEntryPage = "{9100F066-7769-471B-A269-832B85DB7410}",
                BlogHomePage = "{A89EE392-6E5E-4B16-B6F1-833C8DA80781}",
                BlogCategoryPage = "{7EFE5D10-DEF0-4413-8C85-FD770E0A7325}",
                NewsArticlePage = "{3048C2A7-9EC0-4733-8738-E27628518243}",
                FormPage = "{CC242938-8CD9-4475-8836-96E648634CC7}",
                ProgrammePage = "{6B6ECE83-9CB0-4686-BAE7-07EB58833563}",
                ContentPage = "{C0FB3EBE-28A7-41BF-804D-2DE4E55A0760}"
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
                ButtonGroups = $"{sharedItemPath}/Call to Action Panels",
                Carousels = $"{sharedItemPath}/Carousels",
                SidebarBoxes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.SidebarBoxes}",
                Tabs = $"{sharedItemPath}/Tabbed Content",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
                Testimonials = $"{sharedItemPath}/Testimonials",
                Videos = $"{sharedItemPath}/Videos",
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
                AccordionItem = "{FD8E0696-04B5-4DE6-A5AA-C5B5C6783B99}",
                AccordionContainer = "{F7405B2A-32A6-4781-B8F4-B47A10B89235}",
                ButtonGroupContainer = "{F58793DF-B6B2-46C9-8569-7713F8BA14AA}",
                CarouselContainer = "{4D820BB6-5BFA-44C5-A4D4-6BCDA5DDC275}",
                CarouselSlide = "{2E659420-D27E-4754-84C1-EE2A0493EAD2}",
                ContentBox = "{031336C4-A1A3-440B-AFED-85549D7CE808}",
                CTA = "{8C6E3D17-F7FE-42F8-BF3C-721881570739}",
                GalleryContainer = "{73B494C4-8A59-4125-B4F6-272BDFC9E6FE}",
                GalleryItem = "{938ED6F2-76A0-4BCB-82BC-308DD1188621}",
                Hero = "{A572E796-53B5-4F6E-B4B6-7220DC2FA1E3}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{5232EA98-57D4-46C7-AA57-040112924A79}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{4DA435B0-642B-439C-AEE4-66AF7425D2C8}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "{65A7ADAE-C779-48A6-BB7C-66AAD4A2046C}",
                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
                Tab = "{2E322305-4E10-42CD-8CBC-05158E2F22DE}",
                TabContainer = "",
                Testimonial = "{606D7801-9523-413E-BA3B-DEA01D9E27DC}",
                Video = "{0B3C9CF4-1254-409D-A605-0E57550C7AC1}",
                Widgets = new List<string>
                {
                    "{EDFFE774-A83C-4BB4-AC2F-430A449EC98A}"
                }
            };
        }
    }
}
