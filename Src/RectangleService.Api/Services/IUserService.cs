using Microsoft.AspNetCore.Identity;
using RectangleService.Infrastructure.Domain.Models;

namespace RectangleService.Api.Services
{
    /// <summary>
    /// IUserService Interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public Task<IdentityResult> CreateUserAsync(User user, string password);

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool AuthenticateUser(string username, string password);
    }
}
