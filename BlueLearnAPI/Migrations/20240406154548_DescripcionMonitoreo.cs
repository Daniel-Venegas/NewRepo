using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class DescripcionMonitoreo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DescripcionMonitoreoIdDescripcionMonitoreo",
                table: "Monitoreo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DescripcionMonitoreo",
                columns: table => new
                {
                    IdDescripcionMonitoreo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Variable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionMonitoreo", x => x.IdDescripcionMonitoreo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monitoreo_DescripcionMonitoreoIdDescripcionMonitoreo",
                table: "Monitoreo",
                column: "DescripcionMonitoreoIdDescripcionMonitoreo");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitoreo_DescripcionMonitoreo_DescripcionMonitoreoIdDescripcionMonitoreo",
                table: "Monitoreo",
                column: "DescripcionMonitoreoIdDescripcionMonitoreo",
                principalTable: "DescripcionMonitoreo",
                principalColumn: "IdDescripcionMonitoreo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitoreo_DescripcionMonitoreo_DescripcionMonitoreoIdDescripcionMonitoreo",
                table: "Monitoreo");

            migrationBuilder.DropTable(
                name: "DescripcionMonitoreo");

            migrationBuilder.DropIndex(
                name: "IX_Monitoreo_DescripcionMonitoreoIdDescripcionMonitoreo",
                table: "Monitoreo");

            migrationBuilder.DropColumn(
                name: "DescripcionMonitoreoIdDescripcionMonitoreo",
                table: "Monitoreo");
        }
    }
}
