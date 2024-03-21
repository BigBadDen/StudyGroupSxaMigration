using StudyGroupSxaMigration.AppSettings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudyGroupSxaMigration.Sitecore8Constants
{
    public static class Sitecore8WebsiteFactory
    {
        /// <summary>
        /// Retrieves sitecore 8 website object, using the the 'Sitecore8WebsiteClassName' value from appsettings.[environment].json)
        /// </summary>
        /// <param name="applicationSettings"></param>
        /// <returns></returns>
        public static Type GetTypeOfSitecore8Website(ApplicationSettings applicationSettings)
        {
            if (string.IsNullOrWhiteSpace(applicationSettings.WebsiteSettings.Sitecore8WebsiteClassName))
            {
                throw new ArgumentNullException("Unable to retrieve sitecore8 website. Check appsettings value for'Sitecore8WebsiteClassName' is correct. It should be the named to match a class in StudyGroupSxaMigration.Sitecore8Constants.Websites");
            }

            string sitecore8WebsiteName = applicationSettings.WebsiteSettings.Sitecore8WebsiteClassName;
            string sitecore8WebsiteFullClassName = "StudyGroupSxaMigration.SitecoreConstants.Websites." + sitecore8WebsiteName;

            var sitecore8Website = Array.Find(Assembly.GetExecutingAssembly().GetTypes(),
                                            i => i.Namespace == "StudyGroupSxaMigration.SitecoreConstants.Websites" && i.Name == sitecore8WebsiteName);

            if (sitecore8Website == null)
            {
                throw new ApplicationException($"Unable to retrieve '{sitecore8WebsiteFullClassName}'. Check appsettings value for Sitecore8WebsiteClassName '{sitecore8WebsiteFullClassName}' is correct. It should be the named to match a class in StudyGroupSxaMigration.Sitecore8Constants.Websites");
            }

            return sitecore8Website;
        }
    }
}
