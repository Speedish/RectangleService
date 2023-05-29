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
            //Congigure Cors
            services.ConfigureCors();

            //Configure Dependency Injection
            services.ConfigureDependencyInjection(Configuration);           

            services.AddRazorPages();

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            //Configure Swagger
            services.ConfigureSwagger();          

            // Register AutoMapper
            services.AddAutoMapper(typeof(Startup));

            services.AddRouting(options => options.LowercaseUrls=true);
       
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
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureSwagger();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
