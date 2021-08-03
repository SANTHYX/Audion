using Application.Commons.Services;
using Application.Dto.User;
using Core.Commons.Repositories;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task LoginAsync(LoginUserModel model)
        {
            throw new System.NotImplementedException();
        }

        public async Task RegisterAsync(RegisterUserModel model)
        {
            await _userRepository.AddAsync(
                new(model.UserName, model.Password, model.Email));
        }
    }
}
