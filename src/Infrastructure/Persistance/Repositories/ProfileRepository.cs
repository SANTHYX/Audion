using Core.Commons.Persistance.Repositories;
using Core.Domain;
using Infrastructure.Commons.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<Profile> GetByUserIdAsync(Guid userId)
            => await _context.Profile.FirstOrDefaultAsync(x => x.UserId == userId);
    }
}
