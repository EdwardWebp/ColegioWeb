using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core.DTO.Asistencia
{
	public class AsistenciaResponDTO
	{
		public int IDEstudiante { get; set; }
		public int IDasignatura { get; set; }
		public int estado { get; set; }
		public DateTime fecha { get; set; }
	}
}
