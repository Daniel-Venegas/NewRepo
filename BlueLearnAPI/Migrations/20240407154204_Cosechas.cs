using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class Cosechas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cosechas",
                columns: table => new
                {
                    IdCosechas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCosecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadRecogida = table.Column<int>(type: "int", nullable: false),
                    IdCultivo = table.Column<int>(type: "int", nullable: false),
                    IdTemporada = table.Column<int>(type: "int", nullable: false),
                    CultivosIdCultivo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cosechas", x => x.IdCosechas);
                    table.ForeignKey(
                        name: "FK_Cosechas_Cultivos_CultivosIdCultivo",
                        column: x => x.CultivosIdCultivo,
                        principalTable: "Cultivos",
                        principalColumn: "IdCultivo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cosechas_CultivosIdCultivo",
                table: "Cosechas",
                column: "CultivosIdCultivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cosechas");
        }
    }
}
