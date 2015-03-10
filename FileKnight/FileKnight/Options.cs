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
        [Option('f', "file", Required=true, HelpText="File to hash")]
        public string File { get; set; }

        [Option('a', HelpText="Add the file to the database", MutuallyExclusiveSet="add/display")]
        public bool AddFile { get; set; }
        [Option('l', "list", HelpText="List all the saved hashes", MutuallyExclusiveSet="add/display")]
        public bool List { get; set; }
        [Option('c', "critical", HelpText="Mark a file as critical")]
        public bool Critical { get; set; }
        [Option('C', "check", HelpText="Check the database for changes")]
        public bool Check { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = CommandLine.Text.HelpText.AutoBuild(this);
            return help;
        }
    }
}
