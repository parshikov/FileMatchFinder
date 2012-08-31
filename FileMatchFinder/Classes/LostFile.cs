using System.IO;

namespace FilesMatchFinder
{
    public class LostFile
    {
        public LostFile(string name, long length, long beginFrom)
        {
            Name = name;
            Length = length;
            BeginFrom = beginFrom;
        }

        public string Name;
        public long Length;
        public long BeginFrom;
    }
} 