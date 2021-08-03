using Core.Commons.Repositories;
using Core.Domain;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly DataContext _context;

        public TrackRepository(DataContext context)
        {
            _context = context;
        }

        public Task AddAsync(Track track)
        {
            throw new System.NotImplementedException();
        }

        public Task GetAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(Track track)
        {
            throw new System.NotImplementedException();
        }
    }
}
