using BaseCRUDForAPI.Core.Interfaces.RepositoryInterfaces;
using BaseCRUDForAPI.Core.Models.Entities;
using BaseCRUDForAPI.Infrastructure.DbContext;
using BaseCRUDForAPI.Infrastructure.Repositories.Base;

namespace BaseCRUDForAPI.Infrastructure.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
