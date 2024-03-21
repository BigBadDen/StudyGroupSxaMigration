using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class HeroMapper : SitecoreItemMapper
    {
        public SgSxaHero Map(Hero hero)
        {
            SgSxaHero sxaHero = base.MapCommonFields<SgSxaHero, Hero>(hero);

            sxaHero.HeroImage = hero.Image;
            sxaHero.HeroText = hero.Content;
            sxaHero.HeroLink1 = hero.Link;

            sxaHero.TemplateID = StudyGroupTemplateIds.Hero;

            return sxaHero;
        }
    }
}
