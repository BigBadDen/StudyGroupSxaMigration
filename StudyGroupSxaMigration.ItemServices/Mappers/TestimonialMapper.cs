using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class TestimonialMapper : SitecoreItemMapper
    {
        public SgSxaTestimonial Map(Testimonial testimonial)
        {
            SgSxaTestimonial sxaTestimonial = base.MapCommonFields<SgSxaTestimonial, Testimonial>(testimonial);

            sxaTestimonial.TestimonialTitle = testimonial.Title;
            sxaTestimonial.TestimonialImage = testimonial.Image;
            sxaTestimonial.TestimonialContent = testimonial.Content;
            sxaTestimonial.TestimonialDescription = testimonial.Description;

            sxaTestimonial.TemplateID = StudyGroupTemplateIds.Testimonial;

            return sxaTestimonial;
        }
    }
}
