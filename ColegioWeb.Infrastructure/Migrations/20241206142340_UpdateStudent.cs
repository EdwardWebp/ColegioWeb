using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColegioWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Estudiantes_EstudiantesId",
                table: "Estudiantes");

            migrationBuilder.RenameColumn(
                name: "EstudiantesId",
                table: "Estudiantes",
                newName: "EstudianteId");

            migrationBuilder.RenameIndex(
                name: "IX_Estudiantes_EstudiantesId",
                table: "Estudiantes",
                newName: "IX_Estudiantes_EstudianteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Estudiantes_EstudianteId",
                table: "Estudiantes",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Estudiantes_EstudianteId",
                table: "Estudiantes");

            migrationBuilder.RenameColumn(
                name: "EstudianteId",
                table: "Estudiantes",
                newName: "EstudiantesId");

            migrationBuilder.RenameIndex(
                name: "IX_Estudiantes_EstudianteId",
                table: "Estudiantes",
                newName: "IX_Estudiantes_EstudiantesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Estudiantes_EstudiantesId",
                table: "Estudiantes",
                column: "EstudiantesId",
                principalTable: "Estudiantes",
                principalColumn: "Id");
        }
    }
}
