using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace transaccionesBancarias.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cuenta",
                columns: new[] { "account_number", "balance", "initial_balance", "owner_name" },
                values: new object[,]
                {
                    { 1, 2000, 2000, "Richard" },
                    { 2, 1000, 1000, "Jefferson" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cuenta",
                keyColumn: "account_number",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuenta",
                keyColumn: "account_number",
                keyValue: 2);
        }
    }
}
