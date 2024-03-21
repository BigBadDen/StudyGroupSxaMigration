using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    /// <summary>
    /// Base class for all Sitecore Item mappers.
    /// </summary>
    public class SitecoreItemMapper
    {
        /// <summary>
        ///  Maps ItemLanguage, ItemName and DisplayName for all Sitecore 8 to Sitecore 9 mappings
        /// </summary>
        public TSxaItem MapCommonFields<TSxaItem, TSitecore8Item>(TSitecore8Item sitecore8Item)
            where TSxaItem : ISitecoreItem, new()
            where TSitecore8Item : ISitecoreItem
        {
            TSxaItem sxaItem = new TSxaItem()
            {
                ItemLanguage = sitecore8Item.ItemLanguage,
                ItemName = sitecore8Item.ItemName,
                DisplayName = sitecore8Item.DisplayName
            };

            return sxaItem;
        }
    }
}
