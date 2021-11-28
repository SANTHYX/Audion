using Core.Commons.Types;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Commons.Persistance.Repositories
{
    public interface IProfileRepository : IRepository, IGenericRepository<Profile>
    {
        Task<Profile> GetByUserIdAsync(Guid userId);
    }
}
