using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using System;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class NewsListingPageToBlogHomeMapper : SitecoreItemMapper
    {
        public SgSxaBlogHome Map(NewsListingPage newsListingPage)
        {
            SgSxaBlogHome sxaBlogHome = base.MapCommonFields<SgSxaBlogHome, NewsListingPage>(newsListingPage);

            sxaBlogHome.Title = newsListingPage.PageTitle;
            sxaBlogHome.Content = !string.IsNullOrEmpty(newsListingPage.PageContentTitle) ? newsListingPage.PageContentTitle : newsListingPage.MainContent;

            var keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("title", newsListingPage.MetaTitle);
            keyValuePairs.Add("description", newsListingPage.MetaDescription);
            keyValuePairs.Add("keywords", newsListingPage.MetaKeywords);
            //sxaBlogHome.MatadataKeyValues = keyValuePairs;

            sxaBlogHome.NavigationTitle = newsListingPage.NavMenuTitle;

            //TODO - this needs to write a pipe-delimited list of guids; one is listed for each navigation filter. e.g. {E0A2A027-0932-4878-A7D6-0416D5263EFB}|{D063E9D1-C7B5-4B1E-B31E-69886C9C59F5}
            // So we need to store the id of each navigation filter in Sitecore9Constants

            var navigationFilters = new List<string>();
            if (newsListingPage.HideFromNavigation) navigationFilters.Add(NavigationFilters.Main);
            if (newsListingPage.HideFromBreadcrumb) navigationFilters.Add(NavigationFilters.Breadcrumb);
            if (newsListingPage.HideFromSitemap) navigationFilters.Add(NavigationFilters.Sitemap);
            sxaBlogHome.NavigationFilter = String.Join("|", navigationFilters.ToArray());

            sxaBlogHome.BodyCssClass = newsListingPage.BodyCss;
            sxaBlogHome.BodyId = newsListingPage.BodyID;
            sxaBlogHome.CannonicalLink = newsListingPage.CanonicalLink;
            sxaBlogHome.PageKeywords = newsListingPage.MetaKeywords;
            sxaBlogHome.PageDescription = newsListingPage.MetaDescription;

            sxaBlogHome.TemplateID = SxaTemplateIds.BlogHome;

            return sxaBlogHome;
        }
    }
}
