using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites.OldSitesWithBlogsOrNews
{
    public class UiUSA : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public UiUSA()
        {
            RootPath = "/sitecore/content/UiUSA/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/UiUSA";
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
                HomePage = "{258A5A41-9D80-49EC-8E85-16596FFD31E4}",
                HubPage = "{480994B3-1C53-4E0F-92F2-6F5A72105455}",
                ContentPage = "{E4E5A954-708A-4E9B-8A2B-D69C57EED15C}",
                BlogEntryPage = "{28CC1F69-6D14-4FEA-A6E3-E62B216F4C6A}",
                BlogHomePage = "{46663E05-A6B8-422A-8E13-36CD2B041278}",
                BlogCategoryPage = "{E09CEF28-D26E-468D-8852-7F682E6C1138}",
                RSSFeed = "{B960CBE4-381F-4A2B-9F44-A43C7A991A0B}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
                SearchPage = "{536EA392-2B5F-4DD4-A881-FF893668C6F0}"
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
            string sharedItemPath = $"{RootPath}Shared";

            return new SharedItemPaths(sharedItemPath)
            {
                FolderPath = sharedItemPath,
                Accordions = $"{sharedItemPath}/Accordions",
                ButtonGroups = $"{sharedItemPath}/Side Contents/Call To Action Panels",
                Carousels = $"{sharedItemPath}/Carousels",
                ContentBoxes = $"{sharedItemPath}/Contents",
                Maps = $"{sharedItemPath}/Side Contents/Maps",
                ScriptSnippet = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ScriptSnippet}",
                Tabs = $"{sharedItemPath}/Tabs",
                Testimonials = $"{sharedItemPath}/Testimonial Carousel",
                Videos = $"{sharedItemPath}/Side Contents/Videos",
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
                AccordionItem = "{059D0EB9-9BB2-4CA6-A38E-3E642A286754}",
                AccordionContainer = "{A3FBD142-E70C-4C24-AF36-EC257AB4456A}",
                ButtonGroupContainer = "{56B3184F-BD8E-464C-B39B-442DFEE16385}",
                CarouselContainer = "{F85CF185-A91A-4C7A-8FCF-D5EF01496D43}",
                CarouselSlide = "{C0C89308-EB08-44FA-8D88-BA88CB4DFACA}",
                ContentBox = "{5B7F627F-550D-4152-8BEA-2F20D489A105}",
                CTA = "{E58FEBCC-C8F5-4E4D-AEC0-12300085EBA3}",
                GalleryContainer = "",
                GalleryItem = "",
                Hero = "",
                LanguageLinkItem = "",
                LanguageLinks = "",
                LiveChat = "",
                Map = "{6630B4BF-B2E4-4BD3-946A-D75A8CEC6550}",
                MenuLinks = "",
                PageItems = "",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "{F9008FC6-260A-491D-9CBF-9D2DC8CF57B4}",
                SidebarBoxes = "{66B15A1A-D8D0-4E13-8EBC-3E76F5B39FAC}",
                SocialMediaContainer = "{94986F28-A108-4873-A27A-6659EF9CA2E6}",
                SocialMediaLinks = "{540A8264-2FB3-4EC5-8681-80C9E2A3D104}",
                Tab = "{14BDE569-82B4-4545-BA51-B1EAF7CA9B80}",
                TabContainer = "{B992F418-1593-4D61-9E47-C903CDEA6838}",
                Testimonial = "{7D4AE58A-C4A2-408D-9875-1829DA263212}",
                Video = "{8375A9C6-1933-4588-9FC0-B992367646A6}"                
            };
        }
    }
}
