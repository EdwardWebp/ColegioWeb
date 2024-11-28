using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core.DTO
{
	public class CalificacionesDTO
	{
		public int ID { get; set; }
		public decimal nocalificacion { get; set; }
		public int IDEstudiante { get; set; }
		public int IDasignatura { get; set; }
		public string? Literal { get; set; }
	}
}
