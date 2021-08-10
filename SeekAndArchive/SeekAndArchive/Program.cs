using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SeekAndArchive
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                var fileName = args[0].ToString();
                var directory = args[1].ToString();

                Search(directory, fileName);
            }
            PrintMenu();
            SelectMenuItem();
        }

        private static void SelectMenuItem()
        {
            var chosenMenu = Console.ReadLine();
            switch (chosenMenu)
            {
                case "1":
                    NewSearch();
                    PrintMenu();
                    SelectMenuItem();
                    break;
                case "2":
                    BrowseHistory();
                    PrintMenu();
                    SelectMenuItem();
                    break;

                case "e":
                    Environment.Exit(0);
                    break;
            }
        }

        private static void NewSearch()
        {
            Console.WriteLine("Please enter a file name:");
            var fileName = Console.ReadLine();
            Console.WriteLine("Please enter folder name:");
            var directory = Console.ReadLine();

            Search(directory, fileName);
        }

        private static void BrowseHistory()
        {
            var filePath = @"../../../SearchHistory.xml";
            XDocument xmlDoc = XDocument.Load(filePath);
            var searches = xmlDoc.Root.Elements("Search")
                                       .ToList();

            var history = new List<String>();

            var searchNum = 1;

            foreach (var search in searches)
            {

                var foundCount = 0;
                var fileName = search.Element("SearchTerm").Value;
                var folder = search.Element("Folder").Value;
                var searchTime = search.Element("Date").Value;


                foreach (var file in search.Element("Results").Element("Filenames").Elements())
                {
                    foundCount++;
                }



                var result = $"{searchNum}. {searchTime}: '{fileName}' in '{folder}', {foundCount} item/s found" + "\n";

                searchNum++;

                history.Add(result);


            }

            foreach (var res in history)
            {
                Console.WriteLine(res);
            }

            Console.WriteLine("Please Enter the number of previous result to print it again!\n");
            var index = int.Parse(Console.ReadLine())-1;

            Console.WriteLine(history[index]);

        }

        private static void Search(string directory, string fileName)
        {
            SearchOptions searchOptions = new SearchOptions();
            searchOptions.StartDirectorySetUp(directory);
            searchOptions.Search($@"{directory}", $@"{fileName}");
            searchOptions.SaveToXML();
        }

        private static void PrintMenu()
        {
            Console.WriteLine(@"
Hey there, let's search for a file!
---------------------
Please choose a menu item:
    1 - New Search
    2 - Browse history
---------------------
If you want to exit press 'e'.");
        }

    }
}
