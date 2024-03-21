using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using System;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    /// <summary>
    /// Base mapper for all BlogHome page items
    /// </summary>
    public class BlogHomeCommonFieldsMapper : SitecoreItemMapper
    {
        /// <summary>
        ///  Maps common fields for all BlogHome page Items from Sitecore 8 to Sitecore 9
        /// </summary>
        public new TSxaItem MapCommonFields<TSxaItem, TSitecore8Item>(TSitecore8Item sitecore8Item)
            where TSxaItem : SgSxaBlogHome, new()
            where TSitecore8Item : BlogHome
        {
            var sxaItem = base.MapCommonFields<TSxaItem, ContentPageItem>(sitecore8Item);

            var navigationFilters = new List<string>();
            if (sitecore8Item.HideFromNavigation) navigationFilters.Add(NavigationFilters.Main);
            if (sitecore8Item.HideFromBreadcrumb) navigationFilters.Add(NavigationFilters.Breadcrumb);
            if (sitecore8Item.HideFromSitemap) navigationFilters.Add(NavigationFilters.Sitemap);

            sxaItem.NavigationFilter = String.Join("|", navigationFilters.ToArray());
            sxaItem.CannonicalLink = sitecore8Item.CanonicalLink;
            sxaItem.PageDescription = sitecore8Item.MetaDescription;
            sxaItem.PageKeywords = sitecore8Item.MetaKeywords;
            sxaItem.BodyCssClass = sitecore8Item.BodyCss;
            sxaItem.BodyId = sitecore8Item.BodyID;
            sxaItem.NavigationTitle = sitecore8Item.NavMenuTitle;
            sxaItem.Title = sitecore8Item.Title;

            return sxaItem;
        }
    }
}
