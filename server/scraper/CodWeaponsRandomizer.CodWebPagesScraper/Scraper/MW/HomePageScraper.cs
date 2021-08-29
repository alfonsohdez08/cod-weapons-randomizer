namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    abstract class HomePageScraper<T> : WebPageScraper<T> where T : class
    {
        private const string MwWikiHomePage = "https://callofduty.fandom.com/wiki/Call_of_Duty:_Modern_Warfare_(2019)";

        protected HomePageScraper() : base(MwWikiHomePage)
        {
        }
    }
}
