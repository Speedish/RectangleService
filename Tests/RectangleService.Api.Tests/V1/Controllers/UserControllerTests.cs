using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RectangleService.Api.V1.Controllers;
using RectangleService.Core.Common;
using RectangleService.Core.Interfaces.Services;
using RectangleService.Core.Models;
using RectangleService.Core.Requests;
using RectangleService.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RectangleService.Api.UnitTests.V1.Controllers
{
    /// <summary>
    /// UserControllerTests
    /// </summary>
    public class UserControllerTests
    {
        /// <summary>
        /// The fixture
        /// </summary>
        private readonly Fixture _fixture;
        /// <summary>
        /// The user service mock
        /// </summary>
        private readonly Mock<IUserService> _userServiceMock;
        /// <summary>
        /// The HTTP context accessor mock
        /// </summary>
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        /// <summary>
        /// The controller
        /// </summary>
        private readonly UserController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControllerTests"/> class.
        /// </summary>
        public UserControllerTests()
        {
            _fixture = new Fixture();
            _userServiceMock = new Mock<IUserService>();
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _controller = new UserController(_userServiceMock.Object, _httpContextAccessorMock.Object);
        }

        /// <summary>
        /// Creates the user valid request returns ok result with user identifier.
        /// </summary>
        [Fact]
        public async Task CreateUser_ValidRequest_ReturnsOkResultWithUserId()
        {
            // Arrange
            var userRequest = _fixture.Create<CreateUserRequest>();
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userRequest.Username,
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                CreatedOn = DateTime.Now
            };
            var identityResult = IdentityResult.Success;
            _userServiceMock.Setup(x => x.CreateUserAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(identityResult)
                .Verifiable();

            // Act
            var result = await _controller.CreateUser(userRequest);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = (OkObjectResult)result;
            okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
            var response = okResult.Value;
            response.Should().NotBeNull();
            response.Should().BeOfType<Dictionary<string, string>>();
            var responseObject = (Dictionary<string, string>)response;
            responseObject.Should().ContainKey("UserId");
            responseObject["UserId"].Should().Be(user.Id);

            _userServiceMock.Verify();
        }

        /// <summary>
        /// Creates the user invalid request returns bad request with validation errors.
        /// </summary>
        [Fact]
        public async Task CreateUser_InvalidRequest_ReturnsBadRequestWithValidationErrors()
        {
            // Arrange
            var userRequest = _fixture.Create<CreateUserRequest>();
            _controller.ModelState.AddModelError("Username", "The Username field is required.");
            _controller.ModelState.AddModelError("Password", "The Password field is required.");

            // Act
            var result = await _controller.CreateUser(userRequest);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            var badRequestResult = (BadRequestObjectResult)result;
            badRequestResult.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            var response = badRequestResult.Value;
            response.Should().NotBeNull();
            response.Should().BeOfType<ValidationErrorResponse>();
            var errorResponse = (ValidationErrorResponse)response;
            errorResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            errorResponse.ErrorMessage.Should().Contain(Messages.ValidationErrorOccurred);
            errorResponse.ErrorMessage.Should().NotBeNull();
            errorResponse.ErrorMessage.Should().HaveLength(2);
            errorResponse.ErrorMessage.Should().Contain("Username");
            errorResponse.ErrorMessage.Should().Contain("Password");

            _userServiceMock.Verify(x => x.CreateUserAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Never);
        }



        /// <summary>
        /// Creates the user failed user creation returns internal server error.
        /// </summary>
        [Fact]
        public async Task CreateUser_FailedUserCreation_ReturnsInternalServerError()
        {
            // Arrange
            var userRequest = _fixture.Create<CreateUserRequest>();
            var identityResult = IdentityResult.Failed(new IdentityError { Description = "Failed to create user." });
            _userServiceMock.Setup(x => x.CreateUserAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(identityResult)
                .Verifiable();

            // Act
            var result = await _controller.CreateUser(userRequest);

            // Assert
            result.Should().BeOfType<InternalServerErrorObjectResult>();
            var internalServerErrorResult = (InternalServerErrorObjectResult)result;
            internalServerErrorResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);

            _userServiceMock.Verify();
        }

        /// <summary>
        /// Creates the user exception thrown returns internal server error.
        /// </summary>
        [Fact]
        public async Task CreateUser_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var userRequest = _fixture.Create<CreateUserRequest>();
            _userServiceMock.Setup(x => x.CreateUserAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Throws<Exception>()
                .Verifiable();

            // Act
            var result = await _controller.CreateUser(userRequest);

            // Assert
            result.Should().BeOfType<InternalServerErrorObjectResult>();
            var internalServerErrorResult = (InternalServerErrorObjectResult)result;
            internalServerErrorResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);

            _userServiceMock.Verify();
        }
    }
}

