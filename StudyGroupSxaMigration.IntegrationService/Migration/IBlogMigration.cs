using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.IntegrationService.Migration
{
    public interface IBlogMigration
    {
        Task<bool> UpdateItemFields(string blogPageItemId, List<SitecoreItem> blogItems = null);
    }
}

