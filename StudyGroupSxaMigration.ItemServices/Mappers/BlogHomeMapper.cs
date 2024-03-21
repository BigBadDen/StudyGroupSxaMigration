using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class BlogHomeMapper : BlogHomeCommonFieldsMapper
    {
        public SgSxaBlogHome Map(BlogHome blogHome)
        {
            SgSxaBlogHome sxaBlogHome = base.MapCommonFields<SgSxaBlogHome, BlogHome>(blogHome);

            //TO DO !
            //var keyValuePairs = new Dictionary<string, string>();
            //keyValuePairs.Add("title", blogHome.MetaTitle);
            //keyValuePairs.Add("description", blogHome.MetaDescription);
            //keyValuePairs.Add("keywords", blogHome.MetaKeywords);
            //sxaBlogHome.MatadataKeyValues = keyValuePairs;

            sxaBlogHome.TemplateID = SxaTemplateIds.BlogHome;

            return sxaBlogHome;
        }
    }
}
