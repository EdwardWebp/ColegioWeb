using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core.DTO.Calificaciones
{
	public class CalificacionesResponDTO
	{
		public int ID { get; set; }
		public decimal nocalificacion { get; set; }
		public int IDEstudiante { get; set; }
		public int IDasignatura { get; set; }
	}
}
