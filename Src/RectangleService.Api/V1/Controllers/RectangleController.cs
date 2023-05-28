using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RectangleService.Infrastructure.Domain.Models;
using RectangleService.Api.Services;
using System.Collections.Generic;

namespace RectangleService.Api.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    public class RectangleController : ControllerBase
    {
        private readonly IRectangleService _rectangleService;

        public RectangleController(IRectangleService rectangleService)
        {
            _rectangleService = rectangleService;
        }

        [HttpPost("search")]
        public IActionResult SearchRectangles([FromBody] CoordinateInput input)
        {
            var rectangles = _rectangleService.SearchRectangles(input);
            return Ok(rectangles);
        }

    }
}
