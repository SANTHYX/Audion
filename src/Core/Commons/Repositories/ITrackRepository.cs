using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface ITrackRepository
    {
        Task AddAsync(Track track);
        Task RemoveAsync(Track track);
        Task<Track> GetAsync(string title);
        Task<IEnumerable<Track>> GetAllAsync();
    }
}
