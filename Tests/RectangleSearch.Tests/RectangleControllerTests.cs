using Microsoft.AspNetCore.Mvc;
using Moq;
using RectangleSearch.DataAccess.Domain.Models;
using RectangleSearch.Web.Controllers;
using RectangleSearch.Web.Services;
using Xunit;

namespace RectangleSearch.Tests
{
    public class RectangleControllerTests
    {
        [Fact]
        public void SearchRectangles_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var input = new CoordinateInput { /* Set up your test input values here */ };
            var expectedRectangles = new List<Rectangle> { /* Set up your expected output rectangles here */ };

            var rectangleServiceMock = new Mock<IRectangleService>();
            rectangleServiceMock.Setup(s => s.SearchRectangles(input)).Returns(expectedRectangles);

            var controller = new RectangleController(rectangleServiceMock.Object);

            // Act
            var result = controller.SearchRectangles(input);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualRectangles = Assert.IsAssignableFrom<List<Rectangle>>(okResult.Value);
            Assert.Equal(expectedRectangles, actualRectangles);
        }
    }
}
