using Application.Commons.Types;
using Application.Dto;
using Application.Dto.Playlist;
using Core.Commons.Pagination;
using System;
using System.Threading.Tasks;

namespace Application.Commons.Services.Business
{
    public interface IPlaylistService : IService
    {
        Task<GetPlaylistDto> GetAsync(Guid id);
        Task<PagedResponseDto<GetPlaylistsDto>> BrowseAsync(PagedQuery query);
        Task CreateAsync(CreatePlaylistDto model);
        Task UpdateAsync(UpdatePlaylistDto model);
        Task RemoveAsync(RemovePlaylistDto model);
    }
}
