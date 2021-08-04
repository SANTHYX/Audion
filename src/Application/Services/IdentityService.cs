using Application.Commons.Identity;
using Application.Commons.Services;
using Application.Dto.Identity;
using Application.Dto.User;
using Core.Commons.Repositories;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IEncryptor _encryptor;
        private readonly IJwtHandler _jwtHandler;

        public IdentityService(IUserRepository userRepository, ITokenRepository tokenRepository,
            IEncryptor encryptor, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _encryptor = encryptor;
            _jwtHandler = jwtHandler;
        }

        //Need to change names
        public async Task<GetJwtToken> LoginAsync(LoginUserModel model)
        {
            var user = await _userRepository.GetAsync(model.UserName);
            if (user is null || !_encryptor.IsValidPassword(user, model.Password))
            {
                throw new Exception("Invalid creedentials");
            }
            var(token, accessToken) = _jwtHandler.GenerateToken(user);
            await _tokenRepository.AddAsync(token);

            return new()
            {
                AccessToken = accessToken,
                Refresh = token.RefreshToken
            };
        }

        public async Task<GetJwtToken> RefreshToken(RefreshTokenModel model)
        {
            var token = await _tokenRepository.GetAsync(model.RefreshToken);
            if (token is null)
            {
                throw new Exception("Invalid creedentials");
            }
            if (token.IsRevoked)
            {
                throw new Exception("Token is revoked");
            }
            var (newToken, accessToken) = _jwtHandler.GenerateToken(token.User);
            await _tokenRepository.AddAsync(newToken);

            return new()
            {
                AccessToken = accessToken,
                Refresh = newToken.RefreshToken
            };
        }

        public async Task RegisterAsync(RegisterUserModel model)
        {
            if (await _userRepository.IsExist(model.UserName))
            {
                throw new Exception($"User with this Username: {model.UserName} already exist");
            }
            var (hash,salt) = _encryptor.HashPassword(model.Password);
            await _userRepository.AddAsync(
                new(model.UserName, hash, salt, model.Email));
        }
    }
}
