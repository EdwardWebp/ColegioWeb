﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core.DTO
{
	public class EstudianteDTO
	{
		public int ID { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Matricula { get; set; }
		public string Direccion { get; set; }
		public string Descripción { get; set; }
	}
}
