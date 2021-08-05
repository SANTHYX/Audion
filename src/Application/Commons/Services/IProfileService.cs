using Application.Dto.Profile;
using Core.Domain;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IProfileService
    {
        Task CreateAsync(CreateProfileDto model);
        Task UpdateAsync(UpdateProfileDto model);
    }
}
