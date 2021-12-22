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
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        private readonly DataContext _context;
        private readonly IPagedResponse<Playlist> _response;

        public PlaylistRepository(DataContext context, IPagedResponse<Playlist> response) 
            : base(context)
        {
            _context = context;
            _response = response;
        }

        public async Task<Playlist> GetByIdAsync(Guid id)
            => await _context.Playlists.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Page<Playlist>> GetAllAsync(Expression<Func<Playlist, bool>> expression, PagedQuery pagedQuery)
            => await _response.GetPagedResponse(
                _context.Playlists.AsNoTracking().Where(expression),
                pagedQuery.Page,
                pagedQuery.Results);

        public void Remove(Playlist playlist)
        {
            _context.Playlists.Remove(playlist);
        }
    }
}
