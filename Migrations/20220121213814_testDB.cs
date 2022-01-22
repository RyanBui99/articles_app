using Microsoft.EntityFrameworkCore.Migrations;

namespace articles_app.Migrations
{
    public partial class testDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                column: "ConcurrencyStamp",
                value: "bd27d48a-2fb9-4861-8bd6-0bab6a26ee69");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "677c4f89-4d28-4200-bef0-218d4e20b4af", "AQAAAAEAACcQAAAAEE/dE6diqcSlNtrYvlkLJKUjZsOvhF3uitlx68CMxR+hWpcu+BnJ5pZhEk4ZS4L4RQ==", "132d21e3-5747-4fc9-9cf8-c0edf84aa5b1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                column: "ConcurrencyStamp",
                value: "36a8df73-c625-4766-ae99-80b0dd506720");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a10d9476-16ba-4955-a31a-c9a702d827ae", "AQAAAAEAACcQAAAAEOFwMlqnay2hi7HRu/JvIUuRJsPWA07/XHGEgZWhoBgS61AGIg2B5AQeu0h8FsNYoA==", "70e54f3b-3bb9-45c2-9a78-dfb7cfbfff2d" });
        }
    }
}
