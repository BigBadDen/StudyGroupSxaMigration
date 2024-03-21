using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class BlogPostMapper : BlogPostCommonFiledsMapper
    {
        public SgSxaBlogPost Map(BlogEntry blogEntry)
        {
            SgSxaBlogPost sxaBlogPost = base.MapCommonFields<SgSxaBlogPost, BlogEntry>(blogEntry);

            sxaBlogPost.Content = blogEntry.Content;
            sxaBlogPost.Introduction = blogEntry.Introduction;

            sxaBlogPost.Image = blogEntry.BlogImage;
            sxaBlogPost.Thumbnail = blogEntry.BlogThumbnailImage;
            sxaBlogPost.PublishedDate = blogEntry.EntryDate;

            //var keyValuePairs = new Dictionary<string, string>();
            //keyValuePairs.Add("title", blogEntry.MetaTitle);
            //keyValuePairs.Add("description", blogEntry.MetaDescription);
            //keyValuePairs.Add("keywords", blogEntry.MetaKeywords);
            //sxaBlogPost.MatadataKeyValues = keyValuePairs;

            if (!string.IsNullOrEmpty(blogEntry.Category))
            {
                //Use Category field's value in sitecore 8 Blog Entry item as Tags field's value in Sitecore 9 Blog Post item
                sxaBlogPost.Tags = blogEntry.Category;
            }
            else //incase Category field's value is empty or missing, use parent item - Blog Category Item - as Tags
            {
                sxaBlogPost.Tags = "{" + blogEntry.ParentID + "}";
            }

            sxaBlogPost.TemplateID = SxaTemplateIds.BlogPost;

            return sxaBlogPost;
        }
    }
}
