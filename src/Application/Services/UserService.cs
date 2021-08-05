using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Dto.User;
using Core.Commons.Repositories;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _mapper;

        public UserService(IUserRepository userRepository, IUserMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserDto> GetAsync(string userName)
        {
            var user = await _userRepository.GetAsync(userName);

            return _mapper.MapTo(user);
        }
    }
}
