using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaLiveChatFolder : SitecoreItem
    {
        public List<SgSxaLiveChat> LiveChatItems { get; set; }
    }
}
