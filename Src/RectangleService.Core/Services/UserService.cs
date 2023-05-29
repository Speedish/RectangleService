using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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
        /// The logger
        /// </summary>
        public readonly ILogger<RectangleService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">userRepository</exception>
        public UserService(IUserRepository userRepository, ILogger<RectangleService> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }
        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            try
            {
                return await _userRepository.CreateUserAsync(user, password);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call the CreateUserAsync, Error Message = {ex.Message}");
                throw;
            }
        }
    }
}
