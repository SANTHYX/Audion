using Application.Dto.Playlist;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface IPlaylistMapper : IBaseMapper<GetPlaylistDto, Playlist>
    {
    }
}
