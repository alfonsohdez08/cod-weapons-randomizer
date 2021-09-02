using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW
{
    class MwWikiHomePageScraper : WikiHomePageScraper
    {
        private const string MwWikiHomePageUrl = "https://callofduty.fandom.com/wiki/Call_of_Duty:_Modern_Warfare_(2019)";

        public MwWikiHomePageScraper() : base(MwWikiHomePageUrl)
        {
        }

        protected override WeaponTableScraper GetWeaponTableScraper(IHtmlTableElement tableElement) => new MwWeaponTableScraper(tableElement);
    }
}
