using Microsoft.EntityFrameworkCore.Migrations;

namespace articles_app.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Preview",
                table: "BlogPosts",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preview",
                table: "BlogPosts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                column: "ConcurrencyStamp",
                value: "60283b5a-c597-4bd9-97d0-243b8e895667");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e47500bc-f861-4331-9da7-5321cc6ce34b", "AQAAAAEAACcQAAAAECrnPdtfql7KoqyjT+PhNIiBsl1DGRnEExBafX/oUbFq9QQID5X3bXELVhInFk7PZQ==", "0f7bc33b-4549-444a-a17a-ed4d8de702d3" });
        }
    }
}
