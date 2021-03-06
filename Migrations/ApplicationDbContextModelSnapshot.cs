// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using articles_app.Data;

namespace articles_app.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                            ConcurrencyStamp = "44961897-76f5-4886-be77-721a278100f4",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "vd376a8f-9eab-4bb9-9fca-30b01540f446",
                            ConcurrencyStamp = "8c60a06f-bf8e-4dc1-8da5-4c16bfa75e8d",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "be884e05-2728-414d-be4f-75bc63cd3b65",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBR/udLcGH5E7JjI2ysMMUdMSKSxS90ClnPSkHKCX9nhjQugBElpKvemxMa6JBL1Lw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "476c9b32-df45-4a0a-b866-19602a04ba3c",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        },
                        new
                        {
                            Id = "xy376a8f-9eab-4bb9-9fca-30b01540f44z",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4ad80009-d81b-41f0-bc4c-47fc99b9ca76",
                            Email = "user@user.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@USER.com",
                            NormalizedUserName = "USER@USER.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEBQ+cYryPWDwA1RXKnoDq0I7tFoFbObAJFNL9aLiLMwGlbxxFoDfWAJGvdCuWAcioQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "568e900d-9db8-4fd6-80b2-6ded80b2faa5",
                            TwoFactorEnabled = false,
                            UserName = "user@user.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            RoleId = "ad376a8f-9eab-4bb9-9fca-30b01540f445"
                        },
                        new
                        {
                            UserId = "xy376a8f-9eab-4bb9-9fca-30b01540f44z",
                            RoleId = "vd376a8f-9eab-4bb9-9fca-30b01540f446"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("articles_app.Models.BlogPostModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Preview")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogPosts");

                    b.HasData(
                        new
                        {
                            Id = "f366a9bb-7908-4033-af39-686f6c02d244",
                            Content = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.",
                            Header = "I gave it a cold? I gave it a virus.",
                            ImageName = "Sprinkle.svg",
                            Preview = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..."
                        },
                        new
                        {
                            Id = "529e74bb-d0b9-481d-8b9e-ca28ef4671e4",
                            Content = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.",
                            Header = "I gave it a cold? I gave it a virus.",
                            ImageName = "Sprinkle2.svg",
                            Preview = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..."
                        },
                        new
                        {
                            Id = "9292bc91-347a-46c7-a316-7a3b7e33fd41",
                            Content = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.",
                            Header = "I gave it a cold? I gave it a virus.",
                            ImageName = "Sprinkle3.svg",
                            Preview = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..."
                        },
                        new
                        {
                            Id = "6369285f-8b53-4bdd-8678-0b16b15f2d16",
                            Content = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.",
                            Header = "I gave it a cold? I gave it a virus.",
                            ImageName = "Sprinkle4.svg",
                            Preview = "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..."
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
