using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core.DTO.Asignatura
{
	public class AsignaturaDTO
	{

		public int ID { get; set; }
		[Required(ErrorMessage = "El Nombre es obligatorio.")]
		public string Nombre { get; set; }
		[Required(ErrorMessage = "La descripción es obligatoria.")]
		public string Descripción { get; set; }

		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
		public DateTime FechaRegistro { get; set; }
	}
}
