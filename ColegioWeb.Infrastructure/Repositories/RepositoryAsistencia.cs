using ColegioWeb.Domain;
using ColegioWeb.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Infrastructure.Repositories
{
	public class RepositoryAsistencia: RepositoryBase <Asistencia>
	{
		private readonly ApplicationDbContext _context;
		public RepositoryAsistencia (ApplicationDbContext context): base (context)
		{
			_context = context;
		}
	}
}
