using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RectangleService.Api.Auth;
using RectangleService.Core.Interfaces.Repositories;
using RectangleService.Core.Interfaces.Services;
using RectangleService.Core.Models;
using RectangleService.Core.Services;
using RectangleService.Infrastructure.Context;
using RectangleService.Infrastructure.Repositories;

namespace RectangleService.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services
                .AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = "BasicAuthentication";
                    o.DefaultChallengeScheme = "BasicAuthentication";
                })
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<RectangleDBContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<UserManager<User>>();

            services.AddDbContext<RectangleDBContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            // HttpContext Accessor service
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Register the repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRectangleRepository, RectangleRepository>();

            // Register the services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRectangleService, RectangleService.Core.Services.RectangleService>();

            return services;
        }
    }
}
