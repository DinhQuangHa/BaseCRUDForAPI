using BaseCRUDForAPI.Core.Interfaces;
using BaseCRUDForAPI.Core.Interfaces.ServicesInterfaces.Base;
using BaseCRUDForAPI.Core.Models.Entities.Base;
using BaseCRUDForAPI.Core.Models.Reponse.Base;
using BaseCRUDForAPI.Core.Models.Request.Base;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BaseCRUDForAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public abstract class ApiControllerBase<TEntity, TRequest, TReponse, TSearch> : ControllerBase
        where TEntity : BaseEntity
        where TRequest : BaseRequest
        where TReponse : BaseReponse
        where TSearch : BaseSearch, ISearchable<TEntity>
    {
        protected readonly IBaseService<TEntity, TRequest, TReponse, TSearch> _baseService;

        public ApiControllerBase(IBaseService<TEntity, TRequest, TReponse, TSearch> baseService)
        {
            _baseService=baseService;
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TReponse>> GetById(int id)
        {
            var reponse = await _baseService.GetAsync(id);
            return Ok(reponse);
        }
        
        [HttpGet]
        public virtual async Task<ActionResult<TReponse>> GetAll()
        {
            var reponse = await _baseService.GetAllAsync();
            return Ok(reponse);
        }

        [HttpGet("search")]
        public virtual async Task<ActionResult<TReponse>> Search([FromQuery] TSearch search)
        {
            var reponse = await _baseService.SearchAsync(search);
            return Ok(reponse);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Add(TRequest request)
        {
            await _baseService.AddAsync(request);
            return NoContent();
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] TRequest request)
        {
            await _baseService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _baseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
