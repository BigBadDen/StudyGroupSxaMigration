using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class LiveChatMapper : SitecoreItemMapper
    {
        public SgSxaLiveChat Map(LiveChat liveChat)
        {
            SgSxaLiveChat sxaLiveChat = base.MapCommonFields<SgSxaLiveChat, LiveChat>(liveChat);

            sxaLiveChat.LiveChatId = liveChat.LiveChatId;
            sxaLiveChat.OnlineMessage = liveChat.OnlineMessage;
            sxaLiveChat.OfflineMessage = liveChat.OfflineMessage;
            sxaLiveChat.Script = liveChat.Script;
            sxaLiveChat.HideLiveChat = liveChat.HideLiveChat;

            sxaLiveChat.TemplateID = StudyGroupTemplateIds.LiveChat;

            return sxaLiveChat;
        }
    }
}
