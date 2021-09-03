// See https://aka.ms/new-console-template for more information

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
                var mwDb = new MwDatabase();
                mwDb.Export(dbPath);

                var cwDb = new CwDatabase();
                cwDb.Export(dbPath);
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }
    }
}