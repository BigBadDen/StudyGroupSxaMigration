using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyGroupSxaMigration.SitecoreCommon
{
    /// <summary>
    /// Extension methods on SitecoreItem class
    /// </summary>
    public static class SitecoreItemExtensions
    {
        /// <summary>
        /// Comparison of Sitecore item's templateId. Allows for variations of case and also extraneous curly brackets (which are never returned from the API)
        /// </summary>
        /// <param name="sitecoreItem"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public static bool TemplateIdEquals(this SitecoreItem sitecoreItem, string templateId)
        {
            if (string.IsNullOrEmpty(sitecoreItem.TemplateID) || string.IsNullOrEmpty(templateId))
                return false;

            return string.Equals(sitecoreItem.TemplateID, RemoveCurlyBraces(templateId), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Comparison of a sitecore item's template id against a list of TemplateIds. Allows for variations of case and also extraneous curly brackets (which are never returned from the API)
        /// </summary>
        /// <param name="sitecoreItem"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public static bool TemplateIdMatches(this SitecoreItem sitecoreItem, List<string> templateIds)
        {
            if (string.IsNullOrEmpty(sitecoreItem.TemplateID) || templateIds == null || templateIds.Count == 0)
                return false;

            return templateIds.Any(t => string.Equals(sitecoreItem.TemplateID, RemoveCurlyBraces(t), StringComparison.OrdinalIgnoreCase));
        }

        private static string RemoveCurlyBraces(string templateId)
        {
            if (!string.IsNullOrEmpty(templateId))
            {
                templateId = templateId.Replace("{", "");
                return templateId.Replace("}", "");
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
