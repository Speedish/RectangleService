using Microsoft.Extensions.Logging;
using Moq;
using RectangleService.Core.Interfaces.Repositories;
using RectangleService.Core.Models;
using RectangleService.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RectangleService.Core.Tests.Services
{
    /// <summary>
    /// RectangleServiceTests
    /// </summary>
    public class RectangleServiceTests
    {
        /// <summary>
        /// Searches the rectangles with valid input should call repository and return result.
        /// </summary>
        [Fact]
        public async Task SearchRectangles_WithValidInput_ShouldCallRepositoryAndReturnResult()
        {
            // Arrange
            var input = new CoordinateInput();
            var expectedRectangles = new List<Rectangle> { new Rectangle(), new Rectangle() };

            var mockRepository = new Mock<IRectangleRepository>();
            mockRepository.Setup(repo => repo.SearchRectangles(input)).ReturnsAsync(expectedRectangles);

            var mockLogger = new Mock<ILogger<RectangleService.Core.Services.RectangleService>>();

            var service = new RectangleService.Core.Services.RectangleService(mockRepository.Object, mockLogger.Object);

            // Act
            var result = await service.SearchRectangles(input);

            // Assert
            Assert.Equal(expectedRectangles, result);
            mockRepository.Verify(repo => repo.SearchRectangles(input), Times.Once);
        }

        /// <summary>
        /// Searches the rectangles with repository exception should log error and throw.
        /// </summary>
        [Fact]
        public async Task SearchRectangles_WithRepositoryException_ShouldLogErrorAndThrow()
        {
            // Arrange
            var input = new CoordinateInput();
            var expectedErrorMessage = "Error while trying to call the SearchRectangles, Error Message = Test Error";

            var mockRepository = new Mock<IRectangleRepository>();
            mockRepository.Setup(repo => repo.SearchRectangles(input)).ThrowsAsync(new Exception("Test Error"));

            var mockLogger = new Mock<ILogger<RectangleService.Core.Services.RectangleService>>();
            mockLogger.Setup(logger => logger.LogError(It.IsAny<string>())).Verifiable();

            var service = new RectangleService.Core.Services.RectangleService(mockRepository.Object, mockLogger.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => service.SearchRectangles(input));
            Assert.Equal(expectedErrorMessage, exception.Message);
            mockLogger.Verify(logger => logger.LogError(It.IsAny<string>()), Times.Once);
        }
    }
}
