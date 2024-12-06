using ColegioWeb.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        { 
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Asignatura> asignaturas { get; set; }
        public DbSet<Asistencia> asistencias { get; set; }
        public DbSet<Calificaciones> calificaciones { get; set; }
        public DbSet<Estudiante> estudiantes { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configuración para Asignatura
			modelBuilder.Entity<Asignatura>(tb =>
			{
				tb.HasKey(col => col.Id);
				tb.Property(col => col.Nombre)
				  .IsRequired()
				  .HasMaxLength(50);
				tb.Property(col => col.Descripción)
				  .HasMaxLength(100);
				tb.ToTable("Asignaturas");
			});

			// Configuración para Estudiantes
			modelBuilder.Entity<Estudiante>(tb =>
			{
				tb.HasKey(col => col.Id);
				tb.Property(col => col.Nombre)
				  .IsRequired()
				  .HasMaxLength(50);
				tb.Property(col => col.Apellido)
				  .HasMaxLength(50);
				tb.Property(col => col.Matricula)
				  .IsRequired()
				  .HasMaxLength(50);
				tb.Property(col => col.Direccion)
				  .HasMaxLength(100);
				tb.Property(col => col.Descripción)
				  .HasMaxLength(250);
				tb.ToTable("Estudiantes");
			});

			// Configuración para Asistencia
			modelBuilder.Entity<Asistencia>(tb =>
			{
				tb.HasKey(col => col.Id);
				tb.Property(col => col.estado)
				  .IsRequired();
				tb.Property(col => col.fecha)
				  .IsRequired();
				tb.HasOne(col => col.estudiantesnav)
				  .WithMany()
				  .HasForeignKey(col => col.IDEstudiante)
				  .OnDelete(DeleteBehavior.Cascade);
				tb.HasOne(col => col.asignaturanav)
				  .WithMany()
				  .HasForeignKey(col => col.IDasignatura)
				  .OnDelete(DeleteBehavior.Cascade);
				tb.ToTable("Asistencias");
			});

			// Configuración para Calificaciones
			modelBuilder.Entity<Calificaciones>(tb =>
			{
				tb.HasKey(col => col.Id);
				tb.Property(col => col.nocalificacion)
				  .HasColumnType("decimal(18, 0)")
				  .IsRequired();
				tb.HasOne(col => col.estudiantesnav)
				  .WithMany()
				  .HasForeignKey(col => col.IDEstudiante)
				  .OnDelete(DeleteBehavior.Cascade);
				tb.HasOne(col => col.asignaturanav)
				  .WithMany()
				  .HasForeignKey(col => col.IDasignatura)
				  .OnDelete(DeleteBehavior.Cascade);
				tb.ToTable("Calificaciones");
			});
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=DESKTOP-FSUML67\\SQLEXPRESS;Database=ColegiWebDB;integrated security=true; TrustServerCertificate=True");

    }
}
