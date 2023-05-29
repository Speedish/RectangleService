using RectangleService.Core.Models;

namespace RectangleService.Core.Interfaces.Services
{
    /// <summary>
    /// IRectangleService Interface
    /// </summary>
    public interface IRectangleService
    {
        /// <summary>
        /// Gets all rectangles.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Rectangle>> GetAllRectangles();
        /// <summary>
        /// Searches the rectangles.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        Task<List<Rectangle>> SearchRectangles(CoordinateInput input);
        /// <summary>
        /// Adds the rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        Task<bool> AddRectangle(Rectangle rectangle);
        /// <summary>
        /// Updates the rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        Task<bool> UpdateRectangle(Rectangle rectangle);
        /// <summary>
        /// Deletes the rectangle.
        /// </summary>
        /// <param name="rectangleId">The rectangle identifier.</param>
        /// <returns></returns>
        Task<bool> DeleteRectangle(int rectangleId);
    }
}
