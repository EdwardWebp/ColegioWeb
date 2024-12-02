using ColegioWeb.Core.DTO.Asignatura;
using System.Net.Http.Json;

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
			return await _httpClient.GetFromJsonAsync<IEnumerable<AsignaturaDTO>>("api/Articulos");
		}
		public async Task<AsignaturaDTO> GetArticulosById(int id)
		{
			return await _httpClient.GetFromJsonAsync<AsignaturaDTO>($"api/Articulos/{id}");
		}
		public async Task CreateArticulos(CAsignaturaDTO Asignatura)
		{
			await _httpClient.PostAsJsonAsync("api/Articulos", Asignatura);
		}
		public async Task UpdateArticulos(int id, CAsignaturaDTO articulo)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/Articulos/{id}", articulo);
			if (!response.IsSuccessStatusCode)
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				throw new Exception($"Error al actualizar la Articulo: {errorMessage}");
			}
		}
		public async Task DeleteArticulos(int id)
		{
			await _httpClient.DeleteAsync($"api/Articulos/{id}");
		}
	}
}
