using System.Threading.Tasks;
using Application.Commons.Types;
using Application.Dto.Identity.Requests;
using Application.Dto.Identity.Responses;

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
