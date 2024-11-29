using ColegioWeb.Domain.Base_Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Domain
{
    public class Estudiantes: EntityBase
	{
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellido { get; set; }
        [StringLength(50)]
        public string Matricula { get; set; }
        [StringLength(100)]
        public string Direccion { get; set; }
        public string Descripción { get; set; }

        public List<Estudiantes> estudiantes { get; set; } = new List<Estudiantes>();
    }
}
