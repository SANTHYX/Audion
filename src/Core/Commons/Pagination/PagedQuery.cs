namespace Core.Commons.Pagination
{
    public class PagedQuery
    {
        public string? Name { get; set; }
        public int Page { get; set; } = 1;
        public int Results { get; set; } = 5;
    }
}
