using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Jaar.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InformacoesVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoFipe = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AnoModelo = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacoesVeiculos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformacoesVeiculos_Id",
                table: "InformacoesVeiculos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacoesVeiculos");
        }
    }
}
