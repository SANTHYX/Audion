using Application.Commons.Types;
using Application.Dto.Identity;
using Application.Dto.User;
using System.Threading.Tasks;

namespace Application.Commons.Services.Business
{
    public interface IIdentityService : IService
    {
        Task<GetJwtTokenDto> LoginAsync(LoginUserDto model);
        Task<GetJwtTokenDto> RefreshToken(RefreshTokenDto model);
        Task RegisterAsync(RegisterUserDto model);
        Task ChangeCreedentials(ChangeCreedentialsDto model);
        Task RevokeTokenAsync(RevokeTokenDto model);
        Task CreateRecoveryPasswordThreadAsync(RecoveryPasswordDto model);
        Task ChangePasswordAtRecoveryAsync(ChangePasswordAtRecoveryDto model);
    }
}
