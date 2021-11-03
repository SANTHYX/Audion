using Application.Commons.Services;
using Application.Commons.Toolkits.Files;
using Application.Commons.Types;
using Application.Dto.Profile;
using Application.Extensions.Validations;
using Application.Extensions.Validations.Profile;
using Core.Commons.Persistance;
using Core.Domain;
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
        private readonly IStaticFilesWriter<IImageFile> _writer;
        private readonly Guid userId;

        public ProfileService(
            ILogger<ProfileService> logger, 
            IUnitOfWork unit ,
            IHttpContextAccessor httpContext,
            IStaticFilesWriter<IImageFile> writer)
        {
            _logger = logger;
            _unit = unit;
            _httpContextAccessor = httpContext;
            _writer = writer;
            userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ?
                 Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }

        public async Task CreateAsync(CreateProfileDto model)
        {
            var user = await _unit.User.GetAsync(userId);

            user.NotNull().NotOwnProfile();

            Profile profile = new(model.FirstName, 
                model.LastName, model.Country, model.City, user);
            await _unit.Profile.AddAsync(profile);
            await _unit.CommitAsync();

            _logger.LogInformation($"User {user.UserName} has created profile at {DateTime.UtcNow}");
        }

        public async Task UpdateAsync(UpdateProfileDto model)
        {
            var user = await _unit.User.GetAsync(userId);

            user.NotNull().OwnProfile();

            _unit.Profile.Update(user.Profile);
            await _unit.CommitAsync();

            _logger.LogInformation($"User {user.UserName} has updated profile at {DateTime.UtcNow}");
        }

        public async Task UploadAvatarAsync(UploadAvatarDto model)
        {
            var user = await _unit.User.GetAsync(userId);

            user.NotNull().OwnProfile();

            var fileId = Guid.NewGuid().ToString();
            await _writer.SaveAsync(model.Avatar, fileId);

            user.Profile.SetImage(fileId);
            await _unit.CommitAsync();
        }
    }
}
