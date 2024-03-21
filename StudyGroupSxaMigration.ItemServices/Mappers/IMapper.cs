using System;
using System.Collections.Generic;
using System.Text;
using StudyGroupSxaMigration.SitecoreCommon.Models;

namespace StudyGroupSxaMigration.ItemServices.Mappers
{
    public interface IMapper
    {
        TSxaItem Map<TSxaItem, TSitecore8Item>(TSitecore8Item sitecore8Item)
            where TSxaItem : ISitecoreItem, new()
            where TSitecore8Item : ISitecoreItem;
    }
}
