using Core.Commons.Pagination;

namespace Application.Dto.Playlist.Requests
{
    public record BrowsePlaylistQueryDto : PagedQuery
    {
        public string Name { get; set; }
    }
}
