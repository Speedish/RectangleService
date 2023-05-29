using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RectangleService.Core.Common;
using RectangleService.Core.Models;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace RectangleService.Api.Auth
{
    /// <summary>
    /// BasicAuthenticationHandler
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Authentication.AuthenticationHandler&lt;Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions&gt;" />
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        /// <summary>
        /// The HTTP context accessor
        /// </summary>
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthenticationHandler"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="encoder">The encoder.</param>
        /// <param name="clock">The clock.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
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

        /// <summary>
        /// Allows derived types to handle authentication.
        /// </summary>
        /// <returns>
        /// The <see cref="T:Microsoft.AspNetCore.Authentication.AuthenticateResult" />.
        /// </returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // skip authentication if endpoint has [AllowAnonymous] attribute
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
                return AuthenticateResult.NoResult();

            if (!Request.Headers.ContainsKey("Authorization"))
            {
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
                    return AuthenticateResult.Fail("ApiAuthenticateUserNotFoundMessage");
                }

                SignInResult result = await signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

                if (!result.Succeeded)
                {                    
                    return AuthenticateResult.Fail(Messages.ApiAuthenticateInvalidCredentialsMessage);
                }
                else
                {    

                    List<Claim> claims = new List<Claim>()
                        {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                    };

                    var identity = new ClaimsIdentity(claims.ToArray(), Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);


                    return AuthenticateResult.Success(ticket);
                }
            }
            catch
            {
                return AuthenticateResult.Fail(Messages.ApiAuthenticateInvalidAuthHeaderMessage);
            }
        }
    }
}
