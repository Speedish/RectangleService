using RectangleService.Core.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace RectangleService.Core.Tests.Models
{
    /// <summary>
    /// CoordinateTests
    /// </summary>
    public class CoordinateTests
    {
        /// <summary>
        /// Coordinates the with valid values should be valid.
        /// </summary>
        [Fact]
        public void Coordinate_WithValidValues_ShouldBeValid()
        {
            // Arrange
            var coordinate = new Coordinate { X = 10, Y = 20 };

            // Act
            var validationContext = new ValidationContext(coordinate);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(coordinate, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        /// <summary>
        /// Coordinates the with negative values should be invalid.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        [Theory]
        [InlineData(-5, 10)]
        [InlineData(10, -5)]
        [InlineData(-5, -10)]
        public void Coordinate_WithNegativeValues_ShouldBeInvalid(int x, int y)
        {
            // Arrange
            var coordinate = new Coordinate { X = x, Y = y };

            // Act
            var validationContext = new ValidationContext(coordinate);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(coordinate, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }
    }
}
