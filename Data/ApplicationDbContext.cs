using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace articles_app.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // any unique string id
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ADMIN_ROLE_ID = "ad376a8f-9eab-4bb9-9fca-30b01540f445";

            const string EDITOR_ID = "v18be9c0-aa65-4af8-bd17-00bd9344e576";
            const string EDITOR_ROLE_ID = "vd376a8f-9eab-4bb9-9fca-30b01540f446";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "admin",
                NormalizedName = "admin"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = EDITOR_ROLE_ID,
                Name = "editor",
                NormalizedName = "editor"
            });

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                PasswordHash = hasher.HashPassword(null, "Admin123#"),
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id=EDITOR_ID,
                UserName = "editor@editor.com",
                Email = "editor@editor.com",
                PasswordHash = hasher.HashPassword(null, "Admin123#"),
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = EDITOR_ROLE_ID,
                UserId = EDITOR_ID
            });
        }
    }
}
