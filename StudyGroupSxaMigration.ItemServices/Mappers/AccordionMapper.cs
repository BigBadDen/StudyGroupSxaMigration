using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class AccordionMapper : SitecoreItemMapper
    {
        public SxaAccordionItem Map(AccordionItem accordionItem)
        {
            SxaAccordionItem sxaAccordion = base.MapCommonFields<SxaAccordionItem, AccordionItem>(accordionItem);

            sxaAccordion.Heading = accordionItem.Heading;
            sxaAccordion.Content = accordionItem.Content;

            sxaAccordion.TemplateID = SxaTemplateIds.AccordionItem;

            return sxaAccordion;
        }
    }
}
