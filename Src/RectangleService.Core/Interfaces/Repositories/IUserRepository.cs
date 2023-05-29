using Microsoft.AspNetCore.Identity;
using RectangleService.Core.Models;

namespace RectangleService.Core.Interfaces.Repositories
{
    /// <summary>
    /// IUserRepository interface
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<IdentityResult> CreateUserAsync(User user, string password);
    }
}
