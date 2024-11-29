using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core.DTO.Calificaciones
{
	public class CalificacionesDTO
	{
		public int ID { get; set; }
		public decimal nocalificacion { get; set; }
		public int IDEstudiante { get; set; }
		
		public string NombreEstudiante { get; set; }
		public int IDasignatura { get; set; }
		public string NombreAsignatura { get; set; }
		public string? Literal { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
		public DateTime FechaRegistro { get; set; }
	}
}
