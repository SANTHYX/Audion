using Core.Commons.Types;
using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Commons.Persistance.Repositories
{
    public interface IUserRepository : IRepository, IGenericRepository<User>
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string userName);
        Task<User> GetWithProfileAsync(Guid id);
        Task<User> GetWithProfileAsync(string userName);
        Task<User> GetRelationalAsync(Guid id);
        Task<User> GetRelationalAsync(string email);
        Task<User> GetAggregateAsync(string userName);
        Task<bool> IsExist(string userName);
    }
}
