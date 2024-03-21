using StudyGroupSxaMigration.SitecoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.Sitecore8
{
    public interface ISitecore8Client
    {
        Task<T> GetItem<T>(string itemId) where T : new();

        Task<T> GetItem<T>(string itemId, string templateId) where T : SitecoreItem, new();

        Task<List<T>> GetItemChildren<T>(string itemId, string templateId) where T : SitecoreItem, new();
        Task<List<T>> GetItemChildren<T>(string itemId, List<string> templateIds) where T : SitecoreItem, new();
        Task<List<T>> GetItemChildren<T>(string itemId) where T : SitecoreItem, new();

        Task<T> GetItemByPath<T>(string itemPath, bool? logErrorIfNotFound) where T : new();
        Task<T> GetItemByPath<T>(string itemPath, string templateId, bool?  logErrorIfNotFound) where T : SitecoreItem, new();
        Task<List<T>> GetAllChildrenRecursivelyById<T>(string itemId, string templateId, string intermediateItemsInTreeTemplateId = "", bool isIncludeParentItems = false) where T : SitecoreItem, new();
    }
}
