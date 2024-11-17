using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyEntitySecurity.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertedTheUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "password", "role", "username" },
                values: new object[,]
                {
                    { 1, "joelmk28", "ADMIN", "joelmk28" },
                    { 2, "joelmk28", "ETUDIANT", "daniel" },
                    { 3, "joelmk28", "PROD", "claudient" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
