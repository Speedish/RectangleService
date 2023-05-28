using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualBasic;
using RectangleService.Infrastructure.Common;
using RectangleService.Infrastructure.Data;
using RectangleService.Infrastructure.Domain.Models;
using System.Text.Encodings.Web;
using System.Text;

namespace RectangleService.Api.Services
{
    /// <summary>
    /// UserService
    /// </summary>
    /// <seealso cref="RectangleService.Api.Services.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly RectangleContext _context;

        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="configuration">The configuration.</param>
        public UserService(RectangleContext context,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {


                //Add any user to Everyone Group
                //await _userManager.AddToRoleAsync(idpUser, Constants.EveryoneGroupName);

                //_idpLogger.LogInformation(String.Format(Messages.UserCreatedLogMessage) + " | {Category} {Feature}", LogCategory.User, LogFeature.Create);
                //_idpAuditor.Audit(AuditCategory.User, AuditFeature.Create, idpUser, user.CreatedBy);

                
            }

            return result;
        }

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool AuthenticateUser(string username, string password)
        {
            User user = _context.Users.Where(u => u.UserName == username).FirstOrDefault();

            var isSucceeded = false;

            // Check if user is exist
            if (user == null)
            {
                isSucceeded = false;
                //_idpLogger.LogError(String.Format(Messages.UserNotFoundOrNoPrvilageToLoginErrorMessage, username) + " | {Category} {Feature}", LogCategory.User, LogFeature.Login);
                return isSucceeded;
            }

            var resultAuth = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (resultAuth == PasswordVerificationResult.Success)
            {
                isSucceeded = true;
            }
            else
            {
                //_idpLogger.LogError(String.Format(Messages.InvalidCredentials) + " | {Category} {Feature}", LogCategory.User, LogFeature.Login);
            }
            return isSucceeded;
        }        
    }
}
