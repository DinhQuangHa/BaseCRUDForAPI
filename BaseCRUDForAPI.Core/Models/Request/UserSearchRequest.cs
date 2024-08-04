using BaseCRUDForAPI.Core.Interfaces;
using BaseCRUDForAPI.Core.Models.Entities;
using BaseCRUDForAPI.Core.Models.Entities.Base;
using BaseCRUDForAPI.Core.Models.Request.Base;
using System.Linq.Expressions;

namespace BaseCRUDForAPI.Core.Models.Request
{
    public class UserSearchRequest : BaseSearch, ISearchable<UserEntity>
    {
        public string Name { get; set; }

        public Expression<Func<UserEntity, bool>> BuildQueriesSearch()
        {
            return x => (string.IsNullOrEmpty(Name) || x.UserName.Contains(Name));
        }

        public Expression<Func<UserEntity, BaseEntity>>[] Includes()
        {
            return new Expression<Func<UserEntity, BaseEntity>>[]
            {
                p => p.RoleEntity
            };
        }
    }
}