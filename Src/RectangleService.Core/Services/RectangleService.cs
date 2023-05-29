using Microsoft.Extensions.Logging;
using RectangleService.Core.Interfaces.Repositories;
using RectangleService.Core.Interfaces.Services;
using RectangleService.Core.Models;

namespace RectangleService.Core.Services
{
    /// <summary>
    /// RectangleService
    /// </summary>
    /// <seealso cref="RectangleService.Core.Interfaces.Services.IRectangleService" />
    /// <seealso cref="RectangleService.Api.Services.IRectangleService" />
    public class RectangleService : IRectangleService
    {
        /// <summary>
        /// The rectangle repository
        /// </summary>
        public readonly IRectangleRepository _rectangleRepository;
        /// <summary>
        /// The logger
        /// </summary>
        public readonly ILogger<RectangleService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleService" /> class.
        /// </summary>
        /// <param name="rectangleRepository">The rectangle repository.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">rectangleRepository</exception>
        public RectangleService(IRectangleRepository rectangleRepository, ILogger<RectangleService> logger)
        {
            _rectangleRepository = rectangleRepository ?? throw new ArgumentNullException(nameof(rectangleRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// Adds the rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<bool> AddRectangle(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the rectangle.
        /// </summary>
        /// <param name="rectangleId">The rectangle identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<bool> DeleteRectangle(int rectangleId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all rectangles.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<IEnumerable<Rectangle>> GetAllRectangles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches the rectangles.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public async Task<List<Rectangle>> SearchRectangles(CoordinateInput input)
        {
            try
            {
                return await _rectangleRepository.SearchRectangles(input);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call the SearchRectangles, Error Message = {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Updates the rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<bool> UpdateRectangle(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }
    }
}
