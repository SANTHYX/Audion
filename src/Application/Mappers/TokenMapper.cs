using Application.Commons.Mappers;
using Application.Dto.Identity;
using Core.Domain;

namespace Application.Mappers
{
    public class TokenMapper : ITokenMapper
    {
        public GetJwtTokenDto MapTo(Token source)
            => source is null ? null : new()
            {
                Refresh = source.RefreshToken
            };
    }
}
