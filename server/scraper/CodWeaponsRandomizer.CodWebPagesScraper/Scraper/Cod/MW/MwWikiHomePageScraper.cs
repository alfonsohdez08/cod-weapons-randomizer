namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW
{
    class MwWikiHomePageScraper : CodWikiHomePageScraper
    {
        private const string MwWikiHomePageUrl = "https://callofduty.fandom.com/wiki/Call_of_Duty:_Modern_Warfare_(2019)";

        public MwWikiHomePageScraper() : base(MwWikiHomePageUrl)
        {
        }
    }
}
