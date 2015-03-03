using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace FileKnight.Core
{
    public static class Hasher
    {
        public static byte[] HashToBytes(byte[] input)
        {
            byte[] hash;
            using (var hasher = SHA512Managed.Create())
            {
                hash = hasher.ComputeHash(input);
            }
            return hash;
        }

        public static byte[] HashToBytes(string input)
        {
            return HashToBytes(Encoding.UTF8, input);
        }

        public static byte[] HashToBytes(Encoding encoding, string input)
        {
            return HashToBytes(encoding.GetBytes(input));
        }

        public static string HashToString(Encoding encoding, string input)
        {
            return StringUtils.ToHexString(HashToBytes(encoding, input));
        }

        public static string HashToString(string input)
        {
            return HashToString(Encoding.UTF8, input);
        }

        public static string HashToString(byte[] input)
        {
            return StringUtils.ToHexString(HashToBytes(input));
        }

        
    }
}
