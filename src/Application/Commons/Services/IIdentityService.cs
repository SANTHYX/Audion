using Application.Dto.Identity;
using Application.Dto.User;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IIdentityService
    {
        Task RegisterAsync(RegisterUserModel model);
        Task<GetJwtToken> LoginAsync(LoginUserModel model);
        Task<GetJwtToken> RefreshToken(RefreshTokenModel model);
    }
}
