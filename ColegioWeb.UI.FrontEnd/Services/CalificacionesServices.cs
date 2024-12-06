using ColegioWeb.Core.DTO.Calificaciones;
using ColegioWeb.Core.DTO.Calificaciones;
using System.Net.Http.Json;

namespace ColegioWeb.UI.FrontEnd.Services
{
	public class CalificacionesServices
	{
		private readonly HttpClient _httpClient;
		public CalificacionesServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<CalificacionesDTO>> GetAllCalificaciones()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<CalificacionesDTO>>("api/Calificaciones/ObtenerCalificaciones");
		}
		public async Task<CalificacionesDTO> GetCalificacionesById(int id)
		{
			return await _httpClient.GetFromJsonAsync<CalificacionesDTO>($"api/Calificaciones/ObtenerCalificacionesPorID/{id}");
		}
		public async Task CreateCalificaciones(CalificacionesDTO Calificaciones)
		{
			await _httpClient.PostAsJsonAsync("api/Calificaciones/CrearCalificaciones", Calificaciones);
		}
		public async Task UpdateCalificacionesAsync(int id, CalificacionesDTO Calificaciones)
		{
			await _httpClient.PutAsJsonAsync($"api/Calificaciones/{id}", Calificaciones);

		}
		public async Task DeleteCalificaciones(int id)
		{
			await _httpClient.DeleteAsync($"api/Calificaciones/EliminarCalificaciones/{id}");
		}
	}
}
