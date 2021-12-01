using Application.Commons.Identity;
using Application.Commons.Services.Business;
using Application.Commons.Toolkits.Files;
using Application.Commons.Types;
using Application.Dto.Profile;
using Application.Extensions.Validations;
using Application.Extensions.Validations.Profile;
using Core.Commons.Persistance;
using Core.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services.Business
{
    public class ProfileService : IProfileService
    {
        private readonly ILogger<ProfileService> _logger;
        private readonly IUserProvider _provider;
        private readonly IUnitOfWork _unit;
        private readonly IStaticFileManager<IImageFile> _fileManager;
        private Guid _userId;

        public ProfileService(
            ILogger<ProfileService> logger,
            IUserProvider provider,
            IUnitOfWork unit ,
            IStaticFileManager<IImageFile> fileManager)
        {
            _logger = logger;
            _provider = provider;
            _unit = unit;
            _fileManager = fileManager;
            _userId = _provider.CurrentUserId;
        }

        public async Task CreateAsync(CreateProfileDto model)
        {
            var user = await _unit.User.GetByIdAsync(_userId);

            user.NotNull().NotOwnProfile();

            Profile profile = new(
                model.FirstName, 
                model.LastName,
                model.Country,
                model.City,
                user);
            await _unit.Profile.AddAsync(profile);
            await _unit.CommitAsync();

            _logger.LogInformation($"User with Id { _userId } has created profile at { DateTime.UtcNow }");
        }

        public async Task UpdateAsync(UpdateProfileDto model)
        {
            var profile = await _unit.Profile.GetByUserIdAsync(_userId);

            profile.NotNull();

            _unit.Profile.Update(profile);
            await _unit.CommitAsync();

            _logger.LogInformation($"User with Id { _userId } has updated profile at { DateTime.UtcNow }");
        }

        public async Task UploadAvatarAsync(UploadAvatarDto model)
        {
            var profile = await _unit.Profile.GetByUserIdAsync(_userId);

            profile.NotNull();

            var fileId = Guid.NewGuid().ToString();
            await _fileManager.SaveAsync(model.Avatar, fileId);

            _logger.LogInformation("File has been uploaded on server");

            profile.SetImage(fileId);

            _unit.Profile.Update(profile);
            await _unit.CommitAsync();

            _logger.LogInformation("Task have been finished sucessfully");
        }
    }
}
