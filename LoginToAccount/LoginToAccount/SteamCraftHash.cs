using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace LoginToAccount
{
    class SteamCraftHash
    {
        public string getHash(string password, string salt)
        {
            // Convert password into a byte array
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Convert salt from getSalt into a byte array
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            // Allocate array, which will hold password and salt
            byte[] passwordWithSaltBytes = new byte[passwordBytes.Length + saltBytes.Length];

            // Copy password bytes into resulting array
            for (int i = 0; i < passwordBytes.Length; i++)
                passwordWithSaltBytes[i] = passwordBytes[i];

            // Append salt bytes to the resulting array
            for (int i = 0; i < saltBytes.Length; i++)
                passwordWithSaltBytes[passwordBytes.Length + i] = saltBytes[i];

            // Create hashing algorithm object. I just picked one. No, really.
            HashAlgorithm hash = new SHA512Managed();

            // Compute hash value of the password with appended salt
            byte[] hashBytes = hash.ComputeHash(passwordWithSaltBytes);

            // Append salt bytes to the result
            byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

            // Copy hash bytes into resulting array
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // convert to base64-encoded string
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Spit that mofo back out
            return hashValue;
        }
    }
}
