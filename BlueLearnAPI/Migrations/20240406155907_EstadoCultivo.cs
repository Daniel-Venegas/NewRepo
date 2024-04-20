using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class EstadoCultivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoCultivoIdEstadoCultivo",
                table: "Cultivos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstadoCultivo",
                columns: table => new
                {
                    IdEstadoCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCultivo", x => x.IdEstadoCultivo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cultivos_EstadoCultivoIdEstadoCultivo",
                table: "Cultivos",
                column: "EstadoCultivoIdEstadoCultivo");

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivos_EstadoCultivo_EstadoCultivoIdEstadoCultivo",
                table: "Cultivos",
                column: "EstadoCultivoIdEstadoCultivo",
                principalTable: "EstadoCultivo",
                principalColumn: "IdEstadoCultivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cultivos_EstadoCultivo_EstadoCultivoIdEstadoCultivo",
                table: "Cultivos");

            migrationBuilder.DropTable(
                name: "EstadoCultivo");

            migrationBuilder.DropIndex(
                name: "IX_Cultivos_EstadoCultivoIdEstadoCultivo",
                table: "Cultivos");

            migrationBuilder.DropColumn(
                name: "EstadoCultivoIdEstadoCultivo",
                table: "Cultivos");
        }
    }
}
