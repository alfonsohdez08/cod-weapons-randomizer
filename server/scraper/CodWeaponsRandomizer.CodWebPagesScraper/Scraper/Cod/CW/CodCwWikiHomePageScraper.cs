namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.CW
{
    class CodCwWikiHomePageScraper : CodWikiHomePageScraper
    {
        private const string CwWikiHomePageUrl = "https://callofduty.fandom.com/wiki/Call_of_Duty:_Black_Ops_Cold_War";

        public CodCwWikiHomePageScraper() : base(CwWikiHomePageUrl)
        {
        }
    }
}
