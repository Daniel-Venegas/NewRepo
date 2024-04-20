using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class Partida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartidaIdPartida",
                table: "Jugador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    IdPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePartida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdJugador = table.Column<int>(type: "int", nullable: false),
                    IdLogro = table.Column<int>(type: "int", nullable: false),
                    PuntajePartida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.IdPartida);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_PartidaIdPartida",
                table: "Jugador",
                column: "PartidaIdPartida");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugador_Partida_PartidaIdPartida",
                table: "Jugador",
                column: "PartidaIdPartida",
                principalTable: "Partida",
                principalColumn: "IdPartida");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugador_Partida_PartidaIdPartida",
                table: "Jugador");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropIndex(
                name: "IX_Jugador_PartidaIdPartida",
                table: "Jugador");

            migrationBuilder.DropColumn(
                name: "PartidaIdPartida",
                table: "Jugador");
        }
    }
}
