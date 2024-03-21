using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class LynnV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public LynnV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/Lynn V2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Lynn V2";
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
                HomePage = "{615E94FB-A7CA-499F-B256-E05A48E92003}",
                HubPage = "{03705A66-587D-4A39-979F-1BA7BADD3C93}",
                InternalPage = "{9DE9153B-B9CD-4110-99B6-C9AF7E70EBD0}",
                NewsArticlePage = "{C2CF0BBB-0B97-491C-A58B-8D991119E7C7}",
                NewsListingPage = "{5240095C-CA6A-40AD-90D8-0CCED37E78D5}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}"
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
                AccordionItem = "{18A9F7FF-24D2-4E62-AA4E-12980364FD75}",
                AccordionContainer = "{83B28A0A-2EE8-47C4-B7E1-361A8465535E}",
                ButtonGroupContainer = "{7627583E-DAEB-49E2-8265-F11F7DA11EFA}",
                CarouselContainer = "{1C30FEFC-821B-40B4-A5E9-A194921E811B}",
                CarouselSlide = "{4DE13E87-FE0F-483A-8777-48A8E5CD2A14}",
                ContentBox = "{C2227C24-9347-41D3-8965-31AD7A38F650}",
                CTA = "{AD8DACD2-CA77-4330-8A7A-385FE68C836C}",
                GalleryContainer = "{8B58C608-16AB-4AA9-AE9F-41AF8FDB3974}",
                GalleryItem = "{E1C40C9C-0354-48A1-994D-23CC1847C26A}",
                Hero = "{DA10C017-EA24-4286-B22A-221B10B3CCBB}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{D7593E09-6043-44E4-80E8-036767EB55DE}",
                MenuLinks = "{BACD0C87-02DF-4E7C-8307-D4DCFACDAF58}",
                PageItems = "{77D6A7CB-E6AA-4760-ADA7-C6968C4F4340}",
                ProgressionRoutes = "",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{9DBD2482-7E9D-4E46-AB82-8FA4B08AA9C0}",
                SocialMediaLinks = "{AEE4D667-66AC-46E0-8694-3DE4749788C9}",
                Tab = "{5121AE9B-6D72-410B-AF98-F372274BCE6E}",
                TabContainer = "{7DF2D898-5C95-4341-AE43-4E98357C5D64}",
                Testimonial = "{ED6CF400-2ACA-42D1-86E5-B5ED6B7A355B}",
                Video = "{1E9D6F9B-3902-4C68-A46A-EA11D2888F2C}",
                Widgets = new List<string>
                {
                    "{E27E36F0-39E1-417E-A820-670D58E248BB}",
                    "{64DA78D3-176F-424B-8B56-715A262416F8}",
                    "{3FEF07D4-0857-4548-8B3E-C3E8A81026DF}"
                }
            };
        }
    }
}
