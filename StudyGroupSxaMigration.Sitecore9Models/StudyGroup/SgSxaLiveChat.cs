using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore9Models.StudyGroup
{
    public class SgSxaLiveChat : SitecoreItem
    {
        [JsonProperty("Live Chat Id")]
        public string LiveChatId { get; set; }

        [JsonProperty("Online Message")]
        public string OnlineMessage { get; set; }

        [JsonProperty("Offline Message")]
        public string OfflineMessage { get; set; }

        public string Script { get; set; }

        [JsonProperty("Hide Live Chat")]
        public string HideLiveChat { get; set; } //stores a "1" or "0" string, which JSON.Net can't auto convert to bool for some reason without a custom converter, so here we use string
    }
}
