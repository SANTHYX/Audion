using Core.Domain;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface ITrackRepository
    {
        Task AddAsync(Track track);
        Task RemoveAsync(Track track);
        Task GetAsync(string name);
    }
}
