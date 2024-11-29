using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Domain.Base_Entity
{
	public abstract class EntityBase
	{
		protected EntityBase() {
			FechaRegistro = DateTime.Now;
			Eliminado = false;
		}
		public  int Id { get; set; }
		public DateTime FechaRegistro { get; set; }
		public bool Eliminado { get; set; }
	}
}
