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

            var parser = new CommandLine.Parser(BuildParserSettings);
            //parser.Settings.MutuallyExclusive = true;
            Options options = new Options();
            if(parser.ParseArgumentsStrict(args, options))
            {
                var hash = HashFile(options.File.AsAbsolutePath());
                Console.WriteLine(hash);
                if (options.AddFile)
                {
                    Console.WriteLine("adding file");
                }
                if (options.List)
                {
                    Console.WriteLine("listing hashes");
                }
                if (options.Critical)
                {
                    Console.WriteLine("File is critical");
                }
            }
            else
            {
                Console.WriteLine(options.GetUsage());
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


        private static void BuildParserSettings(CommandLine.ParserSettings settings)
        {
            var defaultSettings = CommandLine.Parser.Default.Settings;

            settings.CaseSensitive = defaultSettings.CaseSensitive;
            settings.HelpWriter = defaultSettings.HelpWriter;
            settings.IgnoreUnknownArguments = defaultSettings.IgnoreUnknownArguments;
            settings.MutuallyExclusive = true;
            settings.ParsingCulture = defaultSettings.ParsingCulture;
        }

        
        
    }
}
