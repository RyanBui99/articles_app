using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace articles_app.Migrations
{
    public partial class newestDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preview = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "44961897-76f5-4886-be77-721a278100f4", "admin", "ADMIN" },
                    { "vd376a8f-9eab-4bb9-9fca-30b01540f446", "8c60a06f-bf8e-4dc1-8da5-4c16bfa75e8d", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "be884e05-2728-414d-be4f-75bc63cd3b65", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBR/udLcGH5E7JjI2ysMMUdMSKSxS90ClnPSkHKCX9nhjQugBElpKvemxMa6JBL1Lw==", null, false, "476c9b32-df45-4a0a-b866-19602a04ba3c", false, "admin@admin.com" },
                    { "xy376a8f-9eab-4bb9-9fca-30b01540f44z", 0, "4ad80009-d81b-41f0-bc4c-47fc99b9ca76", "user@user.com", true, false, null, "USER@USER.com", "USER@USER.com", "AQAAAAEAACcQAAAAEBQ+cYryPWDwA1RXKnoDq0I7tFoFbObAJFNL9aLiLMwGlbxxFoDfWAJGvdCuWAcioQ==", null, false, "568e900d-9db8-4fd6-80b2-6ded80b2faa5", false, "user@user.com" }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Content", "Header", "ImageName", "Preview" },
                values: new object[,]
                {
                    { "f366a9bb-7908-4033-af39-686f6c02d244", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.", "I gave it a cold? I gave it a virus.", "Sprinkle.svg", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..." },
                    { "529e74bb-d0b9-481d-8b9e-ca28ef4671e4", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.", "I gave it a cold? I gave it a virus.", "Sprinkle2.svg", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..." },
                    { "9292bc91-347a-46c7-a316-7a3b7e33fd41", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.", "I gave it a cold? I gave it a virus.", "Sprinkle3.svg", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..." },
                    { "6369285f-8b53-4bdd-8678-0b16b15f2d16", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.", "I gave it a cold? I gave it a virus.", "Sprinkle4.svg", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..." }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "vd376a8f-9eab-4bb9-9fca-30b01540f446", "xy376a8f-9eab-4bb9-9fca-30b01540f44z" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
