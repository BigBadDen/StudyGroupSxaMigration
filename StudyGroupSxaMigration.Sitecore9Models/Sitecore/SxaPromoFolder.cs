using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.Sitecore
{
    public class SxaPromoFolder : SitecoreItem
    {
        public List<SxaPromo> PromoItems { get; set; }
    }
}
