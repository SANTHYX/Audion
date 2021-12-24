using Core.Commons.Persistance.Repositories;
using Core.Domain;
using Infrastructure.Commons.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(Guid id)
            => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetByUsernameAsync(string userName)
            => await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

        public async Task<User> GetByEmailAsync(string email)
            => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User> GetWithProfileByIdAsync(Guid id)
          => await _context.Users
              .Include(x => x.Profile)
              .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetWithProfileByUsernameAsync(string userName)
            => await _context.Users
                .Include(x => x.Profile)
                .FirstOrDefaultAsync(x => x.UserName == userName);

        public async Task<User> GetAggregateAsync(string userName)
            => await _context.Users
                .AsNoTracking()
                .Include(x => x.Profile)
                .Include(x => x.Playlists)
                .Include(x => x.Tracks)
                .FirstOrDefaultAsync(x => x.UserName == userName);

        public async Task<bool> IsExist(string userName)
            => await _context.Users.AnyAsync(x => x.UserName == userName);
    }
}
