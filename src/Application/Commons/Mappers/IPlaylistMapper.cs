using Application.Dto;
using Application.Dto.Playlist;
using Core.Commons.Pagination;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface IPlaylistMapper : IBaseMapper<GetPlaylistDto, Playlist>,
        IBaseMapper<PagedResponseDto<GetPlaylistsDto>, IPagedResponse<Playlist>>
    {
    }
}
 