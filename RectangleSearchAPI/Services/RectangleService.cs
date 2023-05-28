using Microsoft.EntityFrameworkCore;
using RectangleSearchAPI.DataAccess.Data;
using RectangleSearchAPI.DataAccess.Domain.Models;

namespace RectangleSearchAPI.Web.Services
{
    public class RectangleService : IRectangleService
    {
        private readonly RectangleContext _dbContext;

        public RectangleService(RectangleContext context)
        {
            _dbContext = context;
        }

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
