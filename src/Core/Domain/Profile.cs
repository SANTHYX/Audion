﻿using Core.Types;
using System;

namespace Core.Domain
{
    public class Profile : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Stats Stats { get; private set; }

        protected Profile() { }

        public Profile(string firstName, string lastName, string country, string city, User user)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetCountry(country);
            SetCity(city);
            AddUser(user);
        }

        public void SetFirstName(string firstName)
        {
            if (FirstName == firstName)
            {
                return;
            }

            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (LastName == lastName)
            {
                return;
            }

            LastName = lastName;
        }

        public void SetCountry(string country)
        {
            if (Country == country)
            {
                return;
            }

            Country = country;
        }

        public void SetCity(string city)
        {
            if (City == city)
            {
                return;
            }

            City = city;
        }

        public void AddUser(User user)
        {
            User = user ?? throw new Exception("Cannot bind newly Profile with empty user");
        }
    }
}
