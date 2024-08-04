using BaseCRUDForAPI.Core.Interfaces;
using BaseCRUDForAPI.Core.Interfaces.RepositoryInterfaces.Base;
using BaseCRUDForAPI.Core.Interfaces.ServicesInterfaces.Base;
using BaseCRUDForAPI.Core.Models.Entities.Base;
using BaseCRUDForAPI.Core.Models.Reponse.Base;
using BaseCRUDForAPI.Core.Models.Request.Base;

namespace BaseCRUDForAPI.Infrastructure.Services.Base
{
    public class BaseService<TEntity, TRequest, TReponse, TSearch> : IBaseService<TEntity, TRequest, TReponse, TSearch> 
        where TEntity : BaseEntity, new()
        where TRequest : BaseRequest
        where TReponse : BaseReponse, new()
        where TSearch : BaseSearch, ISearchable<TEntity>
    {
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(TRequest request)
        {
            var entity = MapRequestToEntity(request);
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public async Task<TReponse> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            return MapEntityToReponse(entity);
        }

        public async Task UpdateAsync(int id, TRequest request)
        {
            var entity = MapRequestToEntity(request);
            await _repository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<TReponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(entity => MapEntityToReponse(entity));
        }

        public async Task<IEnumerable<TReponse>> SearchAsync(TSearch search)
        {
            //var entities = await _repository.SearchAsync(search.BuildQueriesSearch());
            var entities = await _repository.SearchAsync(search.BuildQueriesSearch(), search.Includes());
            return entities.Select(entity => MapEntityToReponse(entity));
        }

        private TEntity MapRequestToEntity(TRequest request)
        {
            var entity = new TEntity();
            MapProperties(request, entity);
            return entity;
        }

        private TReponse MapEntityToReponse(TEntity entity)
        {
            if (entity is null)
            {
                return default(TReponse);
            }

            var reponse = new TReponse();
            MapProperties(entity, reponse);
            return reponse;
        }

        private void MapProperties(object source, object destination)
        {
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties.FirstOrDefault(p => p.Name == sourceProperty.Name);
                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    var sourceValue = sourceProperty.GetValue(source);
                    if (sourceValue != null && IsComplexType(sourceProperty.PropertyType))
                    {
                        var destinationValue = Activator.CreateInstance(destinationProperty.PropertyType);
                        MapProperties(sourceValue, destinationValue);
                        destinationProperty.SetValue(destination, destinationValue);
                    }
                    else
                    {
                        destinationProperty.SetValue(destination, sourceValue);
                    }
                }
            }
        }

        private bool IsComplexType(Type type)
        {
            return type.IsClass && type != typeof(string);
        }

    }
}
