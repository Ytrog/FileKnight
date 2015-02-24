using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using FileKnight.Core;

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

            string output = Hasher.HashToString(encoding, input);

            Console.WriteLine();
            Console.WriteLine(encoding.EncodingName);
            Console.WriteLine(output);
            
        }

        
    }
}
