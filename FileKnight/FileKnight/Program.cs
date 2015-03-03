using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using FileKnight.Core;
using System.IO;
using FileKnight.Core.Model;

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
                var hash = HashFile(options.File.AsAbsolutePath());
                Console.WriteLine(hash);
                if (options.AddFile)
                {
                    
                }
            }

#if DEBUG
            Console.ReadKey();
#endif
        }

        private static HashInfo HashFile(string path)
        {
            
            if (File.Exists(path))
            {
                var input = File.ReadAllBytes(path);
                var output = Hasher.HashToBytes(input);
                return new HashInfo(path, output);
            }
            else
            {
                Console.Error.WriteLine("file {0} not found", path); // TODO log4net
                throw new FileNotFoundException();
            }
        }

        
        
    }
}
