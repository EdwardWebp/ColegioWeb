using ColegioWeb.Core.DTO.Asignatura;
using System.Net.Http.Json;
using System.Text.Json;

namespace ColegioWeb.UI.FrontEnd.Services
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
			catch (Exception ex)
			{
				// Maneja el error o registra detalles
				Console.WriteLine($"Error al obtener las asignaturas: {ex.Message}");
				return Enumerable.Empty<AsignaturaDTO>(); // Retorna una lista vacía en caso de error
			}
		}

		public async Task<AsignaturaDTO> GetAsignaturaById(int id)
		{
			return await _httpClient.GetFromJsonAsync<AsignaturaDTO>($"api/Asignatura/ObtenerAsignaturaID/{id}");
		}
		public async Task<bool> CreateAsignatura(AsignaturaDTO asignatura)
		{
			try
			{
				var response = await _httpClient.PostAsJsonAsync("api/Asignatura/CrearAsignatura", asignatura);
				if (response.IsSuccessStatusCode)
				{
					return true; // Operación exitosa
				}
				else
				{
					var errorContent = await response.Content.ReadAsStringAsync();
					Console.WriteLine($"Error al crear asignatura: {response.StatusCode} - {errorContent}");
					return false; // Operación fallida
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Excepción al crear asignatura: {ex.Message}");
				return false;
			}
		}

		public async Task UpdateAsignaturaAsync(int id, AsignaturaDTO asignatura)
		{
			await _httpClient.PutAsJsonAsync($"api/Asignatura/{id}", asignatura);

		}
		public async Task DeleteAsignatura(int id)
		{
			await _httpClient.DeleteAsync($"api/Asignatura/EliminarAsignatura/{id}");
		}
	}
}
