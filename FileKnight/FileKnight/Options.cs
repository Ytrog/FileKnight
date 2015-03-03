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

        [Option('a', HelpText="Add the file to the database")]
        public bool AddFile { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = CommandLine.Text.HelpText.AutoBuild(this);
            return help;
        }
    }
}
