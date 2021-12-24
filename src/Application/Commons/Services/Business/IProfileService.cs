using Application.Commons.Types;
using Application.Dto.Profile.Requests;
using System.Threading.Tasks;

namespace Application.Commons.Services.Business
{
    public interface IProfileService : IService
    {
        Task CreateAsync(CreateProfileDto model);
        Task UpdateAsync(UpdateProfileDto model);
        Task UploadAvatarAsync(UploadAvatarDto model);
    }
}
