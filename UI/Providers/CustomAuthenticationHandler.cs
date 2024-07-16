using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;

namespace UI.Providers
{
    public class CustomAuthenticationHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, IHttpContextAccessor httpContextAccessor)
    : AuthenticationHandler<CustomAuthOptions>(options, logger, encoder)
    {
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return await Task.Factory.StartNew(() => AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(new GenericIdentity("CustomIdentity")), "CustomAuthenticationScheme")));
        }
    }
}
