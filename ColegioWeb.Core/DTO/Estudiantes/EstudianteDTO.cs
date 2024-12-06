using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core.DTO.Estudiantes
{
	public class EstudianteDTO
	{
		public int ID { get; set; }
		[Required(ErrorMessage = "El Nombre del estudiante es obligatorio.")]
		public string Nombre { get; set; }
		[Required(ErrorMessage = "El Apellido del estudiante es obligatorio.")]
		public string Apellido { get; set; }
		[Required(ErrorMessage = "La Matricula es obligatoria.")]
		public string Matricula { get; set; }
		[Required(ErrorMessage = "Direccion es obligatoria.")]
		public string Direccion { get; set; }
		public string Descripción { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
		public DateTime FechaRegistro { get; set; }
	}
}
