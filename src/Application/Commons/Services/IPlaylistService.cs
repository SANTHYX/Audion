using Application.Dto.Playlist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IPlaylistService
    {
        Task CreateAsync();
        Task UpdateAsync();
        Task RemoveAsync();
        Task<IEnumerable<GetPlaylistsDto>> BrowseAsync();
        Task<GetPlaylistDto> GetAsync();
    }
}
