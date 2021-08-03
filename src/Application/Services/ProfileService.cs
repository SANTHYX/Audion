using Application.Commons.Services;
using Core.Commons.Repositories;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly Guid userId;

        public ProfileService(IUserRepository userRepository, IProfileRepository profileRepository,
            IHttpContextAccessor httpContext)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _httpContext = httpContext;
            userId = _httpContext.HttpContext.User.Identity.IsAuthenticated 
                ? Guid.Parse(_httpContext.HttpContext.User.Identity.Name): Guid.Empty;
        }

        public async Task AddAsync(Profile profile)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}
