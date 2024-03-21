using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.Mappers;
using StudyGroupSxaMigration.Logging.Exceptions;
using StudyGroupSxaMigration.Sitecore8Models.WidgetsV2;
using StudyGroupSxaMigration.Sitecore9;
using StudyGroupSxaMigration.Sitecore9Models.StudyGroup;
using StudyGroupSxaMigration.SitecoreCommon.Models;
using System.Threading.Tasks;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaBlogHomeService : SxaServiceBase, ISxaService
    {
        public SxaBlogHomeService(ISitecore9Client sitecore9Client,
                                       ILogger<SxaBlogHomeService> logger,
                                       ApplicationSettings applicationSettings) :
               base(sitecore9Client, logger, applicationSettings)
        {
        }

        /// <summary>
        /// update the blog home item fields and migrate and page data items (e.g. hero items)
        /// </summary>
        /// <param name="blogHomeItem"></param>
        /// <param name="insertionPath"></param>
        /// <returns></returns>
        public async Task<bool> UpdateFields(BlogHome blogHomeItem, string insertionPath)
        {
            migrationLogger.LogDebug($"Updating Blog Home item:'{blogHomeItem?.ItemName}' to path: '{insertionPath}'");

            SgSxaBlogHome sgSxaBlogHome = new BlogHomeMapper().Map(blogHomeItem);

            sgSxaBlogHome = await ConvertAndValidateBlogItem(sgSxaBlogHome, insertionPath);

             return await _sitecore9Client.UpdateItem<SgSxaBlogHome>(sgSxaBlogHome, insertionPath);
        }

        public async Task<bool> UpdateFields(NewsListingPage newsListingPage, string insertionPath)
        {
            migrationLogger.LogDebug($"Updating News (Blog) Home item using :'{newsListingPage?.ItemName}' to path: '{insertionPath}'");

            SgSxaBlogHome sgSxaBlogHome = new NewsListingPageToBlogHomeMapper().Map(newsListingPage);

            sgSxaBlogHome = await ConvertAndValidateBlogItem(sgSxaBlogHome, insertionPath);

            return await _sitecore9Client.UpdateItem<SgSxaBlogHome>(sgSxaBlogHome, insertionPath);
        }

        private async Task<SgSxaBlogHome> ConvertAndValidateBlogItem(SgSxaBlogHome sgSxaBlogHome, string insertionPath)
        {
            SitecoreItem blogItemInSitecore9 = await _sitecore9Client.GetItemByPath<SitecoreItem>(insertionPath);

            if (blogItemInSitecore9 == null)
            {
                throw new UpdateTargetNotFoundException("Unable to retrieve blog home item from sitecore 9 to update", insertionPath);
            }

            sgSxaBlogHome.ItemID = blogItemInSitecore9.ItemID;

            //TODO - image validatation also needs to be carried out here

            return sgSxaBlogHome;
        }
    }
}
