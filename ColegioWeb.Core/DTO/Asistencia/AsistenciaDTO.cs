using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core.DTO.Asistencia
{
	public class AsistenciaDTO
	{
		public int ID { get; set; }
		[Required(ErrorMessage = "El estudiante es obligatorio.")]
		public int IDEstudiante { get; set; }
		public string NombreEstudiante { get; set; }
		[Required(ErrorMessage = "La Asignatura es obligatoria.")]
		public int IDasignatura { get; set; }
		public string NombreAsignatura { get; set; }
		[Required(ErrorMessage = "El Estado es obligatorio.")]
		public int estado { get; set; }
        public string estadolirycs { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
		[Required(ErrorMessage = "La Fecha es obligatoria.")]
		public DateTime fecha { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
		public DateTime FechaRegistro { get; set; }
	}
}