using ColegioWeb.Domain.Base_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Core.Interfaz
{
	public interface IRepository<T> where T : EntityBase
	{
		Task<T> GetByIdAsync(int id);
		Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
		Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task<bool?> DeleteByIdAsync(int id);
	}
}
