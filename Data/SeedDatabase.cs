using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace articles_app.Data
{
    public static class SeedDatabase
    {
        public static void SeedUsers(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            context.Database.EnsureCreated();

            if (userManager.FindByEmailAsync("admin@admin.com").Result == null || userManager.FindByEmailAsync("editor@editor.com").Result == null)
            {
                IdentityUser adminUser = new IdentityUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                IdentityUser editorUser = new IdentityUser
                {
                    UserName = "editor@editor.com",
                    Email = "editor@editor.com"
                };

                IdentityResult resultAdmin = userManager.CreateAsync(adminUser, "admin123!").Result;
                IdentityResult resultEditor = userManager.CreateAsync(adminUser, "admin123!").Result;

                if (resultAdmin.Succeeded ||resultEditor.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                    userManager.AddToRoleAsync(editorUser, "Editor").Wait();
                }
            }
        }
    }
}
