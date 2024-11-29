using AutoMapper;
using ColegioWeb.Core.DTO.Asignatura;
using ColegioWeb.Core.Interfaz;
using ColegioWeb.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ColegioWeb.api.Controllers
{
	[Route("api/Asignatura")]
	[ApiController]
	public class AsignaturaController : ControllerBase
	{
		private readonly IRepository<Asignatura> _repository;
		private readonly IMapper _mapper;
		private readonly ILogger<AsignaturaController> _logger;
		public AsignaturaController(IRepository<Asignatura> repository, IMapper mapper, ILogger<AsignaturaController> logger)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger;
		}

		[HttpGet("ObtenerAsignatura")]
		public async Task<ActionResult<IEnumerable<AsignaturaDTO>>> GetAllAsignatura()
		{
			var asignaturas = await _repository.GetAllAsync();
			var asignaturasdto = _mapper.Map<IEnumerable<AsignaturaDTO>>(asignaturas);
			return Ok(asignaturasdto);
		}

		[HttpGet("ObtenerAsignaturaID/{id}")]
		public async Task<ActionResult<AsignaturaDTO>> GetAsignaturanById(int id)
		{
			var asignatura = await _repository.GetByIdAsync(id);

			if (asignatura == null)
			{
				return NotFound();
			}

			var asignaturaDTO = _mapper.Map<AsignaturaDTO>(asignatura);
			return Ok(asignaturaDTO);
		}

		[HttpPost("CrearAsignatura")]
		public async Task<ActionResult<AsignaturaDTO>> CreateAsignatura([FromBody] CAsignaturaDTO asignaturaDTO)
		{
			var asignatura = _mapper.Map<Asignatura>(asignaturaDTO);
			await _repository.AddAsync(asignatura);
			var asignaturaDTOs = _mapper.Map<AsignaturaDTO>(asignatura);
			return CreatedAtAction(nameof(GetAsignaturanById), new { id = asignaturaDTOs.ID }, asignaturaDTOs);
		}

		[HttpPut("EditarAsignatura/{id}")]
		public async Task<IActionResult> UpdateAsignatura(int id, [FromBody] CAsignaturaDTO asignaturaDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var asignaturaex = await _repository.GetByIdAsync(id);

			if (asignaturaex == null)
			{
				return NotFound();
			}

			_mapper.Map(asignaturaDTO, asignaturaex);
			await _repository.UpdateAsync(asignaturaex);

			var asignaturaDTOs = _mapper.Map<AsignaturaDTO>(asignaturaex);
			return Ok(asignaturaDTOs);
		}

		[HttpDelete("EliminarAsignatura/{id}")]
		public async Task<ActionResult<bool>> DeleteAsignatura(int id)
		{
			var asignatura = await _repository.GetByIdAsync(id);

			if (asignatura == null)
			{
				return NotFound();
			}

			await _repository.DeleteByIdAsync(id);
			return Ok(asignatura);
		}
	}
}
