using System;

namespace SeekAndArchive
{
    class Program
    {
        
        static void Main(string[] args)
        {
          SearchOptions searchOptions = new SearchOptions();
            searchOptions.Search(@"C:\Program Files\NordVPN", "NordVpn.Resources.resources.dll");
            searchOptions.WriteOut();
            Console.WriteLine("Hello World!");
        }
    }
}
