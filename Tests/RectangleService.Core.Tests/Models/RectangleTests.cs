using RectangleService.Core.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace RectangleService.Core.Tests.Models
{
    /// <summary>
    /// RectangleTests
    /// </summary>
    public class RectangleTests
    {
        /// <summary>
        /// Rectangles the with valid values should be valid.
        /// </summary>
        [Fact]
        public void Rectangle_WithValidValues_ShouldBeValid()
        {
            // Arrange
            var rectangle = new Rectangle { Id = 1, X = 10, Y = 20, Width = 30, Height = 40 };

            // Act
            var validationContext = new ValidationContext(rectangle);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(rectangle, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        /// <summary>
        /// Rectangles the with invalid values should be invalid.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        [Theory]
        [InlineData(-1, 10, 20, 30, 40)]
        [InlineData(1, -10, 20, 30, 40)]
        [InlineData(1, 10, -20, 30, 40)]
        [InlineData(1, 10, 20, -30, 40)]
        [InlineData(1, 10, 20, 30, -40)]
        public void Rectangle_WithInvalidValues_ShouldBeInvalid(int id, int x, int y, int width, int height)
        {
            // Arrange
            var rectangle = new Rectangle { Id = id, X = x, Y = y, Width = width, Height = height };

            // Act
            var validationContext = new ValidationContext(rectangle);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(rectangle, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }
    }
}
