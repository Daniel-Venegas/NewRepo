using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class EtapaAprendizaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EtapaAprendizaje",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAgricultor = table.Column<int>(type: "int", nullable: false),
                    IdEtapa = table.Column<int>(type: "int", nullable: false),
                    FechaInit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgricultoresIdAgricultor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaAprendizaje", x => x.IdEstado);
                    table.ForeignKey(
                        name: "FK_EtapaAprendizaje_Agricultores_AgricultoresIdAgricultor",
                        column: x => x.AgricultoresIdAgricultor,
                        principalTable: "Agricultores",
                        principalColumn: "IdAgricultor");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtapaAprendizaje_AgricultoresIdAgricultor",
                table: "EtapaAprendizaje",
                column: "AgricultoresIdAgricultor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtapaAprendizaje");
        }
    }
}
