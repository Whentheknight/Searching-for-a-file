using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeekAndArchive
{
    public class SearchOptions
    {
        private HashSet<FileInfo> fileInfos = new HashSet<FileInfo>();
        private DateTime searchTime;
        private string searchTerm;
        private string folder;
        
        public void Search(string directory, string fileName)
        {
            searchTerm = fileName;
            folder = directory;

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

            searchTime = DateTime.Now;
        }

        public void WriteOut()
        {
            foreach (System.IO.FileInfo file in fileInfos)
            {
                Console.WriteLine(file.Name);
            }
        }

        public void SaveToXML()
        {
            var filePath = @"../../../SearchHistory.xml";
            XDocument doc = XDocument.Load(filePath);
            XElement searches = doc.Element("Searches");

            searches.Add(new XElement("Search",
                new XElement("SearchTerm", $"{searchTerm}"),
                new XElement("Folder", $"{folder}"),
                new XElement("Date", $"{searchTime}"),
                new XElement("Results",
                new XElement("Filenames", fileInfos.Select(x => new XElement("FileName",x.Name.Replace(x.Extension,""))),
                new XElement("Extensions", fileInfos.Select(x => new XElement("Extension", x.Extension))),
                new XElement("Paths", fileInfos.Select(x => new XElement("Path", x.FullName)))
                ))));

            doc.Save(filePath);
        }
    }
}
