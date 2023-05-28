using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RectangleSearchAPI.DataAccess.Domain.Models;
using RectangleSearchAPI.Web.Services;
using System.Collections.Generic;

namespace RectangleSearchAPI.Web.Controllers
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
