using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Constants.Constants;
using StudyGroupSxaMigration.SitecoreConstants;

namespace StudyGroupSxaMigration.SitecoreConstants.Websites
{
    public class KingstonV2 : Sitecore8WebsiteConfiguration, ISitecore8WebsiteConfiguration
    {
        public KingstonV2()
        {
            RootPath = $"{Sitecore8Paths.IcsPath}/KingstonV2/";
            WebsiteTemplateIds = SetTemplateIds();
            SharedItemFolderPaths = SetSharedItemsPaths();
            PageTemplates = SetPageTemplates();
            PageItemSubFolders = SetPageItemSubFolders();
            HomePagePath = $"{RootPath}Home";
            MediaLibraryPath = $"{Sitecore8Paths.MediaLibraryPath}/ISC/Kingston V2";
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
                HomePage = "{6E7284FF-A848-4241-A2DD-CD67B629BA70}",
                HubPage = "{7F32A219-7F38-44C7-AC86-8F93C017F150}",
                InternalPage = "{0CAC0EFF-ACE9-4FEC-AB90-A78B3C258CA3}",
                NewsArticlePage = "{F8EC01D8-DDC8-4F3A-AD27-4C76BF1FB02D}",
                NewsListingPage = "{9B5C0DC5-4734-4F65-8DC8-49F8160825E6}",
                BlogHomePage = "{6F1BBF4E-3EC9-411D-B632-8FA8BB919375}",
                BlogCategoryPage = "{F8F39DA1-D6E1-47AD-BE95-FFC291BBCF39}",
                BlogEntryPage = "{325954A5-09EC-48EB-90B0-21776CBD8CAD}",
                GenericPage = "{2164DF97-A3C6-4634-AC6E-C91CE363CFC6}",
                DirectApplicationForm = "{7961F2FC-8F55-4999-8964-CAD3473C0FC5}",
                LandingPage = "{CC7D5C7A-F55C-4673-948E-7848A71025F0}",
                ThanksPage = "{65CE1104-5128-4610-BE1B-07B1551D9931}",
                CampaignPage = "{5296F03D-90A0-4116-BF8E-A93ED2DA417A}"
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
                Languages = $"{sharedItemPath}/Language Links",
                Maps = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Maps}",
                Tabs = $"{sharedItemPath}/{SharedItemDefaultFolderNames.Tabs}",
                ProgressionRoutes = $"{sharedItemPath}/{SharedItemDefaultFolderNames.ProgressionRoutes}",
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
                AccordionItem = "{9C78E3AF-5FEF-4423-A48A-2FD1BFAA85FE}",
                AccordionContainer = "{606AED96-5C86-4FCD-BE51-ADCC9503AB41}",
                ButtonGroupContainer = "{60B450BC-383F-4A0D-B748-273A561FE6B1}",
                CarouselContainer = "{C418A3B7-8CD9-4FCE-8614-123DFC4D145E}",
                CarouselSlide = "{428DE6E2-46C8-46A0-9815-26E5CCE27DA1}",
                ContentBox = "{14232C16-8FF7-4C1D-8BF0-CCE14CE1F28E}",
                ComboMenuItem = "{5F7E0D25-3A23-42DE-BEF7-12A35E2B3A86}",
                CTA = "{2A083C81-B9D4-4C61-99E9-D9BF28878E4F}",
                GalleryContainer = "{43953149-162B-4E36-8A86-07AF2A14B279}",
                GalleryItem = "{FB286E53-C1D9-4429-BB19-166E47CA8C53}",
                Hero = "{7710C311-D5AA-4EEE-9588-A991BCB8F384}",
                LanguageLinkItem = "{4E97B638-DFC3-4EAB-8EFC-3954A023CCF6}",
                LanguageLinks = "{F8401601-F7A6-4FA8-BBD0-B9C4EF669B94}",
                LiveChat = "",
                Map = "{14259834-E881-4786-9D35-00D96A34E550}",
                MenuLinks = "{CB65A0C9-F63C-4F04-B016-865FCB58EBAB}",
                PageItems = "{AA514A05-5CBB-4FA0-9273-39008511EBF5}",
                ProgressionRoutes = "{24D790A8-6B48-43DA-B706-96B6B514D3E4}",
                RelatedLinks = "",
                RelatedLinksWithSections = "",
                ScriptSnippet = "",
                SidebarBoxes = "",
                SocialMediaContainer = "{D202A83C-405D-4240-9E90-321C9B0F04FB}",
                SocialMediaLinks = "{A784029F-5FCA-4B51-9DDE-133A3DC1931E}",
                Tab = "{98C7D38B-C020-4788-B612-4B8EC74E5CA0}",
                TabContainer = "{A37DDBE4-09FC-4AF3-8B6A-F53DAA74EF22}",
                Testimonial = "{4F767DE3-2F8D-4057-BF02-33B557BFBBBE}",
                Video = "{7BD32611-4720-40A4-8BA3-22749AA4D15F}",
                Widgets = new List<string> {
                    "{30AADCD1-5699-40EB-BD1E-CCB67733BC2D}",
                    "{C8CBC622-F743-49DA-B5A4-FFC66CA78AA6}",
                    "{9D76475B-E1E1-4C73-AF3F-A1EACE786512}",
                    "{6D45500E-BB02-4A04-8DCD-DB1FEF9D355B}"
                }
            };
        }
    }
}
