using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaTestimonialFolder : SitecoreItem
    {
        public List<SgSxaTestimonial> TestimonialItems { get; set; }
    }
}
