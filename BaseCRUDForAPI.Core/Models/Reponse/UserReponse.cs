using BaseCRUDForAPI.Core.Models.Reponse.Base;

namespace BaseCRUDForAPI.Core.Models.Reponse
{
    public class UserReponse : BaseReponse
    {
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public RoleReponse RoleEntity { get; set; } = new();
    }
}
