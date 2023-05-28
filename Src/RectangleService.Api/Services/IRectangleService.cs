using RectangleService.Infrastructure.Domain.Models;

namespace RectangleService.Api.Services
{
    /// <summary>
    /// IRectangleService Interface
    /// </summary>
    public interface IRectangleService
    {
        /// <summary>
        /// Searches the rectangles.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public List<Rectangle> SearchRectangles(CoordinateInput input);
    }
}
