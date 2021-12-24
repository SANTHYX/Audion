using Core.Commons.Identity;

namespace Application.Dto.Identity.Responses
{
    public record GetJwtTokenDto
    {
        public string AccessToken { get; init; }
        public string Refresh { get; init; }
        public string UserName { get; init; }

        public GetJwtTokenDto(string accessToken, Token token, string userName)
        {
            AccessToken = accessToken;
            Refresh = token.RefreshToken;
            UserName = userName;
        }
    }
}
