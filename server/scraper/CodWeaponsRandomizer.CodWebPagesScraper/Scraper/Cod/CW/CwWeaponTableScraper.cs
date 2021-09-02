using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.CW
{
    class CwWeaponTableScraper : WeaponTableScraper
    {
        public CwWeaponTableScraper(IHtmlTableElement tableElement) : base(tableElement)
        {
        }

        public override int WeaponRowCount => throw new NotImplementedException();

        public override int LethalRowNumber => throw new NotImplementedException();

        public override int TacticalRowNumber => throw new NotImplementedException();

        protected override WeaponPageScraper GetWeaponPageScraper(string weaponHref)
        {
            throw new NotImplementedException();
        }
    }
}
