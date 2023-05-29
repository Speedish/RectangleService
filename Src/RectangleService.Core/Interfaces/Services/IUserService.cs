using Microsoft.AspNetCore.Identity;
using RectangleService.Core.Models;

namespace RectangleService.Core.Interfaces.Services
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
    }
}
