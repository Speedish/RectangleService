using Microsoft.EntityFrameworkCore;
using RectangleService.Infrastructure.Data;
using RectangleService.Infrastructure.Domain.Models;

namespace RectangleService.Api.Services
{
    /// <summary>
    /// RectangleService
    /// </summary>
    /// <seealso cref="RectangleService.Api.Services.IRectangleService" />
    public class RectangleService : IRectangleService
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly RectangleContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RectangleService(RectangleContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Searches the rectangles.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public List<Rectangle> SearchRectangles(CoordinateInput input)
        {
            var rectangles = _dbContext.Rectangles.AsEnumerable()
                            .Where(r =>
                                input.Coordinates.Any(c => c.X >= r.X && c.X <= (r.X + r.Width) && c.Y >= r.Y && c.Y <= (r.Y + r.Height)))
                            .ToList();

            return rectangles;
        }
    }
}
