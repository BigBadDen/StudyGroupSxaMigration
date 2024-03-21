using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class ProgressionRoutesLabelsMapper : SitecoreItemMapper
    {
        public SgSxaProgressionRoutesLabels Map(ProgressionRouteLabels progressionRouteLabels)
        {
            SgSxaProgressionRoutesLabels sxaProgressionRoutesLabels = base.MapCommonFields<SgSxaProgressionRoutesLabels, ProgressionRouteLabels>(progressionRouteLabels);

            sxaProgressionRoutesLabels.EmptyTable = progressionRouteLabels.NoDataLabel;
            sxaProgressionRoutesLabels.DegreeProgrammes = progressionRouteLabels.DegreeProgrammesLabel;
            sxaProgressionRoutesLabels.Awards = progressionRouteLabels.AwardsLabel;
            sxaProgressionRoutesLabels.OverallGrade = progressionRouteLabels.OverallGradeLabel;
            sxaProgressionRoutesLabels.EnglishGrade = progressionRouteLabels.EnglishGradeLabel;
            sxaProgressionRoutesLabels.GradeModule = progressionRouteLabels.GradeModuleLabel;
            sxaProgressionRoutesLabels.FromUniversity = progressionRouteLabels.UniversityLabel;
            sxaProgressionRoutesLabels.ToUniversity = progressionRouteLabels.ToUniversityLabel;
            sxaProgressionRoutesLabels.FromArticle = progressionRouteLabels.FromArticleLabel;

            sxaProgressionRoutesLabels.TemplateID = StudyGroupTemplateIds.ProgressionRoutesLabels;

            return sxaProgressionRoutesLabels;
        }
    }
}
