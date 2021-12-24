using Core.Commons.Identity;
using Core.Commons.Persistance.Repositories;
using Infrastructure.Commons.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class TokenRepository : GenericRepository<Token>, ITokenRepository
    {
        private readonly DataContext _context;

        public TokenRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Token> GetByRefreshAsync(string refresh)
            => await _context.Tokens
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.RefreshToken == refresh);
    }
}
