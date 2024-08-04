using BaseCRUDForAPI.Core.Models.Entities.Base;

namespace BaseCRUDForAPI.Core.Models.Entities
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<UserEntity> Users { get; set; }
    }
}
