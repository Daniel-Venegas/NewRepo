using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class Etapa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EtapaIdEtapa",
                table: "EtapaAprendizaje",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Etapa",
                columns: table => new
                {
                    IdEtapa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapa", x => x.IdEtapa);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtapaAprendizaje_EtapaIdEtapa",
                table: "EtapaAprendizaje",
                column: "EtapaIdEtapa");

            migrationBuilder.AddForeignKey(
                name: "FK_EtapaAprendizaje_Etapa_EtapaIdEtapa",
                table: "EtapaAprendizaje",
                column: "EtapaIdEtapa",
                principalTable: "Etapa",
                principalColumn: "IdEtapa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtapaAprendizaje_Etapa_EtapaIdEtapa",
                table: "EtapaAprendizaje");

            migrationBuilder.DropTable(
                name: "Etapa");

            migrationBuilder.DropIndex(
                name: "IX_EtapaAprendizaje_EtapaIdEtapa",
                table: "EtapaAprendizaje");

            migrationBuilder.DropColumn(
                name: "EtapaIdEtapa",
                table: "EtapaAprendizaje");
        }
    }
}
