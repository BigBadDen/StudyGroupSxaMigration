using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.SitecoreCommon.Models
{
    /// <summary>
    /// Contains a list of sitecore items along with folder details
    /// </summary>
    public class SitecoreItemList<T> where T : SitecoreItem
    {
        public List<T>SitecoreItems { get; set; }
        public string FolderPath { get; set; }
        public string FolderName { get; set; }
    }
}
