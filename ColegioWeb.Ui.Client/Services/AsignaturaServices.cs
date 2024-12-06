using ColegioWeb.Core.DTO.Asignatura;
using System.Net.Http.Json;
using System.Text.Json;

namespace ColegioWeb.Ui.Client.Services
{
	public class AsignaturaServices
	{
		private readonly HttpClient _httpClient;
		public AsignaturaServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<AsignaturaDTO>> GetAllAsignaturas()
		{
			try
			{
				return await _httpClient.GetFromJsonAsync<IEnumerable<AsignaturaDTO>>("api/Asignatura/ObtenerAsignatura");
			}
			catch (HttpRequestException ex)
			{
				// Manejar excepciones de solicitud HTTP
				Console.WriteLine("Error en la solicitud HTTP: " + ex.Message);
				return Enumerable.Empty<AsignaturaDTO>(); // O devolver un valor predeterminado
			}
			catch (JsonException ex)
			{
				// Manejar excepciones de deserialización JSON
				Console.WriteLine("Error al deserializar JSON: " + ex.Message);
				return Enumerable.Empty<AsignaturaDTO>(); // O devolver un valor predeterminado
			}
		}
		public async Task<AsignaturaDTO> GetAsignaturaById(int id)
		{
			return await _httpClient.GetFromJsonAsync<AsignaturaDTO>($"api/Asignatura/ObtenerAsignaturaID/{id}");
		}
		public async Task CreateAsignatura(AsignaturaDTO Asignatura)
		{
			await _httpClient.PostAsJsonAsync("api/Asignatura/CrearAsignatura", Asignatura);
		}
		public async Task UpdateAsignaturaAsync(int id, AsignaturaDTO asignatura)
		{
			await _httpClient.PutAsJsonAsync($"api/Articulo/{id}", asignatura);

		}
		public async Task DeleteAsignatura(int id)
		{
			await _httpClient.DeleteAsync($"api/Asignatura/EliminarAsignatura/{id}");
		}
	}
}
