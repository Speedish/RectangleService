using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RectangleService.Core.Requests;
using System.Net;
using RectangleService.Core.Interfaces.Services;
using RectangleService.Core.Models;
using RectangleService.Core.Common;
using RectangleService.Core.Services;

namespace RectangleService.Api.V1.Controllers
{
    /// <summary>
    /// UserController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiController]
    [Route("api/[controller]/[action]/")]
    [Consumes("application/json", new string[] { "application/xml" })]
    [Produces("application/json")]

    public class UserController : Controller
    {
        /// <summary>
        /// The user service
        /// </summary>
        private readonly IUserService _userService;
        /// <summary>
        /// The HTTP context accessor
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public UserController(
            IUserService userService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="userRequest">The user request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserRequest userRequest)
        {
            try
            {
                // validation
                if (ModelState.IsValid)
                {
                    var user = new User
                    {
                        UserName = userRequest.Username,
                        FirstName = userRequest.FirstName,
                        LastName = userRequest.LastName,
                        CreatedOn = DateTime.Now
                    };

                    IdentityResult result = await _userService.CreateUserAsync(user, userRequest.Password);
                    if (result.Succeeded)
                    {
                        return new OkObjectResult(new { UserId = user.Id });
                    }

                    if (result.Errors != null && result.Errors.Count() > 0)
                    {
                        foreach (var error in result.Errors)
                        {
                            string field = string.Empty;
                            if (error.Code.Contains("password", StringComparison.OrdinalIgnoreCase))
                            {
                                field = "Password";
                            }
                            else if (error.Code.Contains("Username", StringComparison.OrdinalIgnoreCase))
                            {
                                field = "Username";
                            }

                            ModelState.AddModelError(field, error.Description);
                        }
                    }
                    else
                    {
                        return new InternalServerErrorObjectResult(Messages.UserCreationFailedMessage);
                    }
                }

                ValidationErrorResponse errorResponse = new ValidationErrorResponse(HttpStatusCode.BadRequest, Messages.ValidationErrorOccurred, ModelState);

                return new BadRequestObjectResult(errorResponse);

            }
            catch (Exception ex)
            {
                return new InternalServerErrorObjectResult();
            }
        }
    }
}
