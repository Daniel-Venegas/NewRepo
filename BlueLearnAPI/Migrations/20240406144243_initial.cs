using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cultivos",
                columns: table => new
                {
                    IdCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPlantacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstadoCultivo = table.Column<int>(type: "int", nullable: false),
                    IdCampo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivos", x => x.IdCultivo);
                });

            migrationBuilder.CreateTable(
                name: "OpeCu",
                columns: table => new
                {
                    IdOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstadoOperacion = table.Column<int>(type: "int", nullable: false),
                    FechaOperacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCultivo = table.Column<int>(type: "int", nullable: false),
                    IdAgricultor = table.Column<int>(type: "int", nullable: false),
                    CultivosIdCultivo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeCu", x => x.IdOperacion);
                    table.ForeignKey(
                        name: "FK_OpeCu_Cultivos_CultivosIdCultivo",
                        column: x => x.CultivosIdCultivo,
                        principalTable: "Cultivos",
                        principalColumn: "IdCultivo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpeCu_CultivosIdCultivo",
                table: "OpeCu",
                column: "CultivosIdCultivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpeCu");

            migrationBuilder.DropTable(
                name: "Cultivos");
        }
    }
}
