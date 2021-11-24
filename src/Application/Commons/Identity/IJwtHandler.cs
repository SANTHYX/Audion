using Core.Commons.Identity;
using Core.Domain;

namespace Application.Commons.Identity
{
    public interface IJwtHandler
    {
        (Token token, string accessToken) GenerateToken(User user);
    }
}
