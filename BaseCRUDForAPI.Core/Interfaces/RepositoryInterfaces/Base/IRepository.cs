using BaseCRUDForAPI.Core.Models.Entities.Base;
using System.Linq.Expressions;

namespace BaseCRUDForAPI.Core.Interfaces.RepositoryInterfaces.Base
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        Task<T> GetAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, BaseEntity>>[] includes);
    }
}
