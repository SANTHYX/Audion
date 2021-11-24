using Application.Commons.Types;
using Application.Dto.Identity;
using Application.Dto.User;
using System;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IIdentityService : IService
    {
        Task<GetJwtTokenDto> LoginAsync(LoginUserDto model);
        Task<GetJwtTokenDto> RefreshToken(RefreshTokenDto model);
        Task RegisterAsync(RegisterUserDto model);
        Task ChangeCreedentials(ChangeCreedentialsDto model);
        Task RevokeTokenAsync(RevokeTokenDto model);
        Task CreateRecoveryPasswordThreadAsync(string email);
        Task ChangePasswordAtRecoveryAsync(ChangePasswordAtRecoveryDto model);
    }
}
