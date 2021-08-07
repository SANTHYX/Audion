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
        public int Page { get; set; }
        public int Results { get; set; }
        public IEnumerable<T> Collection { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }

        public PagedResponse(int page, int results, IEnumerable<T> collection, 
            int totalResults, int totalPages)
        {
            Page = page;
            Results = results;
            Collection = collection;
            TotalResults = totalResults;
            TotalPages = totalPages;
        }

        public async Task<IPagedResponse<T>> GetPagedResponse(IQueryable<T> context, int page, int results)
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
