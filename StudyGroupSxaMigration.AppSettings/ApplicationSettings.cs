using System.Collections.Generic;

namespace StudyGroupSxaMigration.AppSettings
{
    public class ApplicationSettings
    {
        public bool CreateSubFoldersIfMissing { get; set; }
        public bool DryRunMode { get; set; }
        public bool CheckForInconsistentFolderNaming { get; set; }
        public bool CheckOtherFoldersIfDataItemsInExpectedLocation { get; set; }
        
        public int MaximumPageHierarchyDepth { get; set; }
        public ConsoleSettings ConsoleSettings { get; set; }
        public ExceptionSettings ExceptionSettings { get; set; }
        public IntegrationServiceSettings IntegrationServiceSettings { get; set; }
        public WebsiteSettings WebsiteSettings { get; set; }
        public List<string> MigrationsToExlude { get; set; }
        public List<string> BlogDataItemMigrations { get; set; }
        public SitecoreLogin SitecoreLogin { get; set; }
    }
}
