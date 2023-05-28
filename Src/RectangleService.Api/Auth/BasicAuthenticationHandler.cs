using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RectangleService.Infrastructure.Common;
using RectangleService.Infrastructure.Data;
using RectangleService.Infrastructure.Domain.Models;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace RectangleService.Api.Auth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private IHttpContextAccessor _httpContextAccessor;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder,
            ISystemClock clock,
            IHttpContextAccessor httpContextAccessor
            )
            : base(options, loggerFactory, encoder, clock)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // skip authentication if endpoint has [AllowAnonymous] attribute
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
                return AuthenticateResult.NoResult();

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                //_logger.LogError(String.Format(Messages.ApiAuthenticateMissingAuthHeaderMessage) + " | {Category} {Feature}", LogCategory.Api, LogFeature.ApiUserAuthenticate);

                _httpContextAccessor.HttpContext.Response.Headers["WWW-Authenticate"] = "Basic";
                return AuthenticateResult.Fail(Messages.ApiAuthenticateMissingAuthHeaderMessage);
            }

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];

                var signInManager = _httpContextAccessor.HttpContext.RequestServices.GetService<SignInManager<User>>();
                var userManager = _httpContextAccessor.HttpContext.RequestServices.GetService<UserManager<User>>();

                var user = await userManager.FindByNameAsync(username);
                if (user == null)
                {
                    //_logger.LogError(String.Format(Messages.ApiAuthenticateUserNotFoundMessage) + " | {Category} {Feature}", LogCategory.Api, LogFeature.ApiUserAuthenticate);
                    return AuthenticateResult.Fail("ApiAuthenticateUserNotFoundMessage");
                }

                SignInResult result = await signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

                if (!result.Succeeded)
                {
                    //_logger.LogError(String.Format(Messages.ApiAuthenticateInvalidCredentialsMessage) + " | {Category} {Feature}", LogCategory.Api, LogFeature.ApiUserAuthenticate);
                    
                    return AuthenticateResult.Fail(Messages.ApiAuthenticateInvalidCredentialsMessage);
                }
                else
                {
                    //var userManager = _httpContextAccessor.HttpContext.RequestServices.GetService<UserManager<User>>();
                    var dbContext = _httpContextAccessor.HttpContext.RequestServices.GetService<RectangleContext>();

                    user = await userManager.FindByNameAsync(username);
                    var roles = await userManager.GetRolesAsync(user);

                    var tenantUser = dbContext.Users.Where(x => x.Id == user.Id).FirstOrDefault();

                    List<Claim> claims = new List<Claim>()
                        {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                    };

                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var identity = new ClaimsIdentity(claims.ToArray(), Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    //_logger.LogInformation(String.Format(Messages.ApiAuthenticatedSuccessMessage, user.Id) + " | {Category} {Feature}", LogCategory.Api, LogFeature.ApiUserAuthenticate);

                    return AuthenticateResult.Success(ticket);
                }
            }
            catch
            {
                //_logger.LogError(String.Format(Messages.ApiAuthenticateInvalidAuthHeaderMessage) + " | {Category} {Feature}", LogCategory.Api, LogFeature.ApiUserAuthenticate);
                return AuthenticateResult.Fail(Messages.ApiAuthenticateInvalidAuthHeaderMessage);
            }
        }
    }
}
