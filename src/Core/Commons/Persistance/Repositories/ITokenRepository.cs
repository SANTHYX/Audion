using Core.Commons.Identity;
using Core.Commons.Types;
using Core.Domain;
using System.Threading.Tasks;

namespace Core.Commons.Persistance.Repositories
{
    public interface ITokenRepository : IRepository, IGenericRepository<Token>
    {
        Task<Token> GetAsync(string token);
    }
}
