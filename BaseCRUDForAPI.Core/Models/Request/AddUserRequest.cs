using BaseCRUDForAPI.Core.Models.Request.Base;

namespace BaseCRUDForAPI.Core.Models.Request
{
    public class AddUserRequest : BaseRequest
    {
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public bool IsDeleted { get; set; }

        public AddRoleRequest RoleEntity { get; set; } = new();
    }
}
