using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.Sitecore9
{
    public interface ISitecore9Client
    {
        Task<bool> UpdateItem<T>(T genericSitecoreItem, string insertPath) where T : ISitecoreItem;
        Task<bool> CreateItem<T>(T genericSitecoreItem, string insertPath) where T : ISitecoreItem;
        Task<bool> CreateItem<T>(T genericSitecoreItem, string insertPath, bool logWarningIfAlreadyExists) where T : ISitecoreItem;
        Task<T> GetItemByPath<T>(string itemPath) where T : ISitecoreItem, new();
        Task<T> GetItemById<T>(string itemId) where T : ISitecoreItem, new();
    }
}
