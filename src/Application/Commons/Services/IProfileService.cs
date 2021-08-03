using Core.Domain;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IProfileService
    {
        Task AddAsync(Profile profile);
        Task UpdateAsync(Profile profile);
    }
}
