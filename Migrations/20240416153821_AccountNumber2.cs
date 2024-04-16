using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace transaccionesBancarias.Migrations
{
    /// <inheritdoc />
    public partial class AccountNumber2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cuenta_id",
                table: "Cuenta",
                newName: "account_number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "account_number",
                table: "Cuenta",
                newName: "cuenta_id");
        }
    }
}
