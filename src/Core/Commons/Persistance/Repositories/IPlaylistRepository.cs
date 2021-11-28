using Core.Commons.Pagination;
using Core.Commons.Types;
using Core.Domain;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Commons.Persistance.Repositories
{
    public interface IPlaylistRepository : IRepository, IGenericRepository<Playlist>
    {
        Task<Playlist> GetByIdAsync(Guid id);
        Task<Page<Playlist>> GetAllAsync(Expression<Func<Playlist, bool>> expression, PagedQuery pagedQuery);
        void Remove(Playlist playlist);
    }
}
