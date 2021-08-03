using Application.Dto.User;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterUserModel model);
        Task LoginAsync(LoginUserModel model);
    }
}
