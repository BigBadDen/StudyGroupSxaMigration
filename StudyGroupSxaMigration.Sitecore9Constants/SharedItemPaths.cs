using System;
using System.Collections.Generic;
using System.Text;
using static StudyGroupSxaMigration.Sitecore9Constants.Constants.Sitecore9Folders;

namespace StudyGroupSxaMigration.Sitecore9Constants
{
    /// <summary>
    /// Set shared item paths for sitecore9 websites. Requires the site root as a constructor parameter, to allow full path to be created
    /// </summary>
    public class SharedItemPaths
    {
        private readonly string webSiteRootPath;

        public SharedItemPaths(string rootpath)
        {
            webSiteRootPath = rootpath;
        }

        public string Accordions
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Accordions}";
            }
        }

        public string ButtonGroups
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.ButtonGroups}";
            }
        }

        public string Carousels
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Carousels}";
            }
        }

        public string Galleries
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Galleries}";
            }
        }

        public string Heroes
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Heroes}";
            }
        }

        public string LinkLists
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.LinkLists}";
            }
        }

        public string Links
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Links}";
            }
        }

        public string LiveChat
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.LiveChat}";
            }
        }

        public string MaintainedByLogo
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.MaintainedByLogo}";
            }
        }

        public string Maps
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Maps}";
            }
        }

        public string PlainHtml
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.PlainHtml}";
            }
        }

        public string Promos
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Promos}";
            }
        }

        public string ProgressionRoutes
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.ProgressionRoutes}";
            }
        }

        public string SiteLogo
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.SiteLogo}";
            }
        }

        public string Tabs
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Tabs}";
            }
        }

        public string Tags
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Tags}";
            }
        }

        public string Testimonials
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Testimonials}";
            }
        }

        public string Texts
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Texts}";
            }
        }

        public string SocialMedia {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.SocialMedia}";
            }
        }

        public string VideoBackgrounds
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.VideoBackgrounds}";
            }
        }

        public string Videos
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Videos}";
            }
        }

        public string Widgets
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.Widgets}";
            }
        }

        public string ComboMenuItems
        {
            get
            {
                return $"{webSiteRootPath}/{SharedItemFolders.ComboMenuItems}";
            }
        }
    }
}
