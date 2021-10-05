using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Dto.User;
using Application.Exceptions;
using Core.Commons.Persistance;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUnitOfWork _unit;
        private readonly IUserMapper _mapper;

        public UserService(ILogger<UserService> logger, IUnitOfWork unit, IUserMapper mapper)
        {
            _logger = logger;
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<GetUserDto> GetAsync(string userName)
        {
            var user = await _unit.User.GetAggregateAsync(userName);
            if (user is null)
            {
                throw new NotFoundException($"User with Username: {userName} has not been found");
            }
            _logger.LogInformation($"User with userName: {user.UserName} has been fetched");

            return _mapper.MapTo(user);
        }
    }
}
