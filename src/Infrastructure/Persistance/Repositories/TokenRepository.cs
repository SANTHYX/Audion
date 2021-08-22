using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly DataContext _context;

        public TokenRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Token token)
        {
            await _context.Tokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<Token> GetAsync(string token)
            => await _context.Tokens
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.RefreshToken == token);

        public async Task UpdateAsync(Token token)
        {
            _context.Tokens.Update(token);
            await _context.SaveChangesAsync();
        }
    }
}
