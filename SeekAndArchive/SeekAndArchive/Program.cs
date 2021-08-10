using System;

namespace SeekAndArchive
{
    class Program
    {

        static void Main(string[] args)
        {
            var fileName = args[0].ToString();
            var directory = args[1].ToString();

            SearchOptions searchOptions = new SearchOptions();
            searchOptions.Search($@"{directory}", $@"{fileName}");
            searchOptions.WriteOut();
            searchOptions.SaveToXML();
            Console.WriteLine("Hello World!");
        }
    }
}
