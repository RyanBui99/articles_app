using articles_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace articles_app.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BlogPostModel> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
            //// any unique string id
            //const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            //const string ADMIN_ROLE_ID = "ad376a8f-9eab-4bb9-9fca-30b01540f445";

            //builder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Id = ADMIN_ROLE_ID,
            //    Name = "admin",
            //    NormalizedName = "ADMIN",
            //});

            //var hasher = new PasswordHasher<IdentityUser>();
            //builder.Entity<IdentityUser>().HasData(new IdentityUser
            //{
            //    Id = ADMIN_ID,
            //    UserName = "admin@admin.com",
            //    Email = "admin@admin.com",
            //    PasswordHash = hasher.HashPassword(null, "Admin123#"),
            //    EmailConfirmed = true,
            //    NormalizedUserName = "ADMIN@ADMIN.COM",
            //    NormalizedEmail = "ADMIN@ADMIN.COM"
            //});

            //builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = ADMIN_ROLE_ID,
            //    UserId = ADMIN_ID
            //});
        }
    }
}
