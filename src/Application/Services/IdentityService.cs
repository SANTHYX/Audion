using Application.Commons.Identity;
using Application.Commons.Services;
using Application.Dto.Identity;
using Application.Dto.User;
using Core.Commons.Persistance;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUnitOfWork _unit;
        private readonly IEncryptor _encryptor;
        private readonly IJwtHandler _jwtHandler;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<IdentityService> _logger;
        private readonly Guid userId;

        public IdentityService(IUnitOfWork unit, IEncryptor encryptor, 
            IJwtHandler jwtHandler, IHttpContextAccessor contextAccessor,
            ILogger<IdentityService> logger)
        {
            _unit = unit;
            _encryptor = encryptor;
            _jwtHandler = jwtHandler;
            _contextAccessor = contextAccessor;
            _logger = logger;
            userId = _contextAccessor.HttpContext.User.Identity.IsAuthenticated ? 
                Guid.Parse(_contextAccessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }

        public async Task ChangeCreedentials(ChangeCreedentialsDto model)
        {
            var user = await _unit.User.GetAsync(userId);

            if (!_encryptor.IsValidPassword(user, model.OldPassword))
            {
                throw new UnauthorizedAccessException("Invalid creedentials");
            }

            var(hash, salt) = _encryptor.HashPassword(model.NewPassword);
            user.SetPassword(hash);
            user.SetSalt(salt);

            _unit.User.Update(user);
            await _unit.CommitAsync();

            _logger.LogInformation($"User: '{user.UserName}' has changed password at {DateTime.UtcNow}");
        }

        public async Task<GetJwtTokenDto> LoginAsync(LoginUserDto model)
        {
            var user = await _unit.User.GetAsync(model.UserName);

            if (!_encryptor.IsValidPassword(user, model.Password))
            {
                throw new UnauthorizedAccessException("Invalid creedentials");
            }

            var(token, accessToken) = _jwtHandler.GenerateToken(user);
            await _unit.Token.AddAsync(token);
            await _unit.CommitAsync();

            _logger.LogInformation($"User '{model.UserName}' has been logged at {DateTime.UtcNow}");

            return new()
            {
                AccessToken = accessToken,
                Refresh = token.RefreshToken,
                UserName = user.UserName
            };
        }

        public async Task<GetJwtTokenDto> RefreshToken(RefreshTokenDto model)
        {
            var token = await _unit.Token.GetAsync(model.RefreshToken);

            if (token is null)
            {
                throw new UnauthorizedAccessException("Invalid creedentials");
            }
            if (token.IsRevoked)
            {
                throw new Exception("Token is revoked, cannot be refreshed");
            }

            var (newToken, accessToken) = _jwtHandler.GenerateToken(token.User);
            await _unit.Token.AddAsync(newToken);
            await _unit.CommitAsync();

            _logger.LogInformation($"Token for User: '{token.User.UserName}' " +
                $"has been has been refreshed at {DateTime.UtcNow}");

            return new()
            {
                AccessToken = accessToken,
                Refresh = newToken.RefreshToken,
                UserName = token.User.UserName
            };
        }

        public async Task RegisterAsync(RegisterUserDto model)
        {
            if (await _unit.User.IsExist(model.UserName))
            {
                throw new Exception($"User with this Username: '{model.UserName}' already exist");
            }

            var (hash, salt) = _encryptor.HashPassword(model.Password);
            User user = new(model.UserName, hash, salt, model.Email);
            await _unit.User.AddAsync(user);
            await _unit.CommitAsync();

            _logger.LogInformation($"User has been succesfully registered");
        }

        public async Task RevokeTokenAsync(RevokeTokenDto model)
        {
            var token = await _unit.Token.GetAsync(model.RefreshToken);

            if (token is null)
            {
                throw new UnauthorizedAccessException("Invalid creendentials");
            }

            token.RevokeToken();
            _unit.Token.Update(token);
            await _unit.CommitAsync();

            _logger.LogInformation($"Token {token.RefreshToken} " +
                $"for '{token.User.UserName}' has been succesfully revoked {DateTime.UtcNow}");
        }
    }
}
