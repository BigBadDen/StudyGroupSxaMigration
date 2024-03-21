using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using System;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class ContentPageMapper : SitecoreItemMapper
    {
        /// <summary>
        /// Update meta fields (title and page description)
        /// </summary>
        /// <param name="sitecorePageItem"></param>
        /// <returns></returns>
        public SxaPageItem Map(ContentPageItem sitecorePageItem)
        {
            SxaPageItem sxaPageItem = new SxaPageItem();

            sxaPageItem.Title = sitecorePageItem.PageTitle;
            sxaPageItem.MetaDescription = sitecorePageItem.MetaDescription;
            sxaPageItem.NavigationTitle = sitecorePageItem.NavMenuTitle;

            return sxaPageItem;
        }
        
        private string GetMetaTitle(ContentPageItem sitecorePageItem)
        {
            return !String.IsNullOrWhiteSpace(sitecorePageItem.MetaTitle) ?
                        sitecorePageItem.MetaTitle :
                        (!String.IsNullOrWhiteSpace(sitecorePageItem.NavMenuTitle) ? sitecorePageItem.NavMenuTitle : sitecorePageItem.PageTitle);
         
        }
    }
}
