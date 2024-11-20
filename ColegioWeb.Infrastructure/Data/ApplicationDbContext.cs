using ColegioWeb.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public DbSet<Estudiantes> estudiantes { get; set; }
        public DbSet<Iterales> iterales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=DESKTOP-FSUML67\\SQLEXPRESS;Database=ColegiWebDB;integrated security=true; TrustServerCertificate=True");

    }
}
