using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using StudyGroupSxaMigration.AppSettings;

namespace StudyGroupSxaMigration.IntegrationService.Security
{
    /// <summary>
    /// Authentication client to allow Sitecore 9 connections to be run under a Sitecore user account
    /// NB. Currently not set up for Sitecore 8 
    /// </summary>
    public class SitecoreAuthenticationClient : ISiteCoreAuthenticationClient
    {
        public const string AuthLoginEndpoint = "auth/login";
        public const string AspNetCookieKey = ".AspNet.Cookies";

        private readonly HttpClient _httpClient;
        private readonly ApplicationSettings _settings;

        public SitecoreAuthenticationClient(HttpClient httpClient, ApplicationSettings settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<SetCookieHeaderValue> GetAuthenticationCookie(string requestedUrl)
        {
            string fullAuthLoginUrl = string.Empty;

            //if (requestedUrl.StartsWith(_settings.WebsiteSettings.Sitecore8Uri))
            //{
            //    fullAuthLoginUrl = $"{_settings.WebsiteSettings.Sitecore8Uri}{AuthLoginEndpoint}";
            //}
            //else
            //{
            fullAuthLoginUrl = $"{_settings.WebsiteSettings.Sitecore9Uri}{AuthLoginEndpoint}";
            //}

            var loginRequest = new StringContent
                (
                JsonConvert.SerializeObject(_settings.SitecoreLogin),
                Encoding.UTF8,
                MediaTypeNames.Application.Json
                );

            var response = await _httpClient.PostAsync
            (
                fullAuthLoginUrl,
                loginRequest
            );

            if (response.IsSuccessStatusCode)
            {
                var cookies =
                    response
                        .Headers
                        .Single(h => h.Key == HeaderNames.SetCookie)
                        .Value
                        .ToList();

                return SetCookieHeaderValue
                    .ParseList(cookies)
                    .Single(c => c.Name == AspNetCookieKey);
            }
            else
            {
                return null;
            }
        }
    }
}
