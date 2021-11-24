using Application.Commons.Types;
using Application.Dto;
using Application.Dto.Playlist;
using Core.Commons.Pagination;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface IPlaylistMapper : IMapper<GetPlaylistDto, Playlist>,
        IMapper<PagedResponseDto<GetPlaylistsDto>, Page<Playlist>>
    {
    }
}
 