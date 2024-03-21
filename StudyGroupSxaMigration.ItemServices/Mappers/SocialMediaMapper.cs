using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using System;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public class SocialMediaMapper : SitecoreItemMapper
    {
        public SxaSocialMediaTemplate Map(SocialMediaLinks socialMediaLinks)
        {
            SxaSocialMediaTemplate sxaSocialMediaTemplate = base.MapCommonFields<SxaSocialMediaTemplate, SocialMediaLinks>(socialMediaLinks);

            sxaSocialMediaTemplate.Enabled = true;
            sxaSocialMediaTemplate.OnlyOnceCode = ConvertLinkToCode(socialMediaLinks);

            sxaSocialMediaTemplate.TemplateID = SxaTemplateIds.SocialMediaTemplate;

            return sxaSocialMediaTemplate;
        }

        public string ConvertLinkToCode(SocialMediaLinks socialMediaItem)
        {
            if (socialMediaItem.Link.Contains("linktype=\"external\""))
            {
                var rel = !string.IsNullOrEmpty(socialMediaItem.RelAttribute) ? $" rel={socialMediaItem.RelAttribute}" : string.Empty;

                if (!string.IsNullOrEmpty(socialMediaItem.Link))
                {
                    //link format: "<link text=\"Facebook\" linktype=\"external\" url=\"https://www.facebook.com/WaikatoPathwaysCollege/\" anchor=\"\" target=\"_blank\" />"
                    var array = socialMediaItem.Link.Replace("<", "").Replace("/>", "").Replace("link", "").Replace("=", "").Replace(" ", "").Trim().Split("\"");

                    var index = Array.IndexOf(array, "url");
                    var url = (index >= 0 && index + 1 < array.Length) ? array[index + 1] : string.Empty;

                    index = Array.IndexOf(array, "target");
                    var target = (index >= 0 && index + 1 < array.Length) ? array[index + 1] : string.Empty;

                    return $@"<a href='{url}' target='{target}'{rel}>
                        <i aria-hidden='true' class='fa {socialMediaItem.CssClass}'></i>
                    </a>";
                }

                return $@"<a href='' target='_blank'{rel}>
                        <i aria-hidden='true' class='fa {socialMediaItem.CssClass}'></i>
                    </a>";
            }
            else //internal link will be handled by ConvertAndValidate function in the service layer. But all social media links should be external?
            {
                return socialMediaItem.Link;
            }
        }
    }
}
