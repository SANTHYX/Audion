using Core.Commons.Types;
using Core.Extensions;
using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class User : Entity
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; set; }
        public string Email { get; private set; }
        public Profile Profile { get; private set; }
        public IEnumerable<Token> Tokens { get; private set; }
        public IEnumerable<Playlist> Playlists { get; private set; }
        public IEnumerable<Track> Tracks { get; private set; }

        protected User() { }

        public User(string userName, string password, string salt, string email)
        {
            SetUserName(userName);
            SetPassword(password);
            SetSalt(salt);
            SetEmail(email);
        }

        public void SetUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(userName, "Username is required");
            }
            if (UserName == userName)
            {
                return;
            }

            UserName = userName;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(password, "Password is required");
            }
            if (Password == password)
            {
                return;
            }

            Password = password;
        }

        public void SetSalt(string salt)
        {
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new ArgumentNullException(salt, "Salt is required");
            }
            if (Salt == salt)
            {
                return;
            }

            Salt = salt;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(email, "Email is required");
            }
            if (!email.IsValidEmail())
            {
                throw new Exception("Email is invaild");
            }
            if (Email == email)
            {
                return;
            }

            Email = email;
        }
    }
}
