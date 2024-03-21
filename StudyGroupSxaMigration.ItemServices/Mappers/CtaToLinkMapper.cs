using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using StudyGroupSxaMigration.Sitecore8Models.Sitecore;
using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class CtaToLinkMapper : SitecoreItemMapper
    {
        public SxaLink Map(CallToAction cta)
        {
            SxaLink sxaLink = base.MapCommonFields<SxaLink, CallToAction>(cta);

            sxaLink.Link = cta.Link;
            sxaLink.TemplateID = SxaTemplateIds.Link;

            return sxaLink;
        }
    }
}
