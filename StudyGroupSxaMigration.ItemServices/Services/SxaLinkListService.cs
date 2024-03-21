using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Constants.Constants;
using StudyGroupSxaMigration.Sitecore9Models.Sitecore;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaLinkListService : SxaServiceBase, ISxaService
    {
        public SxaLinkListService(ISitecore9Client sitecore9Client,
                                        ILogger<SxaLinkListService> logger,
                                        ApplicationSettings applicationSettings) :
                base(sitecore9Client, logger, applicationSettings)
        {
        }

        public async Task<bool> Create(MenuLinks sitecore8MenuLinkItem, string insertionPath)
        {
            migrationLogger.LogDebug($"Inserting new Link List Item:'{sitecore8MenuLinkItem?.ItemName}' to path: '{insertionPath}'");

            SxaLinkList sxaLinkList = new GenericSimpleSitecoreItemMapper().Map<SxaLinkList, MenuLinks>(sitecore8MenuLinkItem, SxaTemplateIds.LinkList);

            return (sxaLinkList == null ? false : await _sitecore9Client.CreateItem<SxaLinkList>(sxaLinkList, insertionPath));
        }
    }
}
