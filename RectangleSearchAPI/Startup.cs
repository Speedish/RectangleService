using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RectangleSearchAPI.DataAccess.Data;
using RectangleSearchAPI.DataAccess.Domain.Models;
using RectangleSearchAPI.Web.Auth;
using RectangleSearchAPI.Web.Services;

namespace RectangleSearchAPI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<RectangleContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<UserManager<User>>();

            services.AddRazorPages();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<RectangleContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            // HttpContext Accessor service
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRectangleService, RectangleService>();

            services
                .AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = "BasicAuthentication";
                    o.DefaultChallengeScheme = "BasicAuthentication";
                })
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            //services.AddScoped<IUserService, UserService>();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
