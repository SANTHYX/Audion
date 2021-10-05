using Core.Commons.Pagination;
using Core.Commons.Persistance;
using Core.Domain;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IPlaylistRepository : IGenericRepository<Playlist>
    {
        void Remove(Playlist playlist);
        Task<Playlist> GetAsync(Guid id);
        Task<Page<Playlist>> GetAllAsync
            (Expression<Func<Playlist, bool>> expression, PagedQuery pagedQuery);
    }
}
