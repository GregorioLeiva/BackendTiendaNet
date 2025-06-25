using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace ProyectoFinal_TiendaNet.Utils.Repository
{
	public interface IRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
		Task<T> GetOne(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
		Task Add(T entity);
		Task SaveChangesAsync();
		Task<T> Update(T entity);
		Task Delete(T entity);
		Task Save();
		Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate);
	}
	public class Repository<T> : IRepository<T> where T : class
	{
		public Task Add(T entity)
		{
			throw new NotImplementedException();
		}

		public Task Delete(T entity)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
		{
			throw new NotImplementedException();
		}

		public Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<T> GetOne(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
		{
			throw new NotImplementedException();
		}

		public Task Save()
		{
			throw new NotImplementedException();
		}

		public Task SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		public Task<T> Update(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
