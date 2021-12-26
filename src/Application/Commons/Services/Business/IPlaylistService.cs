using Application.Commons.Types;
using Application.Dto;
using Application.Dto.Playlist.Requests;
using Application.Dto.Playlist.Responses;
using System;
using System.Threading.Tasks;

namespace Application.Commons.Services.Business
{
    public interface IPlaylistService : IService
    {
        Task<GetPlaylistDto> GetAsync(Guid id);
        Task<PagedResponseDto<GetPlaylistCollectionDto>> BrowseAsync(BrowsePlaylistQueryDto query);
        Task<PagedResponseDto<GetPlaylistCollectionDto>> BrowseForCurrentUserAsync(BrowseUserPlaylistsQueryDto query);
        Task CreateAsync(CreatePlaylistDto model);
        Task UpdateAsync(UpdatePlaylistDto model);
        Task RemoveAsync(RemovePlaylistDto model);
    }
}
