using Core.Commons.Identity;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistance
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assembly = typeof(DataContext).GetTypeInfo().Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
