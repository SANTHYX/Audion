using Application.Commons.Mappers;
using Application.Dto.Playlist;
using Core.Domain;

namespace Application.Mappers
{
    public class PlaylistMapper : IPlaylistMapper
    {
        public GetPlaylistDto MapTo(Playlist source)
            => source is null ? null : new()
            {

            };
    }
}
