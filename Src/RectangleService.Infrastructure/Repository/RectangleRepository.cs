using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RectangleService.Core.Interfaces.Repositories;
using RectangleService.Infrastructure.Context;
using RectangleService.Core.Models;
using AutoMapper;

namespace RectangleService.Infrastructure.Repositories
{
    /// <summary>
    /// RectangleRepository
    /// </summary>
    /// <seealso cref="RectangleService.Core.Interfaces.Repositories.IRectangleRepository" />
    public class RectangleRepository : IRectangleRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly RectangleDBContext _dbContext;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <exception cref="System.ArgumentNullException">
        /// dbContext
        /// or
        /// mapper
        /// </exception>
        public RectangleRepository(RectangleDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            var rectangles = await _dbContext.Rectangles
                .Where(r =>
                    input.Coordinates.Any(c => c.X >= r.X && c.X <= (r.X + r.Width) && c.Y >= r.Y && c.Y <= (r.Y + r.Height)))
                .ToListAsync().ConfigureAwait(false);

            return _mapper.Map<List<Rectangle>>(rectangles);
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
