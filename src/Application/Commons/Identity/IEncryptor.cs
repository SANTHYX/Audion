using Core.Domain;

namespace Application.Commons.Identity
{
    public interface IEncryptor
    {
        (string hash, string salt) HashPassword(string password);
        bool IsValidPassword(User user, string password);
    }
}
