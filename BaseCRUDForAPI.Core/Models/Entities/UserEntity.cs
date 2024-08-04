using BaseCRUDForAPI.Core.Models.Entities.Base;

namespace BaseCRUDForAPI.Core.Models.Entities
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public RoleEntity RoleEntity { get; set; } = new();
    }
}
