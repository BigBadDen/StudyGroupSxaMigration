using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.SitecoreCommon.Models
{
    /// <summary>
    /// Base class for all sitecore 8 & sitecore 9 item classes. Represents Sitecore.Services.Core.Model.ItemModel
    /// </summary>
    public class SitecoreItem : ISitecoreItem
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemPath { get; set; }
        public string ParentID { get; set; }
        public string TemplateID { get; set; }
        public string TemplateName { get; set; }
        public object CloneSource { get; set; }
        public string ItemLanguage { get; set; }
        public string ItemVersion { get; set; }
        public string DisplayName { get; set; }
        public bool HasChildren { get; set; }
        public string ItemIcon { get; set; }
        public string ItemMedialUrl { get; set; }
        public string ItemUrl { get; set; }
    }
}
