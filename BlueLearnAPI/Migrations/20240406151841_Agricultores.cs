using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class Agricultores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agricultores",
                columns: table => new
                {
                    IdAgricultor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdJugador = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperacionesCultivoIdOperacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agricultores", x => x.IdAgricultor);
                    table.ForeignKey(
                        name: "FK_Agricultores_OpeCultivos_OperacionesCultivoIdOperacion",
                        column: x => x.OperacionesCultivoIdOperacion,
                        principalTable: "OpeCultivos",
                        principalColumn: "IdOperacion");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agricultores_OperacionesCultivoIdOperacion",
                table: "Agricultores",
                column: "OperacionesCultivoIdOperacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agricultores");
        }
    }
}
