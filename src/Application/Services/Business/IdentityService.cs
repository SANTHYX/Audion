using Application.Commons.Identity;
using Application.Commons.Services.Business;
using Application.Commons.Services.System.Mailing;
using Application.Dto.Identity;
using Application.Dto.User;
using Application.Extensions.Validations;
using Application.Extensions.Validations.Identity;
using Core.Commons.Identity;
using Core.Commons.Persistance;
using Core.Commons.Persistance.Repositories;
using Core.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services.Business
{
    public class IdentityService : IIdentityService
    {
        private readonly ILogger<IdentityService> _logger;
        private readonly IUserProvider _provider;
        private readonly IUnitOfWork _unit;
        private readonly IRecoveryIdentityRepository _recoveryIdentity;
        private readonly IEncryptor _encryptor;
        private readonly IJwtHandler _jwtHandler;
        private readonly IIdentityCommunicatesService _communicatesService;
        private readonly Guid _userId;

        public IdentityService(
            ILogger<IdentityService> logger,
            IUserProvider provider,
            IUnitOfWork unit,
            IRecoveryIdentityRepository recoveryIdentity,
            IEncryptor encryptor,
            IJwtHandler jwtHandler,
            IIdentityCommunicatesService communicatesService)
        {
            _logger = logger;
            _provider = provider;
            _unit = unit;
            _recoveryIdentity = recoveryIdentity;
            _encryptor = encryptor;
            _jwtHandler = jwtHandler;
            _communicatesService = communicatesService;
            _userId = _provider.CurrentUserId;
        }

        public async Task<GetJwtTokenDto> LoginAsync(LoginUserDto model)
        {
            var user = await _unit.User.GetByUsernameAsync(model.UserName);

            ValidateCreedentials(user, model.Password);

            var (token, accessToken) = _jwtHandler.GenerateToken(user);
            await _unit.Token.AddAsync(token);
            await _unit.CommitAsync();

            _logger.LogInformation($"User '{ model.UserName }' has been logged at { DateTime.UtcNow }");

            return new(accessToken, token, model.UserName);
        }

        public async Task<GetJwtTokenDto> RefreshToken(RefreshTokenDto model)
        {
            var token = await _unit.Token.GetByRefreshAsync(model.RefreshToken);

            token.NotNull().NotRevoked();

            var (newToken, accessToken) = _jwtHandler.GenerateToken(token.User);

            await _unit.Token.AddAsync(newToken);
            await _unit.CommitAsync();

            _logger.LogInformation($"Token for User: '{ token.User.UserName }' " +
                $"has been has been refreshed at { DateTime.UtcNow }");

            return new(accessToken, newToken, token.User.UserName);
        }

        public async Task RegisterAsync(RegisterUserDto model)
        {
            await CheckUserExistance(model.UserName);

            var (hash, salt) = _encryptor.HashPassword(model.Password);

            User user = new(model.UserName, hash, salt, model.Email);
            await _unit.User.AddAsync(user);
            await _unit.CommitAsync();

            _logger.LogInformation($"User has been succesfully registered");
        }

        public async Task ChangeCreedentials(ChangeCreedentialsDto model)
        {
            var user = await _unit.User.GetByIdAsync(_userId);

            ValidateCreedentials(user, model.OldPassword);
           
            var(hash, salt) = _encryptor.HashPassword(model.NewPassword);

            user.SetPassword(hash);
            user.SetSalt(salt);

            _unit.User.Update(user);
            await _unit.CommitAsync();

            _logger.LogInformation($"User: '{ user.UserName }' has changed password at { DateTime.UtcNow }");
        }

        public async Task RevokeTokenAsync(RevokeTokenDto model)
        {
            var token = await _unit.Token.GetByRefreshAsync(model.RefreshToken);

            token.NotNull();

            token.RevokeToken();

            _unit.Token.Update(token);
            await _unit.CommitAsync();

            _logger.LogInformation($"Token { token.RefreshToken } " +
                $"for '{ token.User.UserName }' has been succesfully revoked { DateTime.UtcNow }");
        }

        public async Task CreateRecoveryPasswordThreadAsync(RecoveryPasswordDto model)
        {
            var user = await _unit.User.GetByEmailAsync(model.Email);

            user.NotNull();

            RecoveryIdentity recovery = new(user);
            _recoveryIdentity.Add(recovery);

            await _communicatesService.SendMailWithRecoveryPageLinkAsync(model.Email, recovery.Id);
        }

        public async Task ChangePasswordAtRecoveryAsync(ChangePasswordAtRecoveryDto model)
        {
            var recoveryThread = _recoveryIdentity.Get(model.RecoveryId);

            recoveryThread.NotNull();

            var(hash, salt) = _encryptor.HashPassword(model.NewPassword);

            recoveryThread.User.SetPassword(hash);
            recoveryThread.User.SetSalt(salt);

            _unit.User.Update(recoveryThread.User);
            await _unit.CommitAsync();

            _recoveryIdentity.Remove(recoveryThread);
        }

        private void ValidateCreedentials(User user, string password)
        {
            if (!_encryptor.IsValidPassword(user, password))
            { 
                throw new UnauthorizedAccessException("Invalid creedentials");
            }
        }

        private async Task CheckUserExistance(string userName)
        {
            if (await _unit.User.IsExist(userName))
            { 
                throw new Exception($"User with this Username: '{ userName }' already exist");
            }
        }
    }
}
