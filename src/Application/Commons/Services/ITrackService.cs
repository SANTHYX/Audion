using Application.Dto.Track;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface ITrackService
    {
        Task UploadAsync(UploadTrackDto model);
        Task<GetTrackDto> GetAsync(string title);
        Task<IEnumerable<GetTracksDto>> BrowseAsync();
    }
}
