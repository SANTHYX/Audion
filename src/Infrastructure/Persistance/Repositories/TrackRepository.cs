using Core.Commons.Pagination;
using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly DataContext _context;
        private readonly IPagedResponse<Track> _response;

        public TrackRepository(DataContext context, IPagedResponse<Track> response)
        {
            _context = context;
            _response = response;
        }

        public async Task AddAsync(Track track)
        {
            await _context.Tracks.AddAsync(track);
            await _context.SaveChangesAsync();
        }

        public async Task<IPagedResponse<Track>> GetAllAsync
            (Expression<Func<Track, bool>> expression, PagedQuery pagedQuery)
            => await _response.GetPagedResponse(
                _context.Tracks.Where(expression),
                pagedQuery.Page,
                pagedQuery.Results);

        public async Task<Track> GetAsync(string title)
            => await _context.Tracks.FirstOrDefaultAsync(x => x.Title == title);

        public async Task RemoveAsync(Track track)
        {
            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
        }
    }
}
