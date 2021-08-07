using Core.Commons.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Commons.Pagination
{
    public interface IPagedResponse<T> where T : Entity
    {
        int Page { get; set; }
        int Results { get; set; }
        IEnumerable<T> Collection { get; set; }
        int TotalResults { get; set; }
        int TotalPages { get; set; }
        Task<IPagedResponse<T>> GetPagedResponse(IQueryable<T> context, int page, int results);
    }
}
