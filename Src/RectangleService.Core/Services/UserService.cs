using Microsoft.AspNetCore.Identity;
using RectangleService.Core.Interfaces.Repositories;
using RectangleService.Core.Interfaces.Services;
using RectangleService.Core.Models;

namespace RectangleService.Core.Services
{
    /// <summary>
    /// UserService
    /// </summary>
    /// <seealso cref="RectangleService.Core.Interfaces.Services.IUserService" />
    /// <seealso cref="RectangleService.Api.Services.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The user repository
        /// </summary>
        public readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <exception cref="System.ArgumentNullException">userRepository</exception>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository)); ;
        }
        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return await _userRepository.CreateUserAsync(user, password);
        }
    }
}
