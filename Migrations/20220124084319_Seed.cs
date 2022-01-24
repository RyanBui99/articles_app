using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace articles_app.Migrations
{
    public partial class Seed : Migration
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
                values: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "efe1665f-47cd-486f-8c5c-8310d610773e", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "ca2d191f-3915-4825-95cc-652e7c3c4e24", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMd4TFP8O+kVVDyXbPBZ+SK1NyIBgFc0ZnVZ82D2IYngDhlzAUI/Hg1xuw6OK542IQ==", null, false, "058b7561-12d1-40db-9c79-9e823cbb5ee5", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Content", "Header", "ImageName", "Preview" },
                values: new object[,]
                {
                    { "7d3c84af-c275-4eb8-8c76-82efc724d2ed", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\r\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\r\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\r\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\r\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.", "I gave it a cold? I gave it a virus.", "Sprinkle.svg", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..." },
                    { "213907f6-c192-4813-83ec-49611a7e8bfd", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\r\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\r\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\r\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\r\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.", "I gave it a cold? I gave it a virus.", "Sprinkle2.svg", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..." },
                    { "0a21b3e6-31a2-4e36-9a8d-d5292b679296", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\r\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\r\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\r\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\r\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.", "I gave it a cold? I gave it a virus.", "Sprinkle3.svg", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..." },
                    { "8043431a-4479-4425-a9bb-e44e45374dc6", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows. Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\r\nYou know what ? It is beets.I've crashed into a beet truck. So you two dig up, dig up dinosaurs? Must go faster. So you two dig up, dig up dinosaurs? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? This thing comes fully loaded. AM/FM radio, reclining bucket seats, and... power windows.\r\nYou know what ? It is beets.I've crashed into a beet truck. You really think you can fly that thing? Is this my espresso machine? Wh-what is-h-how did you get my espresso machine? Forget the fat lady! You're obsessed with the fat lady! Drive us out of here!\r\nDid he just throw my cat out of the window ? Must go faster.Yeah,but John, if The Pirates of the Caribbean breaks down, the pirates don’t eat the tourists. Hey, you know how I'm, like, always trying to save the planet? Here's my chance.God help us, we're in the hands of engineers.\r\nMust go faster... go, go, go, go, go! We gotta burn the rain forest, dump toxic waste, pollute the air, and rip up the OZONE!'Cause maybe if we screw up this planet enough, they won't want it anymore!God help us, we're in the hands of engineers. You know what? It is beets. I've crashed into a beet truck.", "I gave it a cold? I gave it a virus.", "Sprinkle4.svg", "I gave it a cold? I gave it a virus. A computer virus. God help us, we're in the hands of engineers. Jaguar shark! So tell me - does it really exist? This thing comes..." }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

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
