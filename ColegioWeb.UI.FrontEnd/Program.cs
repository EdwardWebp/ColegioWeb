using CurrieTechnologies.Razor.SweetAlert2;
using ColegioWeb.UI.FrontEnd;
using ColegioWeb.UI.FrontEnd.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7137") });
builder.Services.AddScoped<AsignaturaServices>();
builder.Services.AddScoped<EstudiantesServices>();
builder.Services.AddScoped<AsistenciaServices>();
builder.Services.AddScoped<CalificacionesServices>();

builder.Services.AddSweetAlert2();
await builder.Build().RunAsync();
