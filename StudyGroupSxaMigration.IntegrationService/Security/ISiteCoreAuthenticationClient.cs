using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace StudyGroupSxaMigration.IntegrationService.Security
{
    public interface ISiteCoreAuthenticationClient
    {
        Task<SetCookieHeaderValue> GetAuthenticationCookie(string requestedUrl);
    }
}
