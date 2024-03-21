using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class WidgetMapper : SitecoreItemMapper
    {
        public SgSxaWidget Map(Widget widget)
        {
            SgSxaWidget sxaWidget = base.MapCommonFields<SgSxaWidget, Widget>(widget);

            sxaWidget.WidgetTitle = widget.Title;
            sxaWidget.WidgetContent = widget.Content;
            sxaWidget.WidgetImage = widget.Image;
            sxaWidget.WidgetLink = widget.Link;
            sxaWidget.WidgetLinkText = widget.LinkText;
            sxaWidget.TemplateID = StudyGroupTemplateIds.Widget;

            return sxaWidget;
        }
    }
}
