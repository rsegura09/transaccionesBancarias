using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace transaccionesBancarias.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    cuenta_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    owner_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    initial_balance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.cuenta_id);
                });

            migrationBuilder.InsertData(
                table: "Cuenta",
                columns: new[] { "cuenta_id", "initial_balance", "owner_name" },
                values: new object[] { 1, 1000, "Richard" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuenta");
        }
    }
}
