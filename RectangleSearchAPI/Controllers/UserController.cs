using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RectangleSearchAPI.DataAccess.Common;
using RectangleSearchAPI.DataAccess.Domain.Models;
using RectangleSearchAPI.Web.Requests;
using RectangleSearchAPI.Web.Services;
using System.Net;
using System.Security.Claims;

namespace RectangleSearchAPI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]/")]
    [Consumes("application/json", new string[] { "application/xml" })]
    [Produces("application/json")]
    
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(
            IUserService userService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        //[SwaggerResponse(200, Type = typeof(object))]
        public async Task<ActionResult> CreateUser(CreateUserRequest userRequest)
        {

            // log api request
            //_idpLogger.LogInformation(Messages.ApiRequestReceived + " | {Category} {Feature} {DetailMessage}", LogCategory.Api, LogFeature.CreateUser, JsonConvert.SerializeObject(userRequest).ToString());

            try
            {
                // validation
                if (ModelState.IsValid)
                {
                    var user = new User
                    {
                        //Id = Guid.NewGuid(),
                        UserName = userRequest.Username,
                        FirstName = userRequest.FirstName,
                        LastName = userRequest.LastName,
                        //Password = userRequest.Password,
                        CreatedOn = DateTime.Now
                    };

                    IdentityResult result = await _userService.CreateUserAsync(user, userRequest.Password);
                    if (result.Succeeded)
                    {
                        // log api response
                        //_idpLogger.LogInformation(Messages.ApiResponseSent + " | {Category} {Feature} {DetailMessage}", LogCategory.Api, LogFeature.CreateUser, JsonConvert.SerializeObject(new { UserId = user.Id }).ToString());
                        return new OkObjectResult(new { UserId = user.Id });
                    }

                    //if (result.Errors != null && result.Errors.Count() > 0)
                    //{
                    //    foreach (var error in result.Errors)
                    //    {
                    //        string field = string.Empty;
                    //        if (error.Code.Contains("password", StringComparison.OrdinalIgnoreCase))
                    //        {
                    //            field = "Password";
                    //        }
                    //        else if (error.Code.Contains("Email", StringComparison.OrdinalIgnoreCase))
                    //        {
                    //            field = "Email";
                    //        }
                    //        else if (error.Code.Contains("Username", StringComparison.OrdinalIgnoreCase))
                    //        {
                    //            field = "Username";
                    //        }

                    //        ModelState.AddModelError(field, error.Description);
                    //    }
                    //}
                    //else
                    //{
                    //    // log error
                    //    _idpLogger.LogError(Messages.UserCreationFailedMessage + " | {Category} {Feature}", LogCategory.Api, LogFeature.CreateUser);
                    //    return new InternalServerErrorObjectResult(Messages.UserCreationFailedMessage);
                    //}
                }

                ValidationErrorResponse errorResponse = new ValidationErrorResponse(HttpStatusCode.BadRequest, Messages.ValidationErrorOccurred, ModelState);
                // log api response - 400
                //_idpLogger.LogError(Messages.ValidationErrorOccurred + " | {Category} {Feature} {DetailMessage}", LogCategory.Api, LogFeature.CreateUser, JsonConvert.SerializeObject(errorResponse).ToString());
                return new BadRequestObjectResult(errorResponse);

            }
            catch (Exception ex)
            {
                // log exception
                //_idpLogger.LogError(ex, String.Format(Messages.UserCreateErrorLogMessage, userRequest.Username) + " | {Category} {Feature}", LogCategory.Api, LogFeature.CreateUser);
                return new InternalServerErrorObjectResult();
            }
        }
    }
}
