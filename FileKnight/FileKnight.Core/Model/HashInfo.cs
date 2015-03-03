using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileKnight.Core.Model
{
    public class HashInfo : IEquatable<HashInfo>
    {
        public string Path { get; private set; }
        public string HashString { get { return StringUtils.ToHexString(Hash); } }
        public byte[] Hash { get; private set; }

        public HashInfo(string path, byte[] hash)
        {
            Path = path;
            Hash = hash;
        }



        public bool Equals(HashInfo other)
        {
            return Path.Equals(other.Path) && Hash == other.Hash;
        }

        public override string ToString()
        {
            return "{0} \t {1}".FormatInvariant(Path, HashString);
        }

        public override bool Equals(object obj)
        {
            HashInfo other = obj as HashInfo;
            if (other != null)
            {
                return Equals(other);
            }
            else
            {
                return false;
            }
        }
    }
}
