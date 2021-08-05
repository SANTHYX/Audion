using Application.Commons.Mappers;
using Application.Dto.Playlist;
using Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    public class PlaylistMapper : IPlaylistMapper
    {
        public GetPlaylistDto MapTo(Playlist source)
            => source is null ? null : new()
            {

            };

        public IEnumerable<GetPlaylistsDto> MapTo(IEnumerable<Playlist> source)
            =>source.Select(x => new GetPlaylistsDto
            {

            });
    }
}
