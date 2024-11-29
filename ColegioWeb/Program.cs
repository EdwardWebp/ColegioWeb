using ColegioWeb.Core.Interfaz;
using ColegioWeb.Domain;
using ColegioWeb.Infrastructure.Data;
using ColegioWeb.Infrastructure.Mappings;
using ColegioWeb.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});
// Add services to the container.
//
builder.Services.AddScoped<IRepository<Estudiantes>, RepositoryEstudiante>();
builder.Services.AddScoped<IRepository<Asignatura>, RepositoryAsignatura>();
builder.Services.AddScoped<IRepository<Asistencia>, RepositoryAsistencia>();
builder.Services.AddScoped<IRepository<Calificaciones>, RepositoryCalificaciones>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(builder =>
	{
		builder.WithOrigins("https://localhost:7224")
			   .AllowAnyHeader()
			   .AllowAnyMethod();
	});
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors();
app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
	endpoint.MapControllers();
});

app.MapControllers();

app.Run();
