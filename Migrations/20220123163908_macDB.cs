using Microsoft.EntityFrameworkCore.Migrations;

namespace articles_app.Migrations
{
    public partial class macDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                column: "ConcurrencyStamp",
                value: "faafa8e3-0a50-40da-ac6a-039e1c92df9c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86bbeadb-74ca-4e4e-a96d-d3b4cfd135a5", "AQAAAAEAACcQAAAAEDTFKmRo7G+9wYfkfsHG9fArgF5j2xtMuzJ2lWVGhanIaneXUqjh4cYQ/MdZ6jclXw==", "e81b78dd-8cd8-43c2-9e9d-8e73e5fd63a6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                column: "ConcurrencyStamp",
                value: "ca6e8e00-fe24-4ea9-85d0-75e0d2dcce65");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e827dd2-cb93-47fa-a9ed-b8c85630febc", "AQAAAAEAACcQAAAAEEdlGu6YUmGQ9HJSUn8sb9dvO9z+ix3aMEhM+4ijWWMoLESqhkALPWzra4g/BCgMbA==", "91b898e0-eb46-487f-919f-3b093f74f4bf" });
        }
    }
}
