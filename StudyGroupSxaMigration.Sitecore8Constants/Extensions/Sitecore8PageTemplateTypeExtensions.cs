using StudyGroupSxaMigration.SitecoreConstants;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Sitecore8Constants.Extensions
{
    public static class Sitecore8PageTemplateTypeExtensions
    {
        public static bool HasBlogPageTemplate(this ISitecore8WebsiteConfiguration sitecore8Website)
        {
            return !string.IsNullOrWhiteSpace(sitecore8Website.PageTemplates.BlogHomePage);
        }

        public static bool HasBlogCategoryPageTemplate(this ISitecore8WebsiteConfiguration sitecore8Website)
        {
            return !string.IsNullOrWhiteSpace(sitecore8Website.PageTemplates.BlogCategoryPage);
        }

        public static bool HasBlogEntryPageTemplate(this ISitecore8WebsiteConfiguration sitecore8Website) {
            return !string.IsNullOrWhiteSpace(sitecore8Website.PageTemplates.BlogEntryPage);
        }

        public static bool HasNewsListingPageTemplate(this ISitecore8WebsiteConfiguration sitecore8Website) {
            return !string.IsNullOrWhiteSpace(sitecore8Website.PageTemplates.NewsListingPage);
        }

        public static bool HasNewsArticlePageTemplate(this ISitecore8WebsiteConfiguration sitecore8Website) {
            return !string.IsNullOrWhiteSpace(sitecore8Website.PageTemplates.NewsArticlePage);
        }

        public static bool HasHomePageTemplate(this ISitecore8WebsiteConfiguration sitecore8Website) {
            return !string.IsNullOrWhiteSpace(sitecore8Website.PageTemplates.HomePage);
        }

        public static bool HasHubPageTemplate(this ISitecore8WebsiteConfiguration sitecore8Website) {
            return !string.IsNullOrWhiteSpace(sitecore8Website.PageTemplates.HubPage);
        }

        public static bool HasInternalPageTemplate(this ISitecore8WebsiteConfiguration sitecore8Website) {
            return !string.IsNullOrWhiteSpace(sitecore8Website.PageTemplates.InternalPage);
        }

        public static bool HasGenericPageTemplate(this ISitecore8WebsiteConfiguration sitecore8Website)
        {
            return !string.IsNullOrWhiteSpace(sitecore8Website.PageTemplates.GenericPage);
        }

        public static bool HasCampaignPageTemplate(this ISitecore8WebsiteConfiguration sitecore8Website)
        {
            return !string.IsNullOrWhiteSpace(sitecore8Website.PageTemplates.CampaignPage);
        }
    }
}
