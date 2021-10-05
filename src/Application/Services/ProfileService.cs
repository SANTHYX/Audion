using Application.Commons.Services;
using Application.Dto.Profile;
using Core.Commons.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ILogger<ProfileService> _logger;
        private readonly IUnitOfWork _unit;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Guid userId;

        public ProfileService(ILogger<ProfileService> logger, 
            IUnitOfWork unit ,IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _unit = unit;
            _httpContextAccessor = httpContext;
            userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ?
                 Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }

        public async Task CreateAsync(CreateProfileDto model)
        {
            var user = await _unit.User.GetAsync(userId);
            if (user is null)
            {
                throw new Exception("Invalid creedentials");
            }
            if (user.Profile is not null)
            {
                throw new Exception("User already have instance of profile");
            }
            await _unit.Profile.AddAsync(new(model.FirstName,
                model.LastName, model.Country, model.City, user));
            await _unit.CommitAsync();
            _logger.LogInformation($"User {user.UserName} has created profile at {DateTime.UtcNow}");
        }

        public async Task UpdateAsync(UpdateProfileDto model)
        {
            var user = await _unit.User.GetAsync(userId);
            if (user is null)
            {
                throw new Exception("Invalid creedentials");
            }
            if (user.Profile is null)
            {
                throw new Exception("User dont own profile instance");
            }
            _unit.Profile.Update(user.Profile);
            await _unit.CommitAsync();
            _logger.LogInformation($"User {user.UserName} has updated profile at {DateTime.UtcNow}");
        }

        public async Task UploadAvatarAsync(UploadAvatarDto model)
        {
            var user = await _unit.User.GetAsync(userId);
            if (user is null)
            {
                throw new Exception("Invalid creedentials");
            }
            if (user.Profile is null)
            {
                throw new Exception("User dont own profile instance");
            }
        }
    }
}
