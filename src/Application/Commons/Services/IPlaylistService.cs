using Application.Dto;
using Application.Dto.Playlist;
using Core.Commons.Pagination;
using System;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IPlaylistService
    {
        Task CreateAsync(CreatePlaylistDto model);
        Task UpdateAsync(UpdatePlaylistDto model);
        Task RemoveAsync(Guid id);
        Task<PagedResponseDto<GetPlaylistsDto>> BrowseAsync(PagedQuery query);
        Task<GetPlaylistDto> GetAsync(Guid id);
    }
}
