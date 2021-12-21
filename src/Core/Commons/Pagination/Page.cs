using System.Collections.Generic;

namespace Core.Commons.Pagination
{
    public class Page<T>
    {
        public int CurrentPage { get; set; }
        public int Results { get; set; }
        public IEnumerable<T> Collection { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }

        public Page(int page, int results, IEnumerable<T> collection,
            int totalResults, int totalPages)
        {
            CurrentPage = page >= totalPages ? totalPages : page;
            Results = results;
            Collection = collection;
            TotalResults = totalResults;
            TotalPages = totalPages;
        }
    }
}
