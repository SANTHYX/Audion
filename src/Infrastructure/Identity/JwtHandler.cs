using Application.Commons.Identity;
using Core.Commons.Identity;
using Core.Domain;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Identity
{
    public class JwtHandler : IJwtHandler
    {
        private readonly SecuritySettings _settings;

        public JwtHandler(IOptions<SecuritySettings> settings)
        {
            _settings = settings.Value;
        }

        public (Token token, string accessToken) GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresAt = DateTime.Now.AddDays(2);
            var claim = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(null,null,
                claim,DateTime.Now,expiresAt,signingCredentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return(new(expiresAt, user), accessToken);
        }
    }
}
