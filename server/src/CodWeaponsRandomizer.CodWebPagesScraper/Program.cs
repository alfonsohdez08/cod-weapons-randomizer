using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.CW;
using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW;
using System;
using System.Text;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    public class Program
    {
        public static int Main(string[] args)
        {
            string dbPath = args.Length > 0 ? args[0] : Environment.CurrentDirectory;
            Console.WriteLine($"DB Path: {dbPath}.");

            try
            {
                var mwWikiHomePageScraper = new MwWikiHomePageScraper();
                var mwDbExporter = new MwDbExporter(mwWikiHomePageScraper);
                mwDbExporter.Export(dbPath);

                var cwWikiHomePageScraper = new CwWikiHomePageScraper();
                var cwDbExporter = new CwDbExporter(cwWikiHomePageScraper);
                cwDbExporter.Export(dbPath);
            }
            catch (Exception e)
            {
                var sb = new StringBuilder("An error has ocurred. ")
                    .AppendLine("Please see below to see the exception/error details:")
                    .AppendLine(e.ToString());
                Console.Error.WriteLine(sb.ToString());
                
                return -1;
            }

            return 0;
        }
    }
}