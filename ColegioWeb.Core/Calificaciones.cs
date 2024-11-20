using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core
{
    public class Calificaciones
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal nocalificacion { get; set; }
        public int IDEstudiante { get; set; }
        [ForeignKey("IDEstudiante")]
        public Estudiantes? estudiantesnav { get; set; }
        public int IDasignatura { get; set; }
        [ForeignKey("IDasignatura")]
        public Asignatura? asignaturanav { get; set; }
        public int IDIteral { get; set; }
        [ForeignKey("IDIteral")]
        public Iterales Iteralnav { get; set; }
    }
}
