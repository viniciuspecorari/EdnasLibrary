using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdnasLibrary.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InicializeRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0be6d279-8688-40ba-9d1f-9e66396d839c", null, "Librarian", "LIBRARIAN" },
                    { "12eb63a3-b8d1-4885-9c79-7a4e18a2305d", null, "Administrator", "ADMINISTRATOR" },
                    { "b8798fb1-e8d3-4ad3-aab3-98cdd8a7f362", null, "User", "USER" },
                    { "bdeb6872-8d78-48a8-b885-3b19e8a3d312", null, "UserApi", "USERAPI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0be6d279-8688-40ba-9d1f-9e66396d839c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12eb63a3-b8d1-4885-9c79-7a4e18a2305d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8798fb1-e8d3-4ad3-aab3-98cdd8a7f362");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdeb6872-8d78-48a8-b885-3b19e8a3d312");
        }
    }
}
