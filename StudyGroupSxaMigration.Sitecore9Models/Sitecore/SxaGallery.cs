using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.Sitecore
{
    public class SxaGallery : SitecoreItem
    {
        public List<SxaGalleryImage> Images { get; set; }
        public List<SxaGalleryVideo> Videos { get; set; }
    }
}
