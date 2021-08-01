using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profile { get; set; }

        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) { }
    }
}
