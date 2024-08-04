using BaseCRUDForAPI.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseCRUDForAPI.Infrastructure.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> UserEntities { get; set; }

        public DbSet<RoleEntity> RoleEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
