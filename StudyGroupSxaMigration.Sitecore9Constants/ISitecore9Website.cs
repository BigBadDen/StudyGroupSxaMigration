using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Sitecore9Constants
{
    public interface ISitecore9Website
    {
        string RootPath { get; set; }
        string HomePagePath { get; set; }
        string BlogHomePath { get; set; }

        string DataFolderName { get; set; }
        SharedItemPaths SharedItemPaths { get; set; }
    }
}
