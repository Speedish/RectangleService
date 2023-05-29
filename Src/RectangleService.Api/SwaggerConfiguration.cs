namespace RectangleService.Api
{
    /// <summary>
    /// SwaggerConfiguration
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Configures the swagger.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">services</exception>
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            string serviceDescription = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "ServiceDescription.md"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RectangleService.Api", Version = "v1" , Description = serviceDescription });

                string xmlFile = $"{typeof(SwaggerConfiguration).Assembly.GetName().Name}.xml";

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
                c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}");
            
            });

            return services;
        }

        /// <summary>
        /// Configures the swagger.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">app</exception>
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocumentService.Api v1"));

            return app;
        }
    }
}
