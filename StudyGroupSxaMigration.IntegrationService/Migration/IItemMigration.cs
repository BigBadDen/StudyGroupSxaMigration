using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.IntegrationService.Migration
{
    public interface IItemMigration
    {
        Task<ItemUpdateCounter> MigrateSharedItems();
        Task<ItemUpdateCounter> MigratePageDataItems(SitecoreItem pageItem);
        bool HasHierarchicalItemStructure { get; set; }
    }
}
