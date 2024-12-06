using ColegioWeb.Core.DTO.Asignatura;
using ColegioWeb.Core.DTO.Estudiantes;
using System.Net.Http;
using System.Net.Http.Json;

namespace ColegioWeb.UI.FrontEnd.Services
{
	public class EstudiantesServices
	{
		private readonly HttpClient _httpClient;
		public EstudiantesServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<EstudianteDTO>> GetAllEstudianteAsync()
		{
			try
			{
				return await _httpClient.GetFromJsonAsync<IEnumerable<EstudianteDTO>>("api/Estudiante/ObtenerEstudiante");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al obtener los estudiantes: {ex.Message}");
				return Enumerable.Empty<EstudianteDTO>(); // Retorna una lista vacía en caso de error
			}
		}
		public async Task<EstudianteDTO> GetEstudianteById(int id)
		{
			return await _httpClient.GetFromJsonAsync<EstudianteDTO>($"api/Estudiante/ObtenerEstudianteID/{id}");
		}
		public async Task CreateEstudiante(EstudianteDTO estudiante)
		{
			await _httpClient.PostAsJsonAsync("api/Estudiante/CrearEstudiante", estudiante);
		}
		public async Task UpdateEstudianteAsync(int id, EstudianteDTO estudiante)
		{
			await _httpClient.PutAsJsonAsync($"api/Estudiante/{id}", estudiante);

		}
		public async Task DeleteEstudiante(int id)
		{
			await _httpClient.DeleteAsync($"api/Estudiante/EliminarEstudiante/{id}");
		}
	}
}
