using Application.Dto.Playlist;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IPlaylistService
    {
        Task CreateAsync(CreatePlaylistDto model);
        Task UpdateAsync(UpdatePlaylistDto model);
        Task RemoveAsync(Guid id);
        Task<IEnumerable<GetPlaylistsDto>> BrowseAsync();
        Task<GetPlaylistDto> GetAsync(Guid id);
    }
}
