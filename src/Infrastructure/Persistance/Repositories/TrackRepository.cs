using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly DataContext _context;

        public TrackRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Track track)
        {
            await _context.Tracks.AddAsync(track);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Track>> GetAllAsync()
            => await _context.Tracks.ToListAsync();

        public async Task<Track> GetAsync(string title)
            => await _context.Tracks.FirstOrDefaultAsync(x => x.Title == title);

        public async Task RemoveAsync(Track track)
        {
            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
        }
    }
}
