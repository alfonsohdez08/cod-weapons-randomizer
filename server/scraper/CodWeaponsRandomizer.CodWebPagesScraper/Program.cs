// See https://aka.ms/new-console-template for more information

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    public class Program
    {
        public static int Main(string[] args)
        {
            string mwDbPath = args.Length > 0 ? args[0] : Environment.CurrentDirectory;
            Console.WriteLine($"DB Path: {mwDbPath}.");

            try
            {
                var mwDb = new CodMwDatabase();

                mwDb.Export(mwDbPath);
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }
    }
}