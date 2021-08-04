using Core.Domain;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface ITokenRepository
    {
        Task AddAsync(Token token);
        Task<Token> GetAsync(string token);
        Task UpdateAsync(Token token);
    }
}
