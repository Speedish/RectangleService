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

            services.AddControllersWithViews()
                    .AddApplicationPart(typeof(Startup).Assembly)
                    .AddControllersAsServices();

        }
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
