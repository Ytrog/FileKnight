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
                string hash = HashFile(options.File);
                if (options.AddFile)
                {

                }
            }

#if DEBUG
            Console.ReadKey();
#endif
        }

        private static string HashFile(string path)
        {
            if (File.Exists(path))
            {
                var input = File.ReadAllBytes(path);
                var output = Hasher.HashToString(input);
                Console.WriteLine(output);
                return output;
            }
            else
            {
                Console.Error.WriteLine("file {0} not found", path); // TODO log4net
                throw new FileNotFoundException();
            }
        }

        
        
    }
}
