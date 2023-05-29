using RectangleService.Core.Models;
using System.Collections.Generic;
using Xunit;

namespace RectangleService.Core.Tests.Models
{
    /// <summary>
    /// CoordinateInputTests
    /// </summary>
    public class CoordinateInputTests
    {
        /// <summary>
        /// Coordinates the input with null coordinates should initialize coordinates list.
        /// </summary>
        [Fact]
        public void CoordinateInput_WithNullCoordinates_ShouldInitializeCoordinatesList()
        {
            // Arrange
            var coordinateInput = new CoordinateInput();

            // Act

            // Assert
            Assert.NotNull(coordinateInput.Coordinates);
            Assert.Empty(coordinateInput.Coordinates);
        }

        /// <summary>
        /// Coordinates the input with coordinates should set coordinates list.
        /// </summary>
        [Fact]
        public void CoordinateInput_WithCoordinates_ShouldSetCoordinatesList()
        {
            // Arrange
            var coordinates = new List<Coordinate>
            {
                new Coordinate { X = 10, Y = 20 },
                new Coordinate { X = 30, Y = 40 }
            };

            // Act
            var coordinateInput = new CoordinateInput { Coordinates = coordinates };

            // Assert
            Assert.NotNull(coordinateInput.Coordinates);
            Assert.Equal(coordinates.Count, coordinateInput.Coordinates.Count);
            Assert.Equal(coordinates, coordinateInput.Coordinates);
        }
    }
}
