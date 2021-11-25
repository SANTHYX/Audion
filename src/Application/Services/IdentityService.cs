using Application.Commons.Identity;
using Application.Commons.Services;
using Application.Commons.Toolkits.Mail;
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

namespace Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ILogger<IdentityService> _logger;
        private readonly IUserProvider _provider;
        private readonly IUnitOfWork _unit;
        private readonly IRecoveryIdentityRepository _recoveryIdentity;
        private readonly IEncryptor _encryptor;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMailSender _sender;
        private readonly Guid _userId;

        public IdentityService(
            ILogger<IdentityService> logger,
            IUserProvider provider,
            IUnitOfWork unit,
            IRecoveryIdentityRepository recoveryIdentity,
            IEncryptor encryptor,
            IMailSender sender,
            IJwtHandler jwtHandler)
        {
            _logger = logger;
            _provider = provider;
            _unit = unit;
            _recoveryIdentity = recoveryIdentity;
            _encryptor = encryptor;
            _sender = sender;
            _jwtHandler = jwtHandler;

            _userId = _provider.CurrentUserId;
        }

        public async Task<GetJwtTokenDto> LoginAsync(LoginUserDto model)
        {
            var user = await _unit.User.GetAsync(model.UserName);

            ValidateCreedentials(user, model.Password);

            var (token, accessToken) = _jwtHandler.GenerateToken(user);
            await _unit.Token.AddAsync(token);
            await _unit.CommitAsync();

            _logger.LogInformation($"User '{ model.UserName }' has been logged at { DateTime.UtcNow }");

            return new(accessToken, token, model.UserName);
        }

        public async Task<GetJwtTokenDto> RefreshToken(RefreshTokenDto model)
        {
            var token = await _unit.Token.GetAsync(model.RefreshToken);

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
            var user = await _unit.User.GetAsync(_userId);

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
            var token = await _unit.Token.GetAsync(model.RefreshToken);

            token.NotNull();

            token.RevokeToken();

            _unit.Token.Update(token);
            await _unit.CommitAsync();

            _logger.LogInformation($"Token { token.RefreshToken } " +
                $"for '{ token.User.UserName }' has been succesfully revoked { DateTime.UtcNow }");
        }

        public async Task CreateRecoveryPasswordThreadAsync(string email)
        {
            var user = await _unit.User.GetRelationalAsync(email);

            user.NotNull();

            RecoveryIdentity recovery = new(user);
            _recoveryIdentity.Add(recovery);

            //TODO:Send email with link to perform changing password

        }

        public async Task ChangePasswordAtRecoveryAsync(ChangePasswordAtRecoveryDto model)
        {
            var recoveryThread = _recoveryIdentity.Get(model.RecoveryId);
            var user = await _unit.User.GetAsync(recoveryThread.UserId);

            recoveryThread.NotNull();

            var(hash, salt) = _encryptor.HashPassword(model.NewPassword);

            user.SetPassword(hash);
            user.SetSalt(salt);

            _recoveryIdentity.Remove(recoveryThread);

            _unit.User.Update(user);
            await _unit.CommitAsync();
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
