using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using FileKnight.Core;
using System.IO;

namespace FileKnight
{
    class Program
    {
        static void Main(string[] args)
        {

            var parser = CommandLine.Parser.Default;
            Options options = new Options();
            if(parser.ParseArguments(args, options))
            {
                HashFile(options.File);
            }

#if DEBUG
            Console.ReadKey();
#endif
        }

        private static void HashFile(string path)
        {
            if (File.Exists(path))
            {
                var input = File.ReadAllBytes(path);
                var output = Hasher.HashToString(input);
                Console.WriteLine(output);
            }
        }

        
        
    }
}
