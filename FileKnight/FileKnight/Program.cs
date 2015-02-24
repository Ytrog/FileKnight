using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FileKnight
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "test";
            
            //var encodings = Encoding.GetEncodings().Where(e => e.Name.Contains("utf")).Select(e => e.GetEncoding());

            //foreach (var e in encodings)
            //{
            //    Hash(e, input);
            //}

            Hash(Encoding.UTF8, input);
            Hash(Encoding.UTF7, input);

            

#if DEBUG
            Console.ReadKey();
#endif
        }

        private static void Hash(Encoding encoding, string input)
        {
            
            var hasher = SHA512Managed.Create();

            byte[] hash = hasher.ComputeHash(encoding.GetBytes(input));

            string output = ToHexString(hash);

            Console.WriteLine();
            Console.WriteLine(encoding.EncodingName);
            Console.WriteLine(output);
            
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

        private static string DifferAt(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("lengths differ 1:{0}\t2:{1}\n", s1.Length, s2.Length);
                sb.AppendLine(s1);
                sb.AppendLine(s2);
                return sb.ToString();
            }

            int length = s1.Length;

            for (int i = 0; i < length; i++)
            {
                if (s1[i].Equals(s2[i]))
                {
                    continue;
                }
                else
                {
                    return string.Format("{0} 1:{1} 2:{2}", i, s1[i], s2[i]);
                }
            }

            return "same";
        }
    }
}
