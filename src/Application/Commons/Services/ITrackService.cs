using Application.Dto.Track;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface ITrackService
    {
        Task UploadAsync();
        Task<GetTrackDto> GetAsync();
        Task<IEnumerable<GetTracksDto>> BrowseAsync();
    }
}
