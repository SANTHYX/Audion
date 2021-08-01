using Core.Commons.Repositories;
using Core.Domain;
using System;
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

        public Task AddAsync(Profile profile)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> GetAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}
