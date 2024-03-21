using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class TabsMapper : SitecoreItemMapper
    {
        public SxaTabItem Map(Tab tab)
        {
            SxaTabItem sxaTabItem = base.MapCommonFields<SxaTabItem, Tab>(tab);

            sxaTabItem.Heading = tab.Title;
            sxaTabItem.Content = tab.Content;

            sxaTabItem.TemplateID = SxaTemplateIds.TabItem;

            return sxaTabItem;
        }
    }
}
