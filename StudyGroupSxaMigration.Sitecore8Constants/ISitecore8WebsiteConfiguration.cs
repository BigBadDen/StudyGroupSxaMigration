using StudyGroupSxaMigration.Sitecore8Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.SitecoreConstants
{
    public interface ISitecore8WebsiteConfiguration
    {
        string RootPath { get; set; }
        string HomePagePath { get; set; }
        string MediaLibraryPath { get; set; }
        WebsiteTemplates WebsiteTemplateIds { get; set; }
        SharedItemPaths SharedItemFolderPaths { get; set; }
        PageTemplates PageTemplates { get; set; }
        PageDataItemSubFolders PageItemSubFolders { get; set; }
        List<MiscellaneousSharedItemsFolders> MiscellaneousSharedItemsFolders { get; set; }
    }
}
