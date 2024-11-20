﻿// <auto-generated />
using System;
using ColegioWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ColegioWeb.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ColegioWeb.Core.Asignatura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AsignaturaID")
                        .HasColumnType("int");

                    b.Property<string>("Descripción")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("AsignaturaID");

                    b.ToTable("asignaturas");
                });

            modelBuilder.Entity("ColegioWeb.Core.Asistencia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("IDEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("IDasignatura")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("unable")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("IDEstudiante");

                    b.HasIndex("IDasignatura");

                    b.ToTable("asistencias");
                });

            modelBuilder.Entity("ColegioWeb.Core.Calificaciones", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("IDEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("IDIteral")
                        .HasColumnType("int");

                    b.Property<int>("IDasignatura")
                        .HasColumnType("int");

                    b.Property<decimal>("nocalificacion")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("ID");

                    b.HasIndex("IDEstudiante");

                    b.HasIndex("IDIteral");

                    b.HasIndex("IDasignatura");

                    b.ToTable("calificaciones");
                });

            modelBuilder.Entity("ColegioWeb.Core.Estudiantes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

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

                    b.Property<int?>("EstudiantesID")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("EstudiantesID");

                    b.ToTable("estudiantes");
                });

            modelBuilder.Entity("ColegioWeb.Core.Iterales", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Decripcion")
                        .HasColumnType("int");

                    b.Property<int?>("IteralesID")
                        .HasColumnType("int");

                    b.Property<int>("Nombre")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IteralesID");

                    b.ToTable("iterales");
                });

            modelBuilder.Entity("ColegioWeb.Core.Asignatura", b =>
                {
                    b.HasOne("ColegioWeb.Core.Asignatura", null)
                        .WithMany("asignaturas")
                        .HasForeignKey("AsignaturaID");
                });

            modelBuilder.Entity("ColegioWeb.Core.Asistencia", b =>
                {
                    b.HasOne("ColegioWeb.Core.Estudiantes", "estudiantesnav")
                        .WithMany()
                        .HasForeignKey("IDEstudiante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ColegioWeb.Core.Asignatura", "asignaturanav")
                        .WithMany()
                        .HasForeignKey("IDasignatura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("asignaturanav");

                    b.Navigation("estudiantesnav");
                });

            modelBuilder.Entity("ColegioWeb.Core.Calificaciones", b =>
                {
                    b.HasOne("ColegioWeb.Core.Estudiantes", "estudiantesnav")
                        .WithMany()
                        .HasForeignKey("IDEstudiante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ColegioWeb.Core.Iterales", "Iteralnav")
                        .WithMany()
                        .HasForeignKey("IDIteral")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ColegioWeb.Core.Asignatura", "asignaturanav")
                        .WithMany()
                        .HasForeignKey("IDasignatura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Iteralnav");

                    b.Navigation("asignaturanav");

                    b.Navigation("estudiantesnav");
                });

            modelBuilder.Entity("ColegioWeb.Core.Estudiantes", b =>
                {
                    b.HasOne("ColegioWeb.Core.Estudiantes", null)
                        .WithMany("estudiantes")
                        .HasForeignKey("EstudiantesID");
                });

            modelBuilder.Entity("ColegioWeb.Core.Iterales", b =>
                {
                    b.HasOne("ColegioWeb.Core.Iterales", null)
                        .WithMany("iterales")
                        .HasForeignKey("IteralesID");
                });

            modelBuilder.Entity("ColegioWeb.Core.Asignatura", b =>
                {
                    b.Navigation("asignaturas");
                });

            modelBuilder.Entity("ColegioWeb.Core.Estudiantes", b =>
                {
                    b.Navigation("estudiantes");
                });

            modelBuilder.Entity("ColegioWeb.Core.Iterales", b =>
                {
                    b.Navigation("iterales");
                });
#pragma warning restore 612, 618
        }
    }
}
