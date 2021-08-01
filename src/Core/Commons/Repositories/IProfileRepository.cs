using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IProfileRepository
    {
        Task AddAsync(Profile profile);
        Task<Profile> GetAsync(Guid userId);
        Task UpdateAsync(Profile profile);
    }
}
