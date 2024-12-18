﻿// <auto-generated />
using System;
using ColegioWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ColegioWeb.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241130144604_tercera")]
    partial class tercera
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ColegioWeb.Domain.Asignatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AsignaturaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripción")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AsignaturaId");

                    b.ToTable("asignaturas");
                });

            modelBuilder.Entity("ColegioWeb.Domain.Asistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("IDasignatura")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("unable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IDEstudiante");

                    b.HasIndex("IDasignatura");

                    b.ToTable("asistencias");
                });

            modelBuilder.Entity("ColegioWeb.Domain.Calificaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("IDasignatura")
                        .HasColumnType("int");

                    b.Property<string>("Literal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("nocalificacion")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id");

                    b.HasIndex("IDEstudiante");

                    b.HasIndex("IDasignatura");

                    b.ToTable("calificaciones");
                });

            modelBuilder.Entity("ColegioWeb.Domain.Estudiantes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descripción")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<int?>("EstudiantesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EstudiantesId");

                    b.ToTable("estudiantes");
                });

            modelBuilder.Entity("ColegioWeb.Domain.Asignatura", b =>
                {
                    b.HasOne("ColegioWeb.Domain.Asignatura", null)
                        .WithMany("asignaturas")
                        .HasForeignKey("AsignaturaId");
                });

            modelBuilder.Entity("ColegioWeb.Domain.Asistencia", b =>
                {
                    b.HasOne("ColegioWeb.Domain.Estudiantes", "estudiantesnav")
                        .WithMany()
                        .HasForeignKey("IDEstudiante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ColegioWeb.Domain.Asignatura", "asignaturanav")
                        .WithMany()
                        .HasForeignKey("IDasignatura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("asignaturanav");

                    b.Navigation("estudiantesnav");
                });

            modelBuilder.Entity("ColegioWeb.Domain.Calificaciones", b =>
                {
                    b.HasOne("ColegioWeb.Domain.Estudiantes", "estudiantesnav")
                        .WithMany()
                        .HasForeignKey("IDEstudiante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ColegioWeb.Domain.Asignatura", "asignaturanav")
                        .WithMany()
                        .HasForeignKey("IDasignatura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("asignaturanav");

                    b.Navigation("estudiantesnav");
                });

            modelBuilder.Entity("ColegioWeb.Domain.Estudiantes", b =>
                {
                    b.HasOne("ColegioWeb.Domain.Estudiantes", null)
                        .WithMany("estudiantes")
                        .HasForeignKey("EstudiantesId");
                });

            modelBuilder.Entity("ColegioWeb.Domain.Asignatura", b =>
                {
                    b.Navigation("asignaturas");
                });

            modelBuilder.Entity("ColegioWeb.Domain.Estudiantes", b =>
                {
                    b.Navigation("estudiantes");
                });
#pragma warning restore 612, 618
        }
    }
}
