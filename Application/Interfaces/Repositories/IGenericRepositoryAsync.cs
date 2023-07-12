using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Interfaces.Repositories
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync(
                                           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                           Expression<Func<T, bool>>? predicate = null,
                                           IList<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? includes = null);
        Task<IQueryable<T>> GetAllQueriableAsync(
                                           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
                                           Expression<Func<T, bool>>? predicate = null,
                                           IList<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? includes = null);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> GetCountAsync();
        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(long id);
        Task<T?> GetByIdAsync(long id, IList<Expression<Func<T, object>>> includes);

    }
}
