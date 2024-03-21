using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Sitecore9Constants.Constants
{
    /// <summary>
    /// stores sitecore 9 folder names
    /// </summary>
    public struct Sitecore9Folders
    {
        public static readonly string IcsTenantPath = "sitecore/content/Study Group/ISCs";

        public struct SharedItemFolders
        {
            public static readonly string SharedItemsFolderName = "Data";

            public static readonly string Accordions = $"{SharedItemsFolderName}/Accordions";
            public static readonly string ButtonGroups = $"{SharedItemsFolderName}/Button Groups";
            public static readonly string Carousels = $"{SharedItemsFolderName}/Carousels";
            public static readonly string Galleries = $"{SharedItemsFolderName}/Galleries";
            public static readonly string Heroes = $"{SharedItemsFolderName}/Heroes";
            public static readonly string ProgressionRoutes = $"{SharedItemsFolderName}/Progression Routes";
            public static readonly string LinkLists = $"{SharedItemsFolderName}/Link Lists";
            public static readonly string Links = $"{SharedItemsFolderName}/Links";
            public static readonly string LiveChat = $"{SharedItemsFolderName}/Live Chats";
            public static readonly string MaintainedByLogo = $"{SharedItemsFolderName}/Maintained By Logo";
            public static readonly string Maps = $"{SharedItemsFolderName}/Maps";
            public static readonly string PlainHtml = $"{SharedItemsFolderName}/Plain HTML";
            public static readonly string Promos = $"{SharedItemsFolderName}/Promos";
            public static readonly string SiteLogo = $"{SharedItemsFolderName}/Site Logo";
            public static readonly string Tabs = $"{SharedItemsFolderName}/Tabs";
            public static readonly string Tags = $"{SharedItemsFolderName}/Tags";
            public static readonly string Testimonials = $"{SharedItemsFolderName}/Testimonials";
            public static readonly string Texts = $"{SharedItemsFolderName}/Texts";
            public static readonly string SocialMedia = "Settings/Social Media Groups";
            public static readonly string VideoBackgrounds = $"{SharedItemsFolderName}/Video Backgrounds";
            public static readonly string Videos = $"{SharedItemsFolderName}/Videos";
            public static readonly string Widgets = $"{SharedItemsFolderName}/Widgets";
            public static readonly string ComboMenuItems = $"{SharedItemsFolderName}/Combo Menu Folder";
        }

        public struct PageDataSubFolders
        {
            public static readonly string Texts = "Texts";
            public static readonly string Widgets = "Widgets";
        }
    }
}
