using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class Logro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agricultores_OpeCultivos_OperacionesCultivoIdOperacion",
                table: "Agricultores");

            migrationBuilder.DropForeignKey(
                name: "FK_Jugador_Agricultores_AgricultoresIdAgricultor",
                table: "Jugador");

            migrationBuilder.DropForeignKey(
                name: "FK_Jugador_Partida_PartidaIdPartida",
                table: "Jugador");

            migrationBuilder.DropIndex(
                name: "IX_Jugador_AgricultoresIdAgricultor",
                table: "Jugador");

            migrationBuilder.DropIndex(
                name: "IX_Jugador_PartidaIdPartida",
                table: "Jugador");

            migrationBuilder.DropColumn(
                name: "AgricultoresIdAgricultor",
                table: "Jugador");

            migrationBuilder.DropColumn(
                name: "PartidaIdPartida",
                table: "Jugador");

            migrationBuilder.RenameColumn(
                name: "OperacionesCultivoIdOperacion",
                table: "Agricultores",
                newName: "JugadorIdJugador");

            migrationBuilder.RenameIndex(
                name: "IX_Agricultores_OperacionesCultivoIdOperacion",
                table: "Agricultores",
                newName: "IX_Agricultores_JugadorIdJugador");

            migrationBuilder.AddColumn<int>(
                name: "JugadorIdJugador",
                table: "Partida",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogroIdLogro",
                table: "Partida",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgricultoresIdAgricultor",
                table: "OpeCultivos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Logro",
                columns: table => new
                {
                    IdLogro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Puntos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logro", x => x.IdLogro);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partida_JugadorIdJugador",
                table: "Partida",
                column: "JugadorIdJugador");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_LogroIdLogro",
                table: "Partida",
                column: "LogroIdLogro");

            migrationBuilder.CreateIndex(
                name: "IX_OpeCultivos_AgricultoresIdAgricultor",
                table: "OpeCultivos",
                column: "AgricultoresIdAgricultor");

            migrationBuilder.AddForeignKey(
                name: "FK_Agricultores_Jugador_JugadorIdJugador",
                table: "Agricultores",
                column: "JugadorIdJugador",
                principalTable: "Jugador",
                principalColumn: "IdJugador");

            migrationBuilder.AddForeignKey(
                name: "FK_OpeCultivos_Agricultores_AgricultoresIdAgricultor",
                table: "OpeCultivos",
                column: "AgricultoresIdAgricultor",
                principalTable: "Agricultores",
                principalColumn: "IdAgricultor");

            migrationBuilder.AddForeignKey(
                name: "FK_Partida_Jugador_JugadorIdJugador",
                table: "Partida",
                column: "JugadorIdJugador",
                principalTable: "Jugador",
                principalColumn: "IdJugador");

            migrationBuilder.AddForeignKey(
                name: "FK_Partida_Logro_LogroIdLogro",
                table: "Partida",
                column: "LogroIdLogro",
                principalTable: "Logro",
                principalColumn: "IdLogro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agricultores_Jugador_JugadorIdJugador",
                table: "Agricultores");

            migrationBuilder.DropForeignKey(
                name: "FK_OpeCultivos_Agricultores_AgricultoresIdAgricultor",
                table: "OpeCultivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Partida_Jugador_JugadorIdJugador",
                table: "Partida");

            migrationBuilder.DropForeignKey(
                name: "FK_Partida_Logro_LogroIdLogro",
                table: "Partida");

            migrationBuilder.DropTable(
                name: "Logro");

            migrationBuilder.DropIndex(
                name: "IX_Partida_JugadorIdJugador",
                table: "Partida");

            migrationBuilder.DropIndex(
                name: "IX_Partida_LogroIdLogro",
                table: "Partida");

            migrationBuilder.DropIndex(
                name: "IX_OpeCultivos_AgricultoresIdAgricultor",
                table: "OpeCultivos");

            migrationBuilder.DropColumn(
                name: "JugadorIdJugador",
                table: "Partida");

            migrationBuilder.DropColumn(
                name: "LogroIdLogro",
                table: "Partida");

            migrationBuilder.DropColumn(
                name: "AgricultoresIdAgricultor",
                table: "OpeCultivos");

            migrationBuilder.RenameColumn(
                name: "JugadorIdJugador",
                table: "Agricultores",
                newName: "OperacionesCultivoIdOperacion");

            migrationBuilder.RenameIndex(
                name: "IX_Agricultores_JugadorIdJugador",
                table: "Agricultores",
                newName: "IX_Agricultores_OperacionesCultivoIdOperacion");

            migrationBuilder.AddColumn<int>(
                name: "AgricultoresIdAgricultor",
                table: "Jugador",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartidaIdPartida",
                table: "Jugador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_AgricultoresIdAgricultor",
                table: "Jugador",
                column: "AgricultoresIdAgricultor");

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_PartidaIdPartida",
                table: "Jugador",
                column: "PartidaIdPartida");

            migrationBuilder.AddForeignKey(
                name: "FK_Agricultores_OpeCultivos_OperacionesCultivoIdOperacion",
                table: "Agricultores",
                column: "OperacionesCultivoIdOperacion",
                principalTable: "OpeCultivos",
                principalColumn: "IdOperacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugador_Agricultores_AgricultoresIdAgricultor",
                table: "Jugador",
                column: "AgricultoresIdAgricultor",
                principalTable: "Agricultores",
                principalColumn: "IdAgricultor");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugador_Partida_PartidaIdPartida",
                table: "Jugador",
                column: "PartidaIdPartida",
                principalTable: "Partida",
                principalColumn: "IdPartida");
        }
    }
}
