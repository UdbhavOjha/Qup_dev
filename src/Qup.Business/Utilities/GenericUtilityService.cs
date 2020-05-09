using System;
using System.Security.Cryptography;

namespace Qup.Business.Utilities
{
    public static class GenericUtilityService
    {
        private const int PasswordHashByteSize = 20;

        public static UserCredentials EncryptPassword(string password)
        {
            var salt = Guid.NewGuid();
            var saltByte = salt.ToByteArray();
            // Use the salt to hash the password using PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(password, saltByte);

            // Get the hashed password
            byte[] hashedPassword = pbkdf2.GetBytes(PasswordHashByteSize);

            // To Do - append salt to hash for more complexity

            // convert the byte array to a string
            return new UserCredentials() 
            {
                Salt = salt.ToString(),
                EncryptedPassword = Convert.ToBase64String(hashedPassword)
            };
        }

    }

    public class UserCredentials 
    {
        public string Salt { get; set; }

        public string EncryptedPassword { get; set; }
    }
}
