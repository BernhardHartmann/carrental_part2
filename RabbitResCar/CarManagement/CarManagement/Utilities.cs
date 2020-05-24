using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement
{
    public static class Utilities
    {
        /// <summary>
        /// Generates a hash from a password string
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        public static void GeneratePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                var errorMessage = $"Password is either null, empty or contains empty whitespaces.";
                throw new ArgumentNullException(errorMessage);
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Converts a string to an enum or defaults to None if the parsing fails
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ToEnum<T>(string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return Enum.TryParse(value, true, out T result) ? result : defaultValue;
        }
    }
}
