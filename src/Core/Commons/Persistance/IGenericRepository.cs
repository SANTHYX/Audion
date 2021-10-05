using System.Threading.Tasks;

namespace Core.Commons.Persistance
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Update(T entity);
    }
}
