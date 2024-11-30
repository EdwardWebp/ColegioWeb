using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core.DTO.Asistencia
{
	public class CAsistenciaDTO
	{
		public int ID { get; set; }
		public int IDEstudiante { get; set; }
		public int IDasignatura { get; set; }
		public bool unable { get; set; }
		public DateTime fecha { get; set; }
	}
}
