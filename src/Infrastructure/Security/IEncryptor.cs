using Core.Domain;

namespace Infrastructure.Security
{
    public interface IEncryptor
    {
        (string hash, string salt) HashPassword(string password);
        bool IsValidPassword(User user, string password);
    }
}
