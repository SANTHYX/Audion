using Application.Dto.Identity;
using Application.Dto.User;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IIdentityService
    {
        Task RegisterAsync(RegisterUserDto model);
        Task ChangeCreedentials(ChangeCreedentialsDto model);
        Task<GetJwtTokenDto> LoginAsync(LoginUserDto model);
        Task<GetJwtTokenDto> RefreshToken(RefreshTokenDto model);
        Task RevokeTokenAsync(RevokeTokenDto model);
    }
}
