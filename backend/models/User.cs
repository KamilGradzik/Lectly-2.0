using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace backend.models
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public bool IsActive { get; private set; }

        private User() { }

        public User(string email, string password, string firstName, string lastName, bool isActive)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            SetPassword(password);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetIsActive(isActive);
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("User's email cannot be empty!");

            if(!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                throw new ArgumentException ("User's email format is invalid!");

            Email = email;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("User's password cannot be empty!");
            
            Password = password;
        }

        public void SetFirstName(string firstName)
        {
            if(string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("User's first name cannot be empty!");
            
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if(string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("User's last name cannot be empty!");
            
            LastName = lastName;
        }

        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }
    }
}