using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class ContentBoxToTextMapper : SitecoreItemMapper
    {
        public SxaText Map(ContentBox contentBox)
        {
            SxaText sxaText = base.MapCommonFields<SxaText, ContentBox>(contentBox);

            sxaText.Text = contentBox.Content;
            sxaText.TemplateID = SxaTemplateIds.Text;

            return sxaText;
        }
    }
}
