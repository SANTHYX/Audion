using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string userName);
        Task<User> GetAggregateAsync(Guid id);
        Task<bool> IsExist(string userName);
        Task UpdateAsync(User user);
    }
}
