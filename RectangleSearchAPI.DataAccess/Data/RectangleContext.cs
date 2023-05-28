using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RectangleSearchAPI.DataAccess.Domain.Models;

namespace RectangleSearchAPI.DataAccess.Data
{
    public class RectangleContext : DbContext
    {
        public DbSet<Rectangle> Rectangles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }

        public DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
        public DbSet<IdentityUserRole<string>> UserRoles { get; set; }

        public RectangleContext(DbContextOptions<RectangleContext> options)
            : base(options)
        {
        }
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
    }
}
