using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class EstadoOperacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpeCu_Cultivos_CultivosIdCultivo",
                table: "OpeCu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpeCu",
                table: "OpeCu");

            migrationBuilder.RenameTable(
                name: "OpeCu",
                newName: "OpeCultivos");

            migrationBuilder.RenameIndex(
                name: "IX_OpeCu_CultivosIdCultivo",
                table: "OpeCultivos",
                newName: "IX_OpeCultivos_CultivosIdCultivo");

            migrationBuilder.AddColumn<int>(
                name: "EstadoOperacionIdEstadoOperacion",
                table: "OpeCultivos",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpeCultivos",
                table: "OpeCultivos",
                column: "IdOperacion");

            migrationBuilder.CreateTable(
                name: "EstadoOperacion",
                columns: table => new
                {
                    IdEstadoOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoOperacion", x => x.IdEstadoOperacion);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpeCultivos_EstadoOperacionIdEstadoOperacion",
                table: "OpeCultivos",
                column: "EstadoOperacionIdEstadoOperacion");

            migrationBuilder.AddForeignKey(
                name: "FK_OpeCultivos_Cultivos_CultivosIdCultivo",
                table: "OpeCultivos",
                column: "CultivosIdCultivo",
                principalTable: "Cultivos",
                principalColumn: "IdCultivo");

            migrationBuilder.AddForeignKey(
                name: "FK_OpeCultivos_EstadoOperacion_EstadoOperacionIdEstadoOperacion",
                table: "OpeCultivos",
                column: "EstadoOperacionIdEstadoOperacion",
                principalTable: "EstadoOperacion",
                principalColumn: "IdEstadoOperacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpeCultivos_Cultivos_CultivosIdCultivo",
                table: "OpeCultivos");

            migrationBuilder.DropForeignKey(
                name: "FK_OpeCultivos_EstadoOperacion_EstadoOperacionIdEstadoOperacion",
                table: "OpeCultivos");

            migrationBuilder.DropTable(
                name: "EstadoOperacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpeCultivos",
                table: "OpeCultivos");

            migrationBuilder.DropIndex(
                name: "IX_OpeCultivos_EstadoOperacionIdEstadoOperacion",
                table: "OpeCultivos");

            migrationBuilder.DropColumn(
                name: "EstadoOperacionIdEstadoOperacion",
                table: "OpeCultivos");

            migrationBuilder.RenameTable(
                name: "OpeCultivos",
                newName: "OpeCu");

            migrationBuilder.RenameIndex(
                name: "IX_OpeCultivos_CultivosIdCultivo",
                table: "OpeCu",
                newName: "IX_OpeCu_CultivosIdCultivo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpeCu",
                table: "OpeCu",
                column: "IdOperacion");

            migrationBuilder.AddForeignKey(
                name: "FK_OpeCu_Cultivos_CultivosIdCultivo",
                table: "OpeCu",
                column: "CultivosIdCultivo",
                principalTable: "Cultivos",
                principalColumn: "IdCultivo");
        }
    }
}
