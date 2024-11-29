using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColegioWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asignaturas_asignaturas_AsignaturaID",
                table: "asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_estudiantes_estudiantes_EstudiantesID",
                table: "estudiantes");

            migrationBuilder.RenameColumn(
                name: "EstudiantesID",
                table: "estudiantes",
                newName: "EstudiantesId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "estudiantes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_estudiantes_EstudiantesID",
                table: "estudiantes",
                newName: "IX_estudiantes_EstudiantesId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "calificaciones",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "asistencias",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AsignaturaID",
                table: "asignaturas",
                newName: "AsignaturaId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "asignaturas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_asignaturas_AsignaturaID",
                table: "asignaturas",
                newName: "IX_asignaturas_AsignaturaId");

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "estudiantes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "calificaciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "calificaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "asistencias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "asistencias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "asignaturas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "asignaturas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "asignaturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_asignaturas_asignaturas_AsignaturaId",
                table: "asignaturas",
                column: "AsignaturaId",
                principalTable: "asignaturas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_estudiantes_estudiantes_EstudiantesId",
                table: "estudiantes",
                column: "EstudiantesId",
                principalTable: "estudiantes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asignaturas_asignaturas_AsignaturaId",
                table: "asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_estudiantes_estudiantes_EstudiantesId",
                table: "estudiantes");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "estudiantes");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "estudiantes");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "calificaciones");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "calificaciones");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "asistencias");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "asistencias");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "asignaturas");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "asignaturas");

            migrationBuilder.RenameColumn(
                name: "EstudiantesId",
                table: "estudiantes",
                newName: "EstudiantesID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "estudiantes",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_estudiantes_EstudiantesId",
                table: "estudiantes",
                newName: "IX_estudiantes_EstudiantesID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "calificaciones",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "asistencias",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "AsignaturaId",
                table: "asignaturas",
                newName: "AsignaturaID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "asignaturas",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_asignaturas_AsignaturaId",
                table: "asignaturas",
                newName: "IX_asignaturas_AsignaturaID");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "asignaturas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_asignaturas_asignaturas_AsignaturaID",
                table: "asignaturas",
                column: "AsignaturaID",
                principalTable: "asignaturas",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_estudiantes_estudiantes_EstudiantesID",
                table: "estudiantes",
                column: "EstudiantesID",
                principalTable: "estudiantes",
                principalColumn: "ID");
        }
    }
}
