using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColegioWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class primeramig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asignaturas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AsignaturaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignaturas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_asignaturas_asignaturas_AsignaturaID",
                        column: x => x.AsignaturaID,
                        principalTable: "asignaturas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "estudiantes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstudiantesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiantes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_estudiantes_estudiantes_EstudiantesID",
                        column: x => x.EstudiantesID,
                        principalTable: "estudiantes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "iterales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Decripcion = table.Column<int>(type: "int", nullable: false),
                    IteralesID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "asistencias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEstudiante = table.Column<int>(type: "int", nullable: false),
                    IDasignatura = table.Column<int>(type: "int", nullable: false),
                    unable = table.Column<bool>(type: "bit", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asistencias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_asistencias_asignaturas_IDasignatura",
                        column: x => x.IDasignatura,
                        principalTable: "asignaturas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_asistencias_estudiantes_IDEstudiante",
                        column: x => x.IDEstudiante,
                        principalTable: "estudiantes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calificaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nocalificacion = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    IDEstudiante = table.Column<int>(type: "int", nullable: false),
                    IDasignatura = table.Column<int>(type: "int", nullable: false),
                    IDIteral = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calificaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_calificaciones_asignaturas_IDasignatura",
                        column: x => x.IDasignatura,
                        principalTable: "asignaturas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_calificaciones_estudiantes_IDEstudiante",
                        column: x => x.IDEstudiante,
                        principalTable: "estudiantes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_calificaciones_iterales_IDIteral",
                        column: x => x.IDIteral,
                        principalTable: "iterales",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asignaturas_AsignaturaID",
                table: "asignaturas",
                column: "AsignaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_asistencias_IDasignatura",
                table: "asistencias",
                column: "IDasignatura");

            migrationBuilder.CreateIndex(
                name: "IX_asistencias_IDEstudiante",
                table: "asistencias",
                column: "IDEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_IDasignatura",
                table: "calificaciones",
                column: "IDasignatura");

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_IDEstudiante",
                table: "calificaciones",
                column: "IDEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_IDIteral",
                table: "calificaciones",
                column: "IDIteral");

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_EstudiantesID",
                table: "estudiantes",
                column: "EstudiantesID");

            migrationBuilder.CreateIndex(
                name: "IX_iterales_IteralesID",
                table: "iterales",
                column: "IteralesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asistencias");

            migrationBuilder.DropTable(
                name: "calificaciones");

            migrationBuilder.DropTable(
                name: "asignaturas");

            migrationBuilder.DropTable(
                name: "estudiantes");

            migrationBuilder.DropTable(
                name: "iterales");
        }
    }
}
