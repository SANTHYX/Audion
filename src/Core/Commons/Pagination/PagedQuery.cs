namespace Core.Commons.Pagination
{
    public record PagedQuery
    {
        public int Page { get; set; }
        public int Results { get; set; }
    }
}
