using Application.Dto.Identity;
using Application.Dto.User;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IIdentityService
    {
        Task RegisterAsync(RegisterUserDto model);
        Task<GetJwtTokenDto> LoginAsync(LoginUserDto model);
        Task<GetJwtTokenDto> RefreshToken(RefreshTokenDto model);
        Task RevokeToken(RevokeTokenDto model);
    }
}
