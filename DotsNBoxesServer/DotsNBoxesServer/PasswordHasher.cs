using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DotsNBoxesServer
{
    /// <summary>
    /// Simple password hashing utility
    /// </summary>
    static class PasswordHasher
    {
        /// <summary>
        /// The number of iterations to use in the hash
        /// </summary>
        private const int HASH_ITERATIONS = 1000;

        /// <summary>
        /// The number of hash bytes to generate
        /// </summary>
        private const int HASH_BYTES = 50;

        /// <summary>
        /// The number of salt bytes to generate
        /// </summary>
        private const int SALT_BYTES = 25;

        /// <summary>
        /// Generates a string of salt to be used in a password hash
        /// </summary>
        /// <returns>Randomly generated salt</returns>
        public static string GenerateSalt()
        {
            //Generate some random salt for use in hashing
            RNGCryptoServiceProvider crypoRandom = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTES];
            crypoRandom.GetBytes(salt);

            //Return the salt in string form
            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// Hashes a given password with given salt
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <param name="salt">The salt to use alongside the hash</param>
        /// <returns>The password in hashed from</returns>
        public static string HashPassword(string password, string salt)
        {
            //Convert the given salt from a string to a byte array
            byte[] byteSalt = Convert.FromBase64String(salt);

            //Hash the password with the given salt
            Rfc2898DeriveBytes hash = new Rfc2898DeriveBytes(password, byteSalt);
            hash.IterationCount = HASH_ITERATIONS;
            byte[] hashedPassword = hash.GetBytes(HASH_BYTES);

            //Return the hashed password in string form
            return Convert.ToBase64String(hashedPassword);
        }
    }
}
