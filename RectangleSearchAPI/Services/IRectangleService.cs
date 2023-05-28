using RectangleSearchAPI.DataAccess.Domain.Models;

namespace RectangleSearchAPI.Web.Services
{
    public interface IRectangleService
    {
        public List<Rectangle> SearchRectangles(CoordinateInput input);
    }
}
