using Application.Commons.Services;
using Application.Dto.Profile;
using Core.Commons.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ILogger<ProfileService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Guid userId;

        public ProfileService(ILogger<ProfileService> logger, IUserRepository userRepository,
            IProfileRepository profileRepository,IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _httpContextAccessor = httpContext;
            userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ?
                 Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }

        public async Task CreateAsync(CreateProfileDto model)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user is null)
            {
                throw new Exception("Invalid creedentials");
            }
            if (user.Profile is not null)
            {
                throw new Exception("User already have instance of profile");
            }
            await _profileRepository.AddAsync(new(model.FirstName,
                model.LastName, model.Country, model.City, user));
            _logger.LogInformation($"User {user.UserName} has created profile at {DateTime.UtcNow}");
        }

        public async Task UpdateAsync(UpdateProfileDto model)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user is null)
            {
                throw new Exception("Invalid creedentials");
            }
            if (user.Profile is null)
            {
                throw new Exception("User dont own profile instance");
            }
            await _profileRepository.UpdateAsync(user.Profile);
            _logger.LogInformation($"User {user.UserName} has updated profile at {DateTime.UtcNow}");
        }
    }
}
