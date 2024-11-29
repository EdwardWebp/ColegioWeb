using ColegioWeb.Domain;
using ColegioWeb.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Infrastructure.Repositories
{
	public class RepositoryAsignatura : RepositoryBase <Asignatura>
	{
		private readonly ApplicationDbContext _context;

		public RepositoryAsignatura  (ApplicationDbContext context) : base (context)
		{
			_context = context;
		}
	}
}
