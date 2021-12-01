using Core.Commons.Pagination;

namespace Application.Dto.Track
{
    public record BrowseTracksQueryDto : PagedQuery
    {
        public string Title { get; set; }
    }
}
