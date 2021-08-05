using Core.Domain;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IProfileService
    {
        Task CreateAsync(Profile profile);
        Task UpdateAsync(Profile profile);
    }
}
