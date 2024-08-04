using BaseCRUDForAPI.Core.Interfaces.ServicesInterfaces.Base;
using BaseCRUDForAPI.Core.Models.Entities;
using BaseCRUDForAPI.Core.Models.Reponse;
using BaseCRUDForAPI.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace BaseCRUDForAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase<UserEntity, 
                                                    AddUserRequest, 
                                                    UserReponse, 
                                                    UserSearchRequest>
    {
        public UserController(IBaseService<UserEntity, 
                                           AddUserRequest, 
                                           UserReponse, 
                                           UserSearchRequest> baseService) : base(baseService)
        {
        }
    }
}
