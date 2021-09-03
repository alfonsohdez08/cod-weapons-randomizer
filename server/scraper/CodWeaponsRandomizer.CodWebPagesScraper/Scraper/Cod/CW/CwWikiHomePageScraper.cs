using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.CW
{
    class CwWikiHomePageScraper : WikiHomePageScraper
    {
        private const string CwWikiHomePageUrl = "https://callofduty.fandom.com/wiki/Call_of_Duty:_Black_Ops_Cold_War";

        private readonly CwWildcardTableScraper _wildcardsTableScraper;

        public CwWikiHomePageScraper() : base(CwWikiHomePageUrl)
        {
            _wildcardsTableScraper = new CwWildcardTableScraper(GetPerksAndScorestreaksTableElement());
        }

        public List<GameItem> ScrapWildcards() => _wildcardsTableScraper.ScrapWildcards();

        protected override string PerksScorestreaksSectionId => "Perks_and_Scorestreaks";

        protected override WeaponTableScraper GetWeaponTableScraper(IHtmlTableElement tableElement) => new CwWeaponTableScraper(tableElement);
    }
}
