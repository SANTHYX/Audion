using Application.Dto.Playlist;
using Core.Domain;
using System.Collections.Generic;

namespace Application.Commons.Mappers
{
    public interface IPlaylistMapper : IBaseMapper<GetPlaylistDto, Playlist>,
        IBaseMapper<IEnumerable<GetPlaylistsDto>, IEnumerable<Playlist>>
    {
    }
}
