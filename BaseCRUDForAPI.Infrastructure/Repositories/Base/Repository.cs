using BaseCRUDForAPI.Core.Interfaces.RepositoryInterfaces.Base;
using BaseCRUDForAPI.Core.Models.Entities.Base;
using BaseCRUDForAPI.Infrastructure.DbContext;
using MethodTimer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaseCRUDForAPI.Infrastructure.Repositories.Base
{
    [Time]
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, BaseEntity>>[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            
            query = query.Where(predicate);
            
            return await query.ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
