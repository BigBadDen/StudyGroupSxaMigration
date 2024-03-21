using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using System;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class NewsArticlePageToBlogPostMapper : SitecoreItemMapper
    {
        public SgSxaBlogPost Map(NewsArticlePage newsArticlePage)
        {
            SgSxaBlogPost sxaBlogPost = base.MapCommonFields<SgSxaBlogPost, NewsArticlePage>(newsArticlePage);

            sxaBlogPost.Title = newsArticlePage.PageTitle;
            sxaBlogPost.Content = !string.IsNullOrEmpty(newsArticlePage.Article) ? newsArticlePage.Article : newsArticlePage.MainContent;
            sxaBlogPost.Introduction = newsArticlePage.Summary;
            sxaBlogPost.Image = newsArticlePage.ContentImage;
            sxaBlogPost.Thumbnail = newsArticlePage.OverviewImage;
            sxaBlogPost.PublishedDate = newsArticlePage.Date;

            //var keyValuePairs = new Dictionary<string, string>();
            //keyValuePairs.Add("title", newsArticlePage.MetaTitle);
            //keyValuePairs.Add("description", newsArticlePage.MetaDescription);
            //keyValuePairs.Add("keywords", newsArticlePage.MetaKeywords);
            //sxaBlogPost.MatadataKeyValues = keyValuePairs;

            sxaBlogPost.NavigationTitle = newsArticlePage.NavMenuTitle;
            var navigationFilters = new List<string>();
            if (newsArticlePage.HideFromNavigation) navigationFilters.Add(NavigationFilters.Main);
            if (newsArticlePage.HideFromBreadcrumb) navigationFilters.Add(NavigationFilters.Breadcrumb);
            if (newsArticlePage.HideFromSitemap) navigationFilters.Add(NavigationFilters.Sitemap);
            sxaBlogPost.NavigationFilter = String.Join("|", navigationFilters.ToArray());

            sxaBlogPost.BodyCssClass = newsArticlePage.BodyCss;
            sxaBlogPost.BodyId = newsArticlePage.BodyID;
            sxaBlogPost.CannonicalLink = newsArticlePage.CanonicalLink;
            sxaBlogPost.PageKeywords = newsArticlePage.MetaKeywords;
            sxaBlogPost.PageDescription = newsArticlePage.MetaDescription;

            sxaBlogPost.TemplateID = SxaTemplateIds.BlogPost;

            return sxaBlogPost;
        }
    }
}
