using Application.Commons.Services;
using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Guid userId;

        public ProfileService(IUserRepository userRepository, IProfileRepository profileRepository,
            IHttpContextAccessor httpContext)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _httpContextAccessor = httpContext;
            userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated 
                ? Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name): Guid.Empty;
        }

        public async Task CreateAsync(Profile profile)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}
