using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW
{
    class MwWeaponTableScraper : WeaponTableScraper
    {
        public override int WeaponRowCount => 19;
        public override int LethalRowNumber => 29;
        public override int TacticalRowNumber => 31;

        public MwWeaponTableScraper(IHtmlTableElement tableElement) : base(tableElement)
        {

        }

        protected override WeaponPageScraper GetWeaponPageScraper(string weaponHref)
        {
            throw new NotImplementedException();
        }
    }
}
