using Core.Commons.Repositories;
using Core.Domain;
using Infrastructure.Commons.Persistance;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        private readonly DataContext _context;

        public ProfileRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
