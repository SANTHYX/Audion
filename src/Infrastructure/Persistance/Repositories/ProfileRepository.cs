using Core.Commons.Repositories;
using Core.Domain;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DataContext _context;

        public ProfileRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Profile profile)
        {
            await _context.Profile.AddAsync(profile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Profile profile)
        {
            _context.Profile.Update(profile);
            await _context.SaveChangesAsync();
        }
    }
}
