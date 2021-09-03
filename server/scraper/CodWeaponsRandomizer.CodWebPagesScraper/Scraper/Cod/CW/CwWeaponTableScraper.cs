using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.CW
{
    class CwWeaponTableScraper : WeaponTableScraper
    {
        public CwWeaponTableScraper(IHtmlTableElement tableElement) : base(tableElement)
        {
        }

        public override int WeaponRowCount => 19;

        public override int LethalRowNumber => 27;

        public override int TacticalRowNumber => 29;

        protected override WeaponPageScraper GetWeaponPageScraper(string weaponHref) => new CwWeaponPageScraper(weaponHref);
    }
}
