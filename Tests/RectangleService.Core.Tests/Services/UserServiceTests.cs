using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using RectangleService.Core.Interfaces.Repositories;
using RectangleService.Core.Interfaces.Services;
using RectangleService.Core.Models;
using RectangleService.Core.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RectangleService.Core.Tests.Services
{
    /// <summary>
    /// UserServiceTests
    /// </summary>
    public class UserServiceTests
    {
        /// <summary>
        /// Creates the user asynchronous with valid user and password should call repository and return result.
        /// </summary>
        [Fact]
        public async Task CreateUserAsync_WithValidUserAndPassword_ShouldCallRepositoryAndReturnResult()
        {
            // Arrange
            var user = new User();
            var password = "testPassword";
            var expectedIdentityResult = IdentityResult.Success;

            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(repo => repo.CreateUserAsync(user, password)).ReturnsAsync(expectedIdentityResult);

            var mockLogger = new Mock<ILogger<UserService>>();

            var service = new UserService(mockRepository.Object, mockLogger.Object);

            // Act
            var result = await service.CreateUserAsync(user, password);

            // Assert
            Assert.Equal(expectedIdentityResult, result);
            mockRepository.Verify(repo => repo.CreateUserAsync(user, password), Times.Once);
        }

        /// <summary>
        /// Creates the user asynchronous with repository exception should log error and throw.
        /// </summary>
        [Fact]
        public async Task CreateUserAsync_WithRepositoryException_ShouldLogErrorAndThrow()
        {
            // Arrange
            var user = new User();
            var password = "testPassword";
            var expectedErrorMessage = "Error while trying to call the CreateUserAsync, Error Message = Test Error";

            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(repo => repo.CreateUserAsync(user, password)).ThrowsAsync(new Exception("Test Error"));

            var mockLogger = new Mock<ILogger<UserService>>();
            mockLogger.Setup(logger => logger.LogError(It.IsAny<string>())).Verifiable();

            var service = new UserService(mockRepository.Object, mockLogger.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => service.CreateUserAsync(user, password));
            Assert.Equal(expectedErrorMessage, exception.Message);
            mockLogger.Verify(logger => logger.LogError(It.IsAny<string>()), Times.Once);
        }
    }
}
