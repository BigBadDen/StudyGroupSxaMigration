using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class ComboMenuMapper : SitecoreItemMapper
    {
        public SgSxaComboMenuItem Map(ComboMenuItem comboMenuItem)
        {
            SgSxaComboMenuItem sxaComboMenuItem = base.MapCommonFields<SgSxaComboMenuItem, ComboMenuItem>(comboMenuItem);

            sxaComboMenuItem.Title = comboMenuItem.Title;
            sxaComboMenuItem.Link = comboMenuItem.Link;
            sxaComboMenuItem.IconCSSClasses = comboMenuItem.IconInput;

            sxaComboMenuItem.TemplateID = StudyGroupTemplateIds.ComboMenuItem;

            return sxaComboMenuItem;
        }
    }
}
