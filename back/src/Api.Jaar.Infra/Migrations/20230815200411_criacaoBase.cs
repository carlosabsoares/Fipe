using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Jaar.Infra.Migrations
{
    /// <inheritdoc />
    public partial class criacaoBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InformacoesVeiculos",
                columns: table => new
                {
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    AnoModelo = table.Column<int>(type: "int", nullable: false),
                    CodigoFipe = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TipoVeiculo = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacoesVeiculos", x => x.TipoCombustivel);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacoesVeiculos");
        }
    }
}
