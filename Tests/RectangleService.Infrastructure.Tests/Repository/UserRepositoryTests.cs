using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RectangleService.Core.Models;
using RectangleService.Infrastructure.Context;
using RectangleService.Infrastructure.Repositories;
using Xunit;

namespace RectangleService.Infrastructure.Tests.Repositories
{
    /// <summary>
    /// UserRepositoryTests
    /// </summary>
    public class UserRepositoryTests
    {
        /// <summary>
        /// The options
        /// </summary>
        private readonly DbContextOptions<RectangleDBContext> _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepositoryTests"/> class.
        /// </summary>
        public UserRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<RectangleDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
        }

        /// <summary>
        /// Creates the user asynchronous valid user returns success result.
        /// </summary>
        [Fact]
        public async Task CreateUserAsync_ValidUser_ReturnsSuccessResult()
        {
            // Arrange
            var user = new User
            {
                UserName = "testuser",
                Email = "testuser@example.com"
                // Set other properties as needed
            };

            var password = "password123";

            using (var context = new RectangleDBContext(_options))
            {
                var userManager = CreateUserManager(context);
                var repository = new UserRepository(context, userManager);

                // Act
                var result = await repository.CreateUserAsync(user, password);

                // Assert
                Assert.True(result.Succeeded);

                // Additional assertions as needed
            }
        }

        // Helper method to create an instance of UserManager
        /// <summary>
        /// Creates the user manager.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private UserManager<User> CreateUserManager(RectangleDBContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore, null, null, null, null, null, null, null, null);

            return userManager;
        }

        // Add more tests for other repository methods
        // ...

        // Additional test methods
        // ...
    }
}
