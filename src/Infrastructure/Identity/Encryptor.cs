using Application.Commons.Identity;
using Core.Domain;
using System;
using System.Security.Cryptography;

namespace Infrastructure.Identity
{
    public class Encryptor : IEncryptor
    {
        private readonly int bytesNumber = 42;
        private readonly int derivesIterations = 10000;

        public (string hash, string salt) HashPassword(string password)
        {
            var salt = GenerateSalt(password);
            var hash = GenerateHash(password, salt);

            return (hash, salt);
        }

        public bool IsValidPassword(User user, string password)
            => user is not null && user.Password == GenerateHash(password,user.Salt);

        private string GenerateSalt(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password), 
                    "Cannot generate salt becouse password is empty value");
            }

            var bytes = new byte[bytesNumber];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }

        private string GenerateHash(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password),
                    "Cannot generate hash becouse password is empty value");
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new ArgumentNullException(nameof(salt),
                    "Cannot generate hash becouse salt is empty value");
            }

            var pkfd2 = new Rfc2898DeriveBytes(password, GetBytes(salt), derivesIterations);

            return Convert.ToBase64String(pkfd2.GetBytes(bytesNumber));
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(),0,bytes,0,value.Length);

            return bytes;
        }
    }
}
