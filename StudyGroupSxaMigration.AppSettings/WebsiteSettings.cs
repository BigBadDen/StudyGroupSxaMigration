using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.AppSettings
{
    public class WebsiteSettings
    {
        public string Sitecore9Uri { get; set; }
        public string Sitecore8Uri { get; set; }
        public string Sitecore8WebsiteClassName { get; set; }
        public string Sitecore9WebsiteRoot { get; set; }
        public bool AuthenticateSitecore9Connection { get; set; }
    }
}
