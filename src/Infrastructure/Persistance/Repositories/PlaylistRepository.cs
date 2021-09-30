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
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly DataContext _context;
        private readonly IPagedResponse<Playlist> _response;

        public PlaylistRepository(DataContext context, IPagedResponse<Playlist> response)
        {
            _context = context;
            _response = response;
        }

        public async Task AddAsync(Playlist playlist)
        {
            await _context.Playlists.AddAsync(playlist);
            await _context.SaveChangesAsync();
        }

        public async Task<Page<Playlist>> GetAllAsync
            (Expression<Func<Playlist, bool>> expression, PagedQuery pagedQuery)
            => await _response.GetPagedResponse(
                _context.Playlists.Where(expression),
                pagedQuery.Page,
                pagedQuery.Results);

        public async Task<Playlist> GetAsync(Guid id)
            => await _context.Playlists.FirstOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(Playlist playlist)
        {
            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Playlist playlist)
        {
            _context.Update(playlist);
            await _context.SaveChangesAsync();
        }
    }
}
