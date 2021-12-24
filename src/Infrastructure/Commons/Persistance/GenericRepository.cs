using Core.Commons.Types;
using Infrastructure.Persistance;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Persistance
{
    public abstract class GenericRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
