using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.CW
{
    class CwWikiHomePageScraper : WikiHomePageScraper
    {
        private const string CwWikiHomePageUrl = "https://callofduty.fandom.com/wiki/Call_of_Duty:_Black_Ops_Cold_War";

        public CwWikiHomePageScraper() : base(CwWikiHomePageUrl)
        {
        }

        protected override WeaponTableScraper GetWeaponTableScraper(IHtmlTableElement tableElement) => new CwWeaponTableScraper(tableElement);
    }
}
