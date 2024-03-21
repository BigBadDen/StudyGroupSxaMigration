using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.SitecoreCommon.Models
{
    public interface ISitecoreItem
    {
        string ItemID { get; set; }
        string ItemName { get; set; }
        string ItemPath { get; set; }
        string ParentID { get; set; }
        string TemplateID { get; set; }
        string TemplateName { get; set; }
        object CloneSource { get; set; }
        string ItemLanguage { get; set; }
        string ItemVersion { get; set; }
        string DisplayName { get; set; }
        bool HasChildren { get; set; }
        string ItemIcon { get; set; }
        string ItemMedialUrl { get; set; }
        string ItemUrl { get; set; }
    }
}
