using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    /// <summary>
    /// A generic mapper for Sitecore8 items that contain no custom fields such as containers etc.
    /// </summary>
    public class GenericSimpleSitecoreItemMapper : SitecoreItemMapper
    {
        /// <summary>
        /// A generic mapper for Sitecore8 items that contain no custom fields such as containers etc.
        /// Example of usage:
        ///  SxaAccordion sxaAccordion = new GenericSimpleSitecoreItemMapper().Map< SxaAccordion, AccordionContainer>(sitecore8AccordionContainer, SxaTemplateIds.Accordion);
        /// </summary>
        /// <typeparam name="TSxaItem">The new sxa template class</typeparam>
        /// <typeparam name="TSitecore8Item">The class representing the Sitecore 8 template</typeparam>
        /// <param name="sitecore8Item"></param>
        /// <param name="sxaTemplateId">Pass a value from the StudyGroupSxaMigration.Sitecore9Constants.Constants.SxaTemplateIds or Constants.StudyGroupTemplateIds </param>
        /// <returns></returns>
        public TSxaItem Map<TSxaItem, TSitecore8Item>(TSitecore8Item sitecore8Item, string sxaTemplateId)
            where TSxaItem : ISitecoreItem, new()
            where TSitecore8Item : ISitecoreItem
        {
            TSxaItem sxaItem = base.MapCommonFields<TSxaItem, TSitecore8Item>(sitecore8Item);

            sxaItem.TemplateID = sxaTemplateId;

            return sxaItem;
        }
    }
}
