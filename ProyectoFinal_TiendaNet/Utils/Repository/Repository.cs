using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using ProyectoFinal_TiendaNet.Config;

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
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			dbSet = _db.Set<T>();
		}
		public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
		{
			IQueryable<T> query = dbSet;

			if (filter != null)
				query = query.Where(filter);

			if (include != null)
				query = include(query);

			return await query.ToListAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _db.SaveChangesAsync();
		}

		public async Task<T> GetOne(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;

			if (filter != null)
				query = query.Where(filter);

			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}

			return await query.FirstOrDefaultAsync();
		}
		public async Task Add(T entity)
		{
			await dbSet.AddAsync(entity);
			await Save();
		}

		public async Task<T> Update(T entity)
		{
			dbSet.Update(entity);
			await Save();
			return entity;
		}

		public async Task Delete(T entity)
		{
			dbSet.Remove(entity);
			await Save();
		}

		public async Task Save()
		{
			await _db.SaveChangesAsync();
		}

		public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate)
		{
			return await dbSet.FirstOrDefaultAsync(predicate);
		}
	}
}
