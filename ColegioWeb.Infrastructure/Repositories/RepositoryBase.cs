using ColegioWeb.Core.Interfaz;
using ColegioWeb.Domain.Base_Entity;
using ColegioWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Infrastructure.Repositories
{
	public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
	{
		private readonly ApplicationDbContext _context;
		private DbSet<T> _entity;
		protected RepositoryBase(ApplicationDbContext context)
		{
			_context = context;
			_entity = context.Set<T>();
		}
		public async Task AddAsync(T entity)
		{
			_context.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<bool?> DeleteByIdAsync(int id)
		{
			var entity = await _entity.FindAsync(id);

			entity.Eliminado = true;

			await _context.SaveChangesAsync();
			return true;
		}


		public async virtual Task<IEnumerable<T>> GetAllAsync()
		{
			return await _entity.Where(e => e.Eliminado == false).ToListAsync();
		}

		public async virtual Task<T> GetByIdAsync(int id)
		{
			return await _entity.Where(e => e.Id == id && e.Eliminado == false).FirstOrDefaultAsync();
		}
		public async virtual Task UpdateAsync(T entity)
		{
			var existingEntity = await _entity.Where(e => e.Id == entity.Id && e.Eliminado == false).FirstOrDefaultAsync();

			_context.Entry(existingEntity).CurrentValues.SetValues(entity);
			_context.Entry(existingEntity).Property(e => e.FechaRegistro).IsModified = false;

			await _context.SaveChangesAsync();
		}

		public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = _entity;

			foreach (var include in includes)
			{
				query = query.Include(include);
			}

			return await query.FirstOrDefaultAsync(e => e.Id == id && e.Eliminado == false);
		}

		public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = _entity;

			foreach (var include in includes)
			{
				query = query.Include(include);
			}

			return await query.ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = _entity;

			query = query.Where(e => !e.Eliminado);

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			// Incluir las propiedades de navegación especificadas
			foreach (var include in includes)
			{
				query = query.Include(include);
			}

			return await query.ToListAsync();
		}
	}
}
