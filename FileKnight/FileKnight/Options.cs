using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileKnight
{
    class Options
    {
        [Option('f', "file", Required=true, HelpText="File to hash", MutuallyExclusiveSet="add")]
        public string File { get; set; }

        [Option('a', HelpText="Add the file to the database", MutuallyExclusiveSet="add")]
        public bool AddFile { get; set; }
        [Option('l', "list", HelpText="List all the saved hashes", MutuallyExclusiveSet="display")]
        public bool List { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = CommandLine.Text.HelpText.AutoBuild(this);
            return help;
        }
    }
}
