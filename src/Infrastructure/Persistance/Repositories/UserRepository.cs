using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetAsync(Guid id)
            => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string userName)
            => await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

        public async Task<bool> IsExist(string userName)
            => await _context.Users.AnyAsync(x => x.UserName == userName);

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
