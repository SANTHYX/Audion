using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Dto.User;
using Application.Exceptions;
using Core.Commons.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _mapper;

        public UserService(ILogger<UserService> logger, 
            IUserRepository userRepository, IUserMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserDto> GetAsync(string userName)
        {
            var user = await _userRepository.GetAsync(userName);
            if (user is null)
            {
                throw new NotFoundException($"User with Username: {userName} has not been found");
            }
            _logger.LogInformation($"User with userName: {user.UserName} has been fetched");

            return _mapper.MapTo(user);
        }
    }
}
