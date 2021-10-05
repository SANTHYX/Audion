using Core.Commons.Pagination;
using Core.Commons.Persistance;
using Core.Domain;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface ITrackRepository : IGenericRepository<Track>
    {
        void RemoveAsync(Track track);
        Task<Track> GetAsync(string title);
        Task<Page<Track>> GetAllAsync
            (Expression<Func<Track, bool>> expression, PagedQuery pagedQuery);
    }
}
