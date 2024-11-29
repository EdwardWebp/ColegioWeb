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
        public Estudiantes? estudiantesnav { get; set; }
        public int IDasignatura { get; set; }
        [ForeignKey("IDasignatura")]
        public Asignatura? asignaturanav { get; set; }
        public bool unable { get; set; }
        public DateTime fecha { get; set; }
    }
}
