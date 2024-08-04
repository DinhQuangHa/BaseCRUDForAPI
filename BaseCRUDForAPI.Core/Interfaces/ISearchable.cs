using BaseCRUDForAPI.Core.Models.Entities.Base;
using System.Linq.Expressions;

namespace BaseCRUDForAPI.Core.Interfaces
{
    public interface ISearchable<TEntity> where TEntity : BaseEntity
    {
        Expression<Func<TEntity, bool>> BuildQueriesSearch();

        Expression<Func<TEntity, BaseEntity>>[] Includes();
    }
}
