using Core.Commons.Pagination;
using Core.Commons.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Pagination
{
    public class PagedResponse<T> : IPagedResponse<T> where T: Entity
    {
        public async Task<Page<T>> GetPagedResponse(IQueryable<T> context, int page, int results)
        {
            page = page < 0 ? 0 : page;
            results = results <= 0 ? 5 : results;
            var collection = await context
                .Skip((page - 1) * results)
                .Take(results)
                .ToListAsync();
            var totalResults = await context.CountAsync();
            var totalPages = (int)Math.Ceiling((double)(totalResults / results));

            return new(page, results,
                collection, totalResults, totalPages);
        }
    }
}
