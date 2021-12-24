using Core.Commons.Pagination;
using Core.Commons.Types;
using Core.Domain;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Commons.Persistance.Repositories
{
    public interface IUserRepository : IRepository, IGenericRepository<User>
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByUsernameAsync(string userName);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetWithProfileByIdAsync(Guid id);
        Task<User> GetWithProfileByUsernameAsync(string userName);
        Task<User> GetAggregateAsync(string userName);
        Task<Page<User>> GetAllAsync(Expression<Func<User, bool>> expression, PagedQuery pagedQuery);
        Task<bool> IsExist(string userName);
    }
}
