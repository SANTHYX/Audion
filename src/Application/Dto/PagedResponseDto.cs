using System.Collections.Generic;

namespace Application.Dto
{
    public record PagedResponseDto<T>
    {
        public IEnumerable<T> Collection { get; set; }
        public int Page { get; set; }
        public int Results { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
    }
}
