using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RectangleService.Core.Interfaces.Services;
using RectangleService.Core.Models;

namespace RectangleService.Api.V1.Controllers
{
    /// <summary>
    /// RectangleController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    public class RectangleController : ControllerBase
    {
        /// <summary>
        /// The rectangle service
        /// </summary>
        private readonly IRectangleService _rectangleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleController"/> class.
        /// </summary>
        /// <param name="rectangleService">The rectangle service.</param>
        /// <exception cref="System.ArgumentNullException">rectangleService</exception>
        public RectangleController(IRectangleService rectangleService)
        {
            _rectangleService = rectangleService ?? throw new ArgumentNullException(nameof(rectangleService));
        }

        /// <summary>
        /// Searches the rectangles.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost("search")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Rectangle>>> SearchRectangles([FromBody] CoordinateInput input)
        {
            var rectangles = await _rectangleService.SearchRectangles(input).ConfigureAwait(false);

            if(rectangles==null)
                return NoContent();

            return Ok(rectangles);
        }

    }
}
