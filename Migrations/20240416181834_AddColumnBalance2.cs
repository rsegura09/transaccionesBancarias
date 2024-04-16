using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace transaccionesBancarias.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnBalance2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "balance",
                table: "Cuenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cuenta",
                keyColumn: "account_number",
                keyValue: 1,
                column: "balance",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "balance",
                table: "Cuenta");
        }
    }
}
