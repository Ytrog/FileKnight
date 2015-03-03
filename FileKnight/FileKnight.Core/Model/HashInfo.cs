using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileKnight.Core.Model
{
    public class HashInfo
    {
        public string Path { get; set; }
        public string HashString { get; set; }
        public byte[] Hash { get; set; }

        public HashInfo(string path, string hashString, byte[] Hash)
        {

        }
    }
}
