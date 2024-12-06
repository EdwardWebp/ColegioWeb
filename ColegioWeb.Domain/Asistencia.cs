using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColegioWeb.Domain.Base_Entity;

namespace ColegioWeb.Domain
{
    public class Asistencia : EntityBase
	{
	
        public int IDEstudiante { get; set; }
        [ForeignKey("IDEstudiante")]
        public Estudiante? estudiantesnav { get; set; }
        public int IDasignatura { get; set; }
        [ForeignKey("IDasignatura")]
        public Asignatura? asignaturanav { get; set; }
        public int estado { get; set; }

        public string estadolirycs
		{
			get
			{
				if (estado == 1) return "Presente";
				else if (estado == 2) return "Ausente";
				else if (estado == 3) return "Excusa";
				else
					return "Desconocido";
			}
			  }
		
		public DateTime fecha { get; set; } 

	}
}
