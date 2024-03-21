using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace StudyGroupSxaMigration.IntegrationService.Security
{
    public class SitecoreCookieHandler : DelegatingHandler
    {
        private readonly ISiteCoreAuthenticationClient _authenticationClient;

        public SitecoreCookieHandler(ISiteCoreAuthenticationClient authenticationClient)
        {
            _authenticationClient = authenticationClient;
        }

        public SetCookieHeaderValue AuthenticationCookie { get; protected set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (AuthenticationCookie == null
                || AuthenticationCookie.Expires - DateTime.UtcNow
                    <= TimeSpan.FromMinutes(5))
            {
                AuthenticationCookie = await _authenticationClient.GetAuthenticationCookie(request.RequestUri.AbsoluteUri);
            }

            request
                .Headers
                .Add(HeaderNames.Cookie, AuthenticationCookie.ToString());

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
