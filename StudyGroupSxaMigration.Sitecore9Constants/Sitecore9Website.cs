using Microsoft.Extensions.Configuration;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Sitecore9Constants
{
    /// <summary>
    /// Used to provide all paths specific to a sitecore 9 website
    /// Uses Constructor uses configuration["sitecore9WebsiteRoot"] setting to build up paths
    /// </summary>
    public class Sitecore9Website : ISitecore9Website
    {
        public Sitecore9Website(ApplicationSettings applicationSettings)
        {
            RootPath = applicationSettings.WebsiteSettings.Sitecore9WebsiteRoot;
            SharedItemPaths = new SharedItemPaths(RootPath);
            HomePagePath = RootPath + "/Home";
            BlogHomePath = HomePagePath + "/Blog";
        }

        public string RootPath { get; set; }

        public string HomePagePath { get;set; }

        public SharedItemPaths SharedItemPaths { get; set; }

        public string DataFolderName { get; set; } = "Data";

        public string BlogHomePath { get; set; }
    }
}
