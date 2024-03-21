using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore8Models.WidgetsV2
{
    public class GalleryContainer : SitecoreItem
    {
        public List<GalleryItem> GalleryItems { get; set; }
        public string Title { get; set; }
    }
}
