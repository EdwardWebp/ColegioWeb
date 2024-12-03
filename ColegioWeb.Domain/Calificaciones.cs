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
    public class Calificaciones : EntityBase
    {
        [Column(TypeName = "decimal(18, 0)")]
        public decimal nocalificacion { get; set; }
        public int IDEstudiante { get; set; }
        [ForeignKey("IDEstudiante")]
        public Estudiantes? estudiantesnav { get; set; }
        public int IDasignatura { get; set; }
        [ForeignKey("IDasignatura")]
        public Asignatura? asignaturanav { get; set; }
		public string Literal {
        get
            {
                if (nocalificacion >= 90) return "A";
                else if (nocalificacion >= 80) return "B";
                else if (nocalificacion >= 70) return "C";
                else 
                    return "F";
            }

        }
	}
}
