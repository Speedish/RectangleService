using Microsoft.AspNetCore.Identity;
using RectangleSearchAPI.DataAccess.Domain.Models;

namespace RectangleSearchAPI.Web.Services
{
    public interface IUserService
    {
        public Task<IdentityResult> CreateUserAsync(User user, string password);

        public bool AuthenticateUser(string username, string password);
    }
}
