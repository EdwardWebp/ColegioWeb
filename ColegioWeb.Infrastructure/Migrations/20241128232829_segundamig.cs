using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColegioWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class segundamig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_calificaciones_iterales_IDIteral",
                table: "calificaciones");

            migrationBuilder.DropTable(
                name: "iterales");

            migrationBuilder.DropIndex(
                name: "IX_calificaciones_IDIteral",
                table: "calificaciones");

            migrationBuilder.DropColumn(
                name: "IDIteral",
                table: "calificaciones");

            migrationBuilder.AddColumn<string>(
                name: "Literal",
                table: "calificaciones",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Literal",
                table: "calificaciones");

            migrationBuilder.AddColumn<int>(
                name: "IDIteral",
                table: "calificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "iterales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decripcion = table.Column<int>(type: "int", nullable: false),
                    IteralesID = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iterales", x => x.ID);
                    table.ForeignKey(
                        name: "FK_iterales_iterales_IteralesID",
                        column: x => x.IteralesID,
                        principalTable: "iterales",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_IDIteral",
                table: "calificaciones",
                column: "IDIteral");

            migrationBuilder.CreateIndex(
                name: "IX_iterales_IteralesID",
                table: "iterales",
                column: "IteralesID");

            migrationBuilder.AddForeignKey(
                name: "FK_calificaciones_iterales_IDIteral",
                table: "calificaciones",
                column: "IDIteral",
                principalTable: "iterales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
