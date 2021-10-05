using Core.Commons.Repositories;
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

        public async Task<User> GetAggregateAsync(string userName)
        => await _context.Users
                .AsNoTracking()
                .Include(x => x.Profile)
                .FirstOrDefaultAsync(x => x.UserName == userName);

        public async Task<User> GetAsync(Guid id)
            => await _context.Users
                .Include(x => x.Profile)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string userName)
            => await _context.Users
                .Include(x => x.Profile)
                .FirstOrDefaultAsync(x => x.UserName == userName);

        public async Task<bool> IsExist(string userName)
            => await _context.Users.AnyAsync(x => x.UserName == userName);
    }
}
