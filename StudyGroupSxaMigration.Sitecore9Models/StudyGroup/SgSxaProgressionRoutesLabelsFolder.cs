using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaProgressionRoutesLabelsFolder : SitecoreItem
    {
        public List<SgSxaProgressionRoutesLabels> ProgressionRoutesLabelItems { get; set; }
    }
}
