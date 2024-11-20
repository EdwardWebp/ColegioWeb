using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core
{
    public class Iterales
    {
        [Key]
        public int ID { get; set; }
        [StringLength(10)]
        public int Nombre { get; set; }
        public int Decripcion { get; set; }

        public List<Iterales> iterales { get; set; } = new List<Iterales>();
    }
}
