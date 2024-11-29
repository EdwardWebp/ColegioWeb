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
		public int IDEstudiante { get; set; }
		public int IDasignatura { get; set; }
		public bool unable { get; set; }
		public DateTime fecha { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
		public DateTime FechaRegistro { get; set; }
	}
}
