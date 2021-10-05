using Core.Commons.Persistance;
using Core.Domain;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface ITokenRepository : IGenericRepository<Token>
    {
        Task<Token> GetAsync(string token);
    }
}
