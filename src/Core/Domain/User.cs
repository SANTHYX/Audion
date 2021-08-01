using Core.Types;
using System;

namespace Core.Domain
{
    public class User : Entity
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        protected User() { }

        public User(string userName, string password, string email)
        {
            SetUserName(userName);
            SetPassword(password);
            SetEmail(email);
        }

        public void SetUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new Exception("Username is required");
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
                throw new Exception("Password is required");
            }
            if (Password == password)
            {
                return;
            }

            Password = password;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is required");
            }
            if (Email == email)
            {
                return;
            }

            Email = email;
        }
    }
}
