using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.AppSettings
{
    public class ExceptionSettings
    {
        public bool SkipItemsWithSitecore8BrokenItemLinks { get; set; }
        public bool SkipItemsWithSitecore8BrokenMediaLinks { get; set; }
        public bool SkipItemsWithSitecore9BrokenItemLinks { get; set; }
        public bool SkipItemsWithSitecore9BrokenMediaLinks { get; set; }
    }
}
