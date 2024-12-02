using AutoMapper;
using ColegioWeb.Core.DTO.Asistencia;
using ColegioWeb.Core.Interfaz;
using ColegioWeb.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ColegioWeb.api.Controllers
{
	[Route("api/Asistencia")]
	[ApiController]
	public class AsistenciaController : Controller
	{
		private readonly IRepository<Asistencia> _repository;
		private readonly IMapper _mapper;
		private readonly ILogger<AsistenciaController> _logger;
		public AsistenciaController(IRepository<Asistencia> repository, IMapper mapper, ILogger<AsistenciaController> logger)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger;
		}

		[HttpGet("ObtenerAsistencia")]
		public async Task<ActionResult<IEnumerable<AsistenciaDTO>>> GetAllAsistencia()
		{
			// Obtener todas las Asistencia que no están eliminadas, incluyendo las relaciones necesarias
			var asistencia = await _repository.GetAllAsync(
				a => !a.Eliminado && a.estudiantesnav != null && !a.estudiantesnav.Eliminado &&
					 a.asignaturanav != null && !a.asignaturanav.Eliminado,
				a => a.estudiantesnav,  // Incluir la relación de 'estudiantesnav'
				a => a.asignaturanav   // Incluir la relación de 'asignaturanav'
			);

			// Mapear las Asistencia a DTO
			var asistenciaDto = _mapper.Map<IEnumerable<AsistenciaDTO>>(asistencia);

			// Retornar los DTOs
			return Ok(asistenciaDto);
		}

		[HttpGet("ObtenerAsistenciaPorID/{id}")]
		public async Task<ActionResult<AsistenciaDTO>> GetAsistenciaById(int id)
		{
			// Obtener la Asistencia por ID, incluyendo las relaciones necesarias
			var asistencia = await _repository.GetByIdAsync(id,
				a => a.estudiantesnav, // Incluir 'estudiantesnav'
				a => a.asignaturanav   // Incluir 'asignaturanav'
			);

			// Verificar si no se encontró la Asistencia
			if (asistencia == null)
			{
				return NotFound();
			}

			// Mapear la entidad 'Asistencia' a DTO
			var AsistenciaDto = _mapper.Map<AsistenciaDTO>(asistencia);

			// Retornar el DTO mapeado
			return Ok(AsistenciaDto);
		}

		[HttpPost("CrearAsistencia")]
		public async Task<ActionResult<AsistenciaDTO>> CreateAsistencia([FromBody] CAsistenciaDTO asistenciaDTO)
		{
			var asistencia = _mapper.Map<Asistencia>(asistenciaDTO);
			await _repository.AddAsync(asistencia);
			var AsitenciaDTOs = _mapper.Map<AsistenciaDTO>(asistencia);
			return CreatedAtAction(nameof(GetAsistenciaById), new { id = AsitenciaDTOs.ID }, AsitenciaDTOs);
		}

		[HttpPut("EditarAsistencia/{id}")]
		public async Task<IActionResult> UpdateAsistencia(int id, [FromBody] CAsistenciaDTO AsistenciaDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Asistenciaex = await _repository.GetByIdAsync(id);

			if (Asistenciaex == null)
			{
				return NotFound();
			}

			_mapper.Map(AsistenciaDTO, Asistenciaex);
			await _repository.UpdateAsync(Asistenciaex);

			var AsistenciaDTOs = _mapper.Map<AsistenciaResponDTO>(Asistenciaex);
			return Ok(AsistenciaDTOs);
		}

		[HttpDelete("EliminarAsistencia/{id}")]
		public async Task<ActionResult<bool>> DeleteAsistencia(int id)
		{
			var Asistencia = await _repository.GetByIdAsync(id);

			if (Asistencia == null)
			{
				return NotFound();
			}

			await _repository.DeleteByIdAsync(id);
			return Ok(Asistencia);
		}
	}
}
