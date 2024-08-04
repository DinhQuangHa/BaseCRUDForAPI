using BaseCRUDForAPI.Core.Models.Request.Base;

namespace BaseCRUDForAPI.Core.Models.Request
{
    public class AddRoleRequest : BaseRequest
    {
        public string Name { get; set; }
    }
}
