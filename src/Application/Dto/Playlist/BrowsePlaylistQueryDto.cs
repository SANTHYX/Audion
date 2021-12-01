using Core.Commons.Pagination;

namespace Application.Dto.Playlist
{
    public record BrowsePlaylistQueryDto : PagedQuery
    {
        public string Name { get; set; }
    }
}
