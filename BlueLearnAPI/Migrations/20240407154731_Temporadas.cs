using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class Temporadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TemporadasIdTemporada",
                table: "Cosechas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Temporadas",
                columns: table => new
                {
                    IdTemporada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temporada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporadas", x => x.IdTemporada);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cosechas_TemporadasIdTemporada",
                table: "Cosechas",
                column: "TemporadasIdTemporada");

            migrationBuilder.AddForeignKey(
                name: "FK_Cosechas_Temporadas_TemporadasIdTemporada",
                table: "Cosechas",
                column: "TemporadasIdTemporada",
                principalTable: "Temporadas",
                principalColumn: "IdTemporada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cosechas_Temporadas_TemporadasIdTemporada",
                table: "Cosechas");

            migrationBuilder.DropTable(
                name: "Temporadas");

            migrationBuilder.DropIndex(
                name: "IX_Cosechas_TemporadasIdTemporada",
                table: "Cosechas");

            migrationBuilder.DropColumn(
                name: "TemporadasIdTemporada",
                table: "Cosechas");
        }
    }
}
