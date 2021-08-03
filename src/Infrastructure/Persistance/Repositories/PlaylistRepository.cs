using Core.Commons.Repositories;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly DataContext _context;

        public PlaylistRepository(DataContext context)
        {
            _context = context;
        }

        public Task AddAsync(Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public Task<Playlist> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Playlist playlist)
        {
            throw new NotImplementedException();
        }
    }
}
