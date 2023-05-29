using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RectangleService.Api.V1.Controllers;
using RectangleService.Core.Interfaces.Services;
using RectangleService.Core.Models;

namespace RectangleService.Api.Tests.V1.Controllers
{

    /// <summary>
    /// RectangleControllerTests
    /// </summary>
    public class RectangleControllerTests
    {
        /// <summary>
        /// The rectangle service
        /// </summary>
        private readonly IFixture _fixture;
        /// <summary>
        /// The service mock
        /// </summary>
        private readonly Mock<IRectangleService> _serviceMock;
        /// <summary>
        /// The sut
        /// </summary>
        private readonly RectangleController _sut;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleController" /> class.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">rectangleService</exception>
        public RectangleControllerTests()
        {
            _fixture = new Fixture();
            _serviceMock = _fixture.Freeze<Mock<IRectangleService>>();
            _sut = new RectangleController(_serviceMock.Object);
        }

        /// <summary>
        /// Searches the rectangles should return ok response when data found.
        /// </summary>
        [Fact]
        public async Task SearchRectangles_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var rectangleMock = _fixture.Create<List<Rectangle>>();
            var input = _fixture.Create<CoordinateInput>();
            _serviceMock.Setup(x => x.SearchRectangles(input)).ReturnsAsync(rectangleMock);

            //Act
            var result = await _sut.SearchRectangles(input).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<Rectangle>>();
            result.Result.Should().BeAssignableTo<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value
                .Should()
                .NotBeNull()
                .And.BeOfType(rectangleMock.GetType());
            _serviceMock.Verify(x => x.SearchRectangles(input), Times.Once());
        }

    }
}
