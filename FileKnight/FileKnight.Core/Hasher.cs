using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace FileKnight.Core
{
    class Hasher
    {
        public byte[] HashToBytes(byte[] input)
        {
            byte[] hash;
            using (var hasher = SHA512Managed.Create())
            {
                hash = hasher.ComputeHash(input);
            }
            return hash;
        }

        public byte[] HashToBytes(string input)
        {
            return HashToBytes(Encoding.UTF8, input);
        }

        public byte[] HashToBytes(Encoding encoding, string input)
        {
            return HashToBytes(encoding.GetBytes(input));
        }


        private static string ToHexString(byte[] hash)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
