using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    abstract class WeaponTableScraper: TableScraper
    {
        public WeaponTableScraper(IHtmlTableElement tableElement) : base(tableElement)
        {

        }

        private List<string> ScrapWeaponHrefs() => TakeFirstRowsAnchors(WeaponRowCount).Select(a => a.Href).ToList();

        public List<Weapon> ScrapWeapons()
        {
            var weaponSet = new Set<Weapon>();
            foreach (string weaponWikiHref in ScrapWeaponHrefs())
            {
                WeaponPageScraper weaponScraper = GetWeaponPageScraper(weaponWikiHref);
                weaponSet.Add(weaponScraper.ScrapWeapon());
            }

            return weaponSet.ToList();
        }

        public List<GameItem> ScrapLethals() => ParseAnchors(GetSingleRowAnchors(LethalRowNumber));

        public List<GameItem> ScrapTacticals() => ParseAnchors(GetSingleRowAnchors(TacticalRowNumber));

        public abstract int WeaponRowCount { get; }
        public abstract int LethalRowNumber { get; }
        public abstract int TacticalRowNumber { get; }
        protected abstract WeaponPageScraper GetWeaponPageScraper(string weaponHref);
    }
}
