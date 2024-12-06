using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColegioWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class pruebaultim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unable",
                table: "Asistencias");

            migrationBuilder.AddColumn<int>(
                name: "estado",
                table: "Asistencias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "Asistencias");

            migrationBuilder.AddColumn<bool>(
                name: "unable",
                table: "Asistencias",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
