using Core.Commons.Pagination;
using Core.Domain;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface ITrackRepository
    {
        Task AddAsync(Track track);
        Task RemoveAsync(Track track);
        Task<Track> GetAsync(string title);
        Task<IPagedResponse<Track>> GetAllAsync
            (Expression<Func<Track, bool>> expression, PagedQuery pagedQuery);
    }
}
