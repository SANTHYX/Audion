using Core.Commons.Persistance;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string userName);
        Task<User> GetAggregateAsync(string userName);
        Task<bool> IsExist(string userName);
    }
}
