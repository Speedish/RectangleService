using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RectangleService.Infrastructure.Entities;

namespace RectangleService.Infrastructure.Context
{
    /// <summary>
    /// RectangleDBContext
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class RectangleDBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleDBContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public RectangleDBContext(DbContextOptions<RectangleDBContext> options)
            : base(options)
        {
            //SeedData();
        }

        /// <summary>
        /// Gets or sets the rectangles.
        /// </summary>
        /// <value>
        /// The rectangles.
        /// </value>
        public virtual DbSet<Rectangle> Rectangles { get; set; }
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public virtual DbSet<RectangleService.Core.Models.User> Users { get; set; }
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public virtual DbSet<IdentityRole> Roles { get; set; }
        /// <summary>
        /// Gets or sets the user claims.
        /// </summary>
        /// <value>
        /// The user claims.
        /// </value>
        public virtual DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
        /// <summary>
        /// Gets or sets the user roles.
        /// </summary>
        /// <value>
        /// The user roles.
        /// </value>
        public virtual DbSet<IdentityUserRole<string>> UserRoles { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// <para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run. However, it will still run when creating a compiled model.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
        /// examples.
        /// </para>
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Identity-related mappings and configurations
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                entity.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Roles");
            });
        }

        /// <summary>
        /// Seeds the data.
        /// </summary>
        private void SeedData()
        {
            // Generate and save 200 rectangle data entries
            for (int i = 0; i < 200; i++)
            {
                var rectangle = new Rectangle
                {
                    X = i * 10,
                    Y = i * 10,
                    Width = 10,
                    Height = 10
                };
                Rectangles.Add(rectangle);
            }

            SaveChanges();
        }
    }
}
