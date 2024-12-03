using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColegioWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cuartamig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asignaturas_asignaturas_AsignaturaId",
                table: "asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_asistencias_asignaturas_IDasignatura",
                table: "asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_asistencias_estudiantes_IDEstudiante",
                table: "asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_calificaciones_asignaturas_IDasignatura",
                table: "calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_calificaciones_estudiantes_IDEstudiante",
                table: "calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_estudiantes_estudiantes_EstudiantesId",
                table: "estudiantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estudiantes",
                table: "estudiantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_calificaciones",
                table: "calificaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asistencias",
                table: "asistencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asignaturas",
                table: "asignaturas");

            migrationBuilder.DropColumn(
                name: "Literal",
                table: "calificaciones");

            migrationBuilder.RenameTable(
                name: "estudiantes",
                newName: "Estudiantes");

            migrationBuilder.RenameTable(
                name: "calificaciones",
                newName: "Calificaciones");

            migrationBuilder.RenameTable(
                name: "asistencias",
                newName: "Asistencias");

            migrationBuilder.RenameTable(
                name: "asignaturas",
                newName: "Asignaturas");

            migrationBuilder.RenameIndex(
                name: "IX_estudiantes_EstudiantesId",
                table: "Estudiantes",
                newName: "IX_Estudiantes_EstudiantesId");

            migrationBuilder.RenameIndex(
                name: "IX_calificaciones_IDEstudiante",
                table: "Calificaciones",
                newName: "IX_Calificaciones_IDEstudiante");

            migrationBuilder.RenameIndex(
                name: "IX_calificaciones_IDasignatura",
                table: "Calificaciones",
                newName: "IX_Calificaciones_IDasignatura");

            migrationBuilder.RenameIndex(
                name: "IX_asistencias_IDEstudiante",
                table: "Asistencias",
                newName: "IX_Asistencias_IDEstudiante");

            migrationBuilder.RenameIndex(
                name: "IX_asistencias_IDasignatura",
                table: "Asistencias",
                newName: "IX_Asistencias_IDasignatura");

            migrationBuilder.RenameIndex(
                name: "IX_asignaturas_AsignaturaId",
                table: "Asignaturas",
                newName: "IX_Asignaturas_AsignaturaId");

            migrationBuilder.AlterColumn<string>(
                name: "Descripción",
                table: "Estudiantes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Asignaturas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calificaciones",
                table: "Calificaciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asistencias",
                table: "Asistencias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asignaturas",
                table: "Asignaturas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaturas_Asignaturas_AsignaturaId",
                table: "Asignaturas",
                column: "AsignaturaId",
                principalTable: "Asignaturas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Asignaturas_IDasignatura",
                table: "Asistencias",
                column: "IDasignatura",
                principalTable: "Asignaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Estudiantes_IDEstudiante",
                table: "Asistencias",
                column: "IDEstudiante",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Asignaturas_IDasignatura",
                table: "Calificaciones",
                column: "IDasignatura",
                principalTable: "Asignaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Estudiantes_IDEstudiante",
                table: "Calificaciones",
                column: "IDEstudiante",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Estudiantes_EstudiantesId",
                table: "Estudiantes",
                column: "EstudiantesId",
                principalTable: "Estudiantes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_Asignaturas_AsignaturaId",
                table: "Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Asignaturas_IDasignatura",
                table: "Asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Estudiantes_IDEstudiante",
                table: "Asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Asignaturas_IDasignatura",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Estudiantes_IDEstudiante",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Estudiantes_EstudiantesId",
                table: "Estudiantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calificaciones",
                table: "Calificaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asistencias",
                table: "Asistencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asignaturas",
                table: "Asignaturas");

            migrationBuilder.RenameTable(
                name: "Estudiantes",
                newName: "estudiantes");

            migrationBuilder.RenameTable(
                name: "Calificaciones",
                newName: "calificaciones");

            migrationBuilder.RenameTable(
                name: "Asistencias",
                newName: "asistencias");

            migrationBuilder.RenameTable(
                name: "Asignaturas",
                newName: "asignaturas");

            migrationBuilder.RenameIndex(
                name: "IX_Estudiantes_EstudiantesId",
                table: "estudiantes",
                newName: "IX_estudiantes_EstudiantesId");

            migrationBuilder.RenameIndex(
                name: "IX_Calificaciones_IDEstudiante",
                table: "calificaciones",
                newName: "IX_calificaciones_IDEstudiante");

            migrationBuilder.RenameIndex(
                name: "IX_Calificaciones_IDasignatura",
                table: "calificaciones",
                newName: "IX_calificaciones_IDasignatura");

            migrationBuilder.RenameIndex(
                name: "IX_Asistencias_IDEstudiante",
                table: "asistencias",
                newName: "IX_asistencias_IDEstudiante");

            migrationBuilder.RenameIndex(
                name: "IX_Asistencias_IDasignatura",
                table: "asistencias",
                newName: "IX_asistencias_IDasignatura");

            migrationBuilder.RenameIndex(
                name: "IX_Asignaturas_AsignaturaId",
                table: "asignaturas",
                newName: "IX_asignaturas_AsignaturaId");

            migrationBuilder.AlterColumn<string>(
                name: "Descripción",
                table: "estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "Literal",
                table: "calificaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "asignaturas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_estudiantes",
                table: "estudiantes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_calificaciones",
                table: "calificaciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asistencias",
                table: "asistencias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asignaturas",
                table: "asignaturas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_asignaturas_asignaturas_AsignaturaId",
                table: "asignaturas",
                column: "AsignaturaId",
                principalTable: "asignaturas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_asistencias_asignaturas_IDasignatura",
                table: "asistencias",
                column: "IDasignatura",
                principalTable: "asignaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asistencias_estudiantes_IDEstudiante",
                table: "asistencias",
                column: "IDEstudiante",
                principalTable: "estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_calificaciones_asignaturas_IDasignatura",
                table: "calificaciones",
                column: "IDasignatura",
                principalTable: "asignaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_calificaciones_estudiantes_IDEstudiante",
                table: "calificaciones",
                column: "IDEstudiante",
                principalTable: "estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_estudiantes_estudiantes_EstudiantesId",
                table: "estudiantes",
                column: "EstudiantesId",
                principalTable: "estudiantes",
                principalColumn: "Id");
        }
    }
}
