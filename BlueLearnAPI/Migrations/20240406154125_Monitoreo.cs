using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class Monitoreo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monitoreo",
                columns: table => new
                {
                    IdMonitoreo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaMonitoreo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    IdDescripcionMonitoreo = table.Column<int>(type: "int", nullable: false),
                    IdCultivo = table.Column<int>(type: "int", nullable: false),
                    CultivosIdCultivo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoreo", x => x.IdMonitoreo);
                    table.ForeignKey(
                        name: "FK_Monitoreo_Cultivos_CultivosIdCultivo",
                        column: x => x.CultivosIdCultivo,
                        principalTable: "Cultivos",
                        principalColumn: "IdCultivo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monitoreo_CultivosIdCultivo",
                table: "Monitoreo",
                column: "CultivosIdCultivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitoreo");
        }
    }
}
