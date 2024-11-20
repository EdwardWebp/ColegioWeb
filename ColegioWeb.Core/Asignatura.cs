using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core
{
    public class Asignatura
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripción { get; set; }
        public List<Asignatura> asignaturas { get; set; } = new List<Asignatura>();

    }
}
