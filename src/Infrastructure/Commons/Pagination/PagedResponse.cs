using Core.Commons.Pagination;
using Core.Commons.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Pagination
{
    public class PagedResponse<T> : IPagedResponse<T> where T: Entity
    {
        public async Task<Page<T>> GetPagedResponse(IQueryable<T> context, int page = 1, int results = 5)
        {
            page = page <= 0 ? 1 : page;
            results = results <= 0 ? 5 : results;

            var totalResults = await context.CountAsync();

            if (totalResults == 0)
            {
                return Empty();
            }

            var totalPages = (int)Math.Ceiling((double)(results / totalResults));

            var collection = await context
                .Skip((page - 1) * results)
                .Take(results)
                .ToListAsync();

            return new(page, results,
                collection, totalResults, totalPages);
        }

        private static Page<T> Empty()
            => new(1,0,new List<T>(), 0,1);
    }
}
