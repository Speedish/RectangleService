using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using RectangleService.Api.Auth;
using System.Reflection;
using RectangleService.Infrastructure.Context;
using RectangleService.Core.Interfaces.Services;
using RectangleService.Core.Services;
using RectangleService.Core.Models;
using RectangleService.Core.Interfaces.Repositories;
using RectangleService.Infrastructure.Repositories;

namespace RectangleService.Api
{
    /// <summary>
    /// Startup Class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<RectangleDBContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<UserManager<User>>();

            services.AddRazorPages();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<RectangleDBContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            // HttpContext Accessor service
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Register the repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRectangleRepository, RectangleRepository>();

            // Register the services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRectangleService, RectangleService.Core.Services.RectangleService>();

            // Register AutoMapper
            services.AddAutoMapper(typeof(Startup));

            services
                .AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = "BasicAuthentication";
                    o.DefaultChallengeScheme = "BasicAuthentication";
                })
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "RectangleService API",
                    Description = "Rectangle Service"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);

                // add Basic Authentication security definition
                var basicSecurityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    Reference = new OpenApiReference { Id = "BasicAuthentication", Type = ReferenceType.SecurityScheme }
                };
                c.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);

                // Security requirement filter
                //c.OperationFilter<SwaggerSecurityRequirementOperationFilter>();

            });

        }
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
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
