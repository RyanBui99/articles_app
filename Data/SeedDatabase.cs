using articles_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace articles_app.Data
{
    public static class SeedDatabase
    {
        public static void Seed(this ModelBuilder builder)
        {
            // any unique string id
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ADMIN_ROLE_ID = "ad376a8f-9eab-4bb9-9fca-30b01540f445";
            const string USER_ROLE_ID = "vd376a8f-9eab-4bb9-9fca-30b01540f446";
            const string USER_ID = "xy376a8f-9eab-4bb9-9fca-30b01540f44z";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "admin",
                NormalizedName = "ADMIN",
            },
            new IdentityRole {
                Id = USER_ROLE_ID,
                Name = "user",
                NormalizedName = "USER",
            });

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                PasswordHash = hasher.HashPassword(null, "Admin123#"),
                EmailConfirmed = true,
                NormalizedUserName = "ADMIN@ADMIN.COM",
                NormalizedEmail = "ADMIN@ADMIN.COM"
            },
            new IdentityUser{
                Id = USER_ID,
                UserName = "user@user.com",
                Email = "user@user.com",
                PasswordHash = hasher.HashPassword(null, "User123#"),
                EmailConfirmed = true,
                NormalizedUserName = "USER@USER.com",
                NormalizedEmail = "USER@USER.com"
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            },
            new IdentityUserRole<string>{
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            });

            builder.Entity<BlogPostModel>()
               .HasData(
               new BlogPostModel
               {
                   Id = Guid.NewGuid().ToString(),
                   Header = "I gave it a cold? I gave it a virus.",
                   Preview = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes...",
                   Content = $"I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!" +
                   Environment.NewLine +
                   $"You know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows." +
                   Environment.NewLine +
                   $"You know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!" +
                   Environment.NewLine +
                   $"Did he just throw my cat out of the window ? Must go faster.Yeah," +
                   $"but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers." +
                   Environment.NewLine +
                   $"Must go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.",
                   ImageName = "Sprinkle.svg",
               },
               new BlogPostModel
               {
                   Id = Guid.NewGuid().ToString(),
                   Header = "I gave it a cold? I gave it a virus.",
                   Preview = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes...",
                   Content = $"I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!" +
                   Environment.NewLine +
                   $"You know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows." +
                   Environment.NewLine +
                   $"You know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!" +
                   Environment.NewLine +
                   $"Did he just throw my cat out of the window ? Must go faster.Yeah," +
                   $"but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers." +
                   Environment.NewLine +
                   $"Must go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.",
                   ImageName = "Sprinkle2.svg",
               },
               new BlogPostModel
               {
                   Id = Guid.NewGuid().ToString(),
                   Header = "I gave it a cold? I gave it a virus.",
                   Preview = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes...",
                   Content = $"I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!" +
                   Environment.NewLine +
                   $"You know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows." +
                   Environment.NewLine +
                   $"You know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!" +
                   Environment.NewLine +
                   $"Did he just throw my cat out of the window ? Must go faster.Yeah," +
                   $"but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers." +
                   Environment.NewLine +
                   $"Must go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.",
                   ImageName = "Sprinkle3.svg",
               },
               new BlogPostModel
               {
                   Id = Guid.NewGuid().ToString(),
                   Header = "I gave it a cold? I gave it a virus.",
                   Preview = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes...",
                   Content = $"I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!" +
                   Environment.NewLine +
                   $"You know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows." +
                   Environment.NewLine +
                   $"You know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!" +
                   Environment.NewLine +
                   $"Did he just throw my cat out of the window ? Must go faster.Yeah," +
                   $"but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers." +
                   Environment.NewLine +
                   $"Must go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.",
                   ImageName = "Sprinkle4.svg",
               });
        }
    }
}
