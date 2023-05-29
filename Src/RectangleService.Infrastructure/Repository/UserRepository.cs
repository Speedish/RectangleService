using Microsoft.AspNetCore.Identity;
using RectangleService.Infrastructure.Context;
using RectangleService.Core.Models;
using RectangleService.Core.Interfaces.Repositories;

namespace RectangleService.Infrastructure.Repositories
{
    /// <summary>
    /// UserRepository
    /// </summary>
    /// <seealso cref="RectangleService.Core.Interfaces.Repositories.IUserRepository" />
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly RectangleDBContext _context;
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        public UserRepository(RectangleDBContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                // Add any user to Everyone Group
                // await _userManager.AddToRoleAsync(idpUser, Constants.EveryoneGroupName);

                // _idpLogger.LogInformation(String.Format(Messages.UserCreatedLogMessage) + " | {Category} {Feature}", LogCategory.User, LogFeature.Create);
                // _idpAuditor.Audit(AuditCategory.User, AuditFeature.Create, idpUser, user.CreatedBy);
            }

            return result;
        }
    }
}
