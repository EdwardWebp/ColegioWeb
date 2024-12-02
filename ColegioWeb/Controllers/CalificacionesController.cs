using AutoMapper;
using ColegioWeb.Core.DTO.Calificaciones;
using ColegioWeb.Core.Interfaz;
using ColegioWeb.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ColegioWeb.api.Controllers
{
	[Route("api/Calificaciones")]
	[ApiController]
	public class CalificacionesController : ControllerBase
	{
		private readonly IRepository<Calificaciones> _repository;
		private readonly IMapper _mapper;
		private readonly ILogger<CalificacionesController> _logger;
		public CalificacionesController(IRepository<Calificaciones> repository, IMapper mapper, ILogger<CalificacionesController> logger)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger;
		}

		[HttpGet("ObtenerCalificaciones")]
		public async Task<ActionResult<IEnumerable<CalificacionesDTO>>> GetAllCalificaciones()
		{
			// Obtener todas las calificaciones que no están eliminadas, incluyendo las relaciones necesarias
			var calificaciones = await _repository.GetAllAsync(
				a => !a.Eliminado && a.estudiantesnav != null && !a.estudiantesnav.Eliminado &&
					 a.asignaturanav != null && !a.asignaturanav.Eliminado,
				a => a.estudiantesnav,  // Incluir la relación de 'estudiantesnav'
				a => a.asignaturanav   // Incluir la relación de 'asignaturanav'
			);

			// Mapear las calificaciones a DTO
			var calificacionesDtos = _mapper.Map<IEnumerable<CalificacionesDTO>>(calificaciones);

			// Retornar los DTOs
			return Ok(calificacionesDtos);
		}

		[HttpGet("ObtenerCalificacionesPorID/{id}")]
		public async Task<ActionResult<CalificacionesDTO>> GetCalificacionesById(int id)
		{
			// Obtener la calificación por ID, incluyendo las relaciones necesarias
			var calificacion = await _repository.GetByIdAsync(id,
				a => a.estudiantesnav, // Incluir 'estudiantesnav'
				a => a.asignaturanav   // Incluir 'asignaturanav'
			);

			// Verificar si no se encontró la calificación
			if (calificacion == null)
			{
				return NotFound();
			}

			// Mapear la entidad 'Calificaciones' a DTO
			var calificacionesDto = _mapper.Map<CalificacionesDTO>(calificacion);

			// Retornar el DTO mapeado
			return Ok(calificacionesDto);
		}

		[HttpPost("CrearCalificaciones")]
		public async Task<ActionResult<CalificacionesDTO>> CreateCalificaciones([FromBody] CCalificacionesDTO calificacionesDTO)
		{
			var calificaciones = _mapper.Map<Calificaciones>(calificacionesDTO);
			await _repository.AddAsync(calificaciones);
			var calificacionesDTOs = _mapper.Map<CalificacionesDTO>(calificaciones);
			return CreatedAtAction(nameof(GetCalificacionesById), new { id = calificacionesDTOs.ID }, calificacionesDTOs);
		}

		[HttpPut("EditarCalificaciones/{id}")]
		public async Task<IActionResult> UpdateCalificaciones(int id, [FromBody] CCalificacionesDTO calificacionesDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var calificacionesex = await _repository.GetByIdAsync(id);

			if (calificacionesex == null)
			{
				return NotFound();
			}

			_mapper.Map(calificacionesDTO, calificacionesex);
			await _repository.UpdateAsync(calificacionesex);

			var calificacionesDTOs = _mapper.Map<CalificacionesResponDTO>(calificacionesex);
			return Ok(calificacionesDTOs);
		}

		[HttpDelete("EliminarCalificaciones/{id}")]
		public async Task<ActionResult<bool>> DeleteCalificaciones(int id)
		{
			var calificaciones = await _repository.GetByIdAsync(id);

			if (calificaciones == null)
			{
				return NotFound();
			}

			await _repository.DeleteByIdAsync(id);
			return Ok(calificaciones);
		}
	}
}
