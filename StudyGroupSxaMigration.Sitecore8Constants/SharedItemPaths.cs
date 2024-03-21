namespace StudyGroupSxaMigration.SitecoreConstants
{
    /// <summary>
    /// Defines the paths to the shared items folders for a Sitecore 8 website
    /// </summary>
    public class SharedItemPaths
    {
        public SharedItemPaths(string path)
        {
            FolderPath = path;
        }

        public string FolderPath { get; set; }
        public string Accordions { get; set; }
        public string ButtonGroups { get; set; }
        public string Carousels { get; set; }
        public string ContentBoxes { get; set; }
        public string Galleries { get; set; }
        public string HeroContent { get; set; }
        public string HeaderAndFooterLinks { get; set; }
        public string Languages { get; set; }
        public string LiveChat { get; set; }
        public string Maps { get; set; }

        public string ProgressionRoutes { get; set; }
        public string RelatedLinks { get; set; }
        public string RelatedLinksWithSections { get; set; }
        public string SidebarBoxes { get; set; }
        public string ScriptSnippet { get; set; }
        public string Tabs { get; set; }
        public string Testimonials { get; set; }
        public string Videos { get; set; }
        public string Widgets { get; set; }
        public string SocialMedia { get; set; }
        public string SharedComboMenus { get; set; }
    }
}
