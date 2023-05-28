using Microsoft.AspNetCore.Identity;
using RectangleSearchAPI.DataAccess.Data;
using RectangleSearchAPI.DataAccess.Domain.Models;
using System.Security.Cryptography;

namespace RectangleSearchAPI.Web.Auth
{
    public class AuthManager
    {
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// The context
        /// </summary>
        private readonly RectangleContext _context;

        /// <summary>
        /// The HTTP context accessor
        /// </summary>
        private IHttpContextAccessor _httpContextAccessor;

        public AuthManager(
            UserManager<User> userManager,
            RectangleContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

    }
}
