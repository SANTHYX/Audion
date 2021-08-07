using Core.Commons.Pagination;
using Core.Domain;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IPlaylistRepository
    {
        Task AddAsync(Playlist playlist);
        Task UpdateAsync(Playlist playlist);
        Task RemoveAsync(Playlist playlist);
        Task<Playlist> GetAsync(Guid id);
        Task<IPagedResponse<Playlist>> GetAllAsync
            (Expression<Func<Playlist, bool>> expression, PagedQuery pagedQuery);
    }
}
