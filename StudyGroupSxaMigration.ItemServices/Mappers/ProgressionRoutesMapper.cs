using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class ProgressionRoutesMapper : SitecoreItemMapper
    {
        public SgSxaProgressionRoutesTable Map(ProgressionRoutes progressionRoutes)
        {
            SgSxaProgressionRoutesTable sxaProgressionRoutesTable = base.MapCommonFields<SgSxaProgressionRoutesTable, ProgressionRoutes>(progressionRoutes);

            sxaProgressionRoutesTable.CentreId = progressionRoutes.CentreID;
            sxaProgressionRoutesTable.ArticleId = progressionRoutes.ArticleID;
            sxaProgressionRoutesTable.DisplayGradeModule = progressionRoutes.DisplayGradeModule;
            sxaProgressionRoutesTable.PageSize = progressionRoutes.PageSize;

            sxaProgressionRoutesTable.TemplateID = StudyGroupTemplateIds.ProgressionRoutesTable;

            return sxaProgressionRoutesTable;
        }
    }
}
