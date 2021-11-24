using Core.Commons.Pagination;
using Core.Commons.Types;
using Core.Domain;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Commons.Persistance.Repositories
{
    public interface ITrackRepository : IRepository, IGenericRepository<Track>
    {
        Task<Track> GetAsync(Guid id);
        Task<Track> GetAsync(string title);
        Task<Page<Track>> GetAllAsync(Expression<Func<Track, bool>> expression, PagedQuery pagedQuery);
        void Remove(Track track);
    }
}
