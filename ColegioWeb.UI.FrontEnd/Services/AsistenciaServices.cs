using ColegioWeb.Core.DTO.Asistencia;
using System.Net.Http.Json;

namespace ColegioWeb.UI.FrontEnd.Services
{
	public class AsistenciaServices
	{
		private readonly HttpClient _httpClient;
		public AsistenciaServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<AsistenciaDTO>> GetAllAsistencia()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<AsistenciaDTO>>("api/Asistencia/ObtenerAsistencia");
		}
		public async Task<AsistenciaDTO> GetAsistenciaById(int id)
		{
			return await _httpClient.GetFromJsonAsync<AsistenciaDTO>($"api/Asistencia/ObtenerAsistenciaPorID/{id}");
		}
		public async Task CreateAsistencia(AsistenciaDTO asistencia)
		{
			await _httpClient.PostAsJsonAsync("api/Asistencia/CrearAsistencia", asistencia);
		}
		public async Task UpdateAsistenciaAsync(int id, AsistenciaDTO asistencia)
		{
			await _httpClient.PutAsJsonAsync($"api/Asistencia/{id}", asistencia);

		}
		public async Task DeleteAsistencia(int id)
		{
			await _httpClient.DeleteAsync($"api/Asistencia/EliminarAsistencia/{id}");
		}
	}
}
