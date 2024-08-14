using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CdbInfra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxaBancarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cdb = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tb = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxaBancarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxaMensal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taxa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Meses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxaMensal", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaxaBancarias",
                columns: new[] { "Id", "Cdb", "Tb" },
                values: new object[] { 1, 0.009m, 1.08m });

            migrationBuilder.InsertData(
                table: "TaxaMensal",
                columns: new[] { "Id", "Meses", "Taxa" },
                values: new object[,]
                {
                    { 1, 6, 0.225m },
                    { 2, 12, 0.20m },
                    { 3, 24, 0.175m },
                    { 4, 0, 0.15m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxaBancarias");

            migrationBuilder.DropTable(
                name: "TaxaMensal");
        }
    }
}
