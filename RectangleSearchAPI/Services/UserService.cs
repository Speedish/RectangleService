using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualBasic;
using RectangleSearchAPI.DataAccess.Common;
using RectangleSearchAPI.DataAccess.Data;
using RectangleSearchAPI.DataAccess.Domain.Models;
using System.Text.Encodings.Web;
using System.Text;

namespace RectangleSearchAPI.Web.Services
{
    public class UserService : IUserService
    {
        private readonly RectangleContext _context;

        private readonly UserManager<User> _userManager;

        private readonly IConfiguration _configuration;

        public UserService(RectangleContext context,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

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

        public bool AuthenticateUser(string username, string password)
        {
            User user = _context.Users.Where(u => u.UserName == username).FirstOrDefault();

            var isSucceeded = false;

            // Check if user is valid for the given application and user is in a valid user type (not an apiuser)
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
