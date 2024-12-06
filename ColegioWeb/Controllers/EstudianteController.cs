using AutoMapper;
using ColegioWeb.Core.DTO.Estudiantes;
using ColegioWeb.Core.Interfaz;
using ColegioWeb.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ColegioWeb.api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EstudianteController : ControllerBase
	{
		private readonly IRepository<Estudiante> _repository;
		private readonly IMapper _mapper;
		private readonly ILogger<EstudianteController> _logger;
		public EstudianteController(IRepository<Estudiante> repository, IMapper mapper, ILogger<EstudianteController> logger)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger;
		}

		[HttpGet]
		[Route("ObtenerEstudiante")]
		public async Task<ActionResult<IEnumerable<EstudianteDTO>>> GetAllEstudiante()
		{
			var estudiante = await _repository.GetAllAsync();
			var estudiantesdto = _mapper.Map<IEnumerable<EstudianteDTO>>(estudiante);
			return Ok(estudiantesdto);
		}

		[HttpGet]
		[Route("ObtenerEstudianteID/{id}")]
		public async Task<ActionResult<EstudianteDTO>> GetEstudianteById(int id)
		{
			var estudiante = await _repository.GetByIdAsync(id);

			if (estudiante == null)
			{
				return NotFound();
			}

			var estudianteDTO = _mapper.Map<EstudianteDTO>(estudiante);
			return Ok(estudianteDTO);
		}

		[HttpPost("CrearEstudiante")]
		public async Task<ActionResult<EstudianteDTO>> CreateEstudiante([FromBody] CEstudianteDTO estudianteDTO)
		{
			var estudiante = _mapper.Map<Estudiante>(estudianteDTO);
			await _repository.AddAsync(estudiante);
			var estudianteDTOs = _mapper.Map<EstudianteDTO>(estudiante);
			return CreatedAtAction(nameof(GetEstudianteById), new { id = estudianteDTOs.ID }, estudianteDTOs);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateEstudiante(int id, [FromBody] CEstudianteDTO estudianteDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var estudianteex = await _repository.GetByIdAsync(id);

			if (estudianteex == null)
			{
				return NotFound();
			}

			_mapper.Map(estudianteDTO, estudianteex);
			await _repository.UpdateAsync(estudianteex);

			var estudianteDTOs = _mapper.Map<EstudianteDTO>(estudianteex);
			return Ok(estudianteDTOs);
		}

		[HttpDelete("EliminarEstudiante/{id}")]
		public async Task<ActionResult<bool>> DeleteEstudiante(int id)
		{
			var estudiante = await _repository.GetByIdAsync(id);

			if (estudiante == null)
			{
				return NotFound();
			}

			await _repository.DeleteByIdAsync(id);
			return Ok(estudiante);
		}
	}
}
