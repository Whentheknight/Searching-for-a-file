using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeekAndArchive
{
    public class SearchOptions
    {
        public HashSet<FileInfo> fileInfos = new HashSet<FileInfo>();
        public void Search(string directory, string fileName)
        {

            var dirInfo = new System.IO.DirectoryInfo($@"{directory}");

            System.IO.FileInfo[] fileNames = dirInfo.GetFiles($"*{fileName}*");

            foreach (System.IO.FileInfo fi in fileNames)
            {
                fileInfos.Add(fi);
            }

            System.IO.DirectoryInfo[] subDirectories = dirInfo.GetDirectories();

            foreach (System.IO.DirectoryInfo subDir in subDirectories)
            {
                Search($@"{directory}\{subDir.Name}", fileName);
            }
        }

        public void WriteOut()
        {
            foreach (System.IO.FileInfo file in fileInfos)
            {
                Console.WriteLine(file.Name);
            }
        }
    }
}
