using Core.Commons.Pagination;
using Core.Commons.Persistance.Repositories;
using Core.Domain;
using Infrastructure.Commons.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class TrackRepository : GenericRepository<Track>, ITrackRepository
    {
        private readonly DataContext _context;
        private readonly IPagedResponse<Track> _response;

        public TrackRepository(DataContext context, IPagedResponse<Track> response) 
            : base(context)
        {
            _context = context;
            _response = response;
        }

        public async Task<Track> GetByTitleAsync(string title)
            => await _context.Tracks.FirstOrDefaultAsync(x => x.Title == title);

        public async Task<Track> GetByIdAsync(Guid id)
            => await _context.Tracks.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Page<Track>> GetAllAsync(Expression<Func<Track, bool>> expression, PagedQuery pagedQuery)
            => await _response.GetPagedResponse(
                _context.Tracks.Where(expression),
                pagedQuery.Page,
                pagedQuery.Results);

        public void Remove(Track track)
        {
            _context.Tracks.Remove(track);
        }
    }
}
