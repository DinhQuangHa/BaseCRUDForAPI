using BaseCRUDForAPI.Core.Models.Entities.Base;
using BaseCRUDForAPI.Core.Models.Reponse.Base;
using BaseCRUDForAPI.Core.Models.Request.Base;

namespace BaseCRUDForAPI.Core.Interfaces.ServicesInterfaces.Base
{
    public interface IBaseService<TEntity, TRequest, TReponse, TSearch> 
        where TEntity : BaseEntity
        where TRequest : BaseRequest
        where TReponse : BaseReponse
        where TSearch : BaseSearch, ISearchable<TEntity>
    {
        Task<TReponse> GetAsync(int id);

        Task AddAsync(TRequest request);

        Task UpdateAsync(int id, TRequest request);

        Task DeleteAsync(int id);

        Task<IEnumerable<TReponse>> GetAllAsync();

        Task<IEnumerable<TReponse>> SearchAsync (TSearch search);
    }
}
