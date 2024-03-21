using Newtonsoft.Json;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.Sitecore8Models.Sitecore
{
    public class MediaItem : SitecoreItem
    {
        public string Keywords { get; set; }

        [JsonProperty("Asset 3")]
        public string Asset3 { get; set; }

        [JsonProperty("Date Time")]
        public string DateTime { get; set; }

        public string Dimensions { get; set; }

        [JsonProperty("Mime Type")]
        public string MimeType { get; set; }

        public string Alt { get; set; }
        public string Latitude { get; set; }

        [JsonProperty("Asset 2")]
        public string Asset2 { get; set; }

        public string ZipCode { get; set; }
        public string Make { get; set; }

        [JsonProperty("File Path")]
        public string FilePath { get; set; }

        public string Blob { get; set; }
        public string Width { get; set; }
        public string Software { get; set; }
        public string Extension { get; set; }

        [JsonProperty("Marketing asset")]
        public string Marketingasset { get; set; }

        public string Title { get; set; }
        public string LocationDescription { get; set; }
        public string Longitude { get; set; }
        public string Height { get; set; }
        public string Format { get; set; }
        public string Model { get; set; }
        public string Copyright { get; set; }
        public string Size { get; set; }

        [JsonProperty("Image Description")]
        public string ImageDescription { get; set; }

        [JsonProperty("Asset 1")]
        public string Asset1 { get; set; }

        public string Artist { get; set; }
        public string Description { get; set; }
        public string CountryCode { get; set; }
    }
}
