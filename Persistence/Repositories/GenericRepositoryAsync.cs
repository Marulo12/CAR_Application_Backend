using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly DbContext _dbContext;

        public GenericRepositoryAsync(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext
                  .Set<T>()
                  .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, Expression<Func<T, bool>>? predicate = null, IList<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? includes = null)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            query = PrepareQuery(query, predicate, includes, orderBy);
            return await query.ToListAsync();
        }

        public async Task<IQueryable<T>> GetAllQueriableAsync(Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, Expression<Func<T, bool>>? predicate = null, IList<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? includes = null)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            await Task.Run(() => { query = PrepareQuery(query, predicate, includes, orderBy); });
            return query;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(long id, IList<Expression<Func<T, object>>> includes)
        {
            var set = _dbContext.Set<T>().AsQueryable();
            set = includes.Aggregate(set, (current, includeProperty) => current.Include(includeProperty));
            return await set.FirstOrDefaultAsync(s => EF.Property<long>(s, "Id") == id);
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().CountAsync(predicate);
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> PrepareQuery(
            IQueryable<T> query,
            Expression<Func<T, bool>>? predicate = null,
            IList<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? includes = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? take = null
        )
        {
            if (includes?.Count > 0)
            {
                includes?.ToList().ForEach(i => query = i(query));
            }

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (take.HasValue)
                query = query.Take(Convert.ToInt32(take));

            return query;
        }
    }
}
