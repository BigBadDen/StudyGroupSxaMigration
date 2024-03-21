using StudyGroupSxaMigration.Sitecore8Constants;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.SitecoreConstants
{
    /// <summary>
    /// Base class for all website configuration items
    /// </summary>
    public abstract class Sitecore8WebsiteConfiguration
    {
        public string HomePagePath { get; set; }
        public string RootPath { get; set; }
        public string MediaLibraryPath { get; set; }
        public WebsiteTemplates WebsiteTemplateIds { get; set; }
        public SharedItemPaths SharedItemFolderPaths { get; set; }
        public PageTemplates PageTemplates { get; set; }
        public PageDataItemSubFolders PageItemSubFolders { get; set; }
        public List<MiscellaneousSharedItemsFolders> MiscellaneousSharedItemsFolders { get; set;}
    }
}
