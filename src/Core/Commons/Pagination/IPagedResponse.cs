using Core.Commons.Types;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Commons.Pagination
{
    public interface IPagedResponse<T> where T : Entity
    {
        Task<Page<T>> GetPagedResponse(IQueryable<T> context, int page, int results);
    }
}
