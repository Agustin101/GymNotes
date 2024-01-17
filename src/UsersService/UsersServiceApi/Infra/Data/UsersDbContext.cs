using Microsoft.EntityFrameworkCore;
using UsersServiceApi.Domain.Models;

namespace UsersServiceApi.Infra.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> opts) :base(opts)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
