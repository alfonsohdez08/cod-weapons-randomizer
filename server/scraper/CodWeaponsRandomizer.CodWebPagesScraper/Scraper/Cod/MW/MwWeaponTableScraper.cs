using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW
{
    class MwWeaponTableScraper : TableScraper
    {
        public MwWeaponTableScraper(IHtmlTableElement tableElement) : base(tableElement)
        {

        }
        private List<string> ScrapWeaponHrefs() => TakeFirstRowsAnchors(19).Select(a => a.Href).ToList();

        public List<Weapon> ScrapWeapons()
        {
            var weaponSet = new Set<Weapon>();
            foreach (string weaponWikiHref in ScrapWeaponHrefs())
            {
                var weaponScraper = new WeaponPageScraper(weaponWikiHref);
                weaponSet.Add(weaponScraper.ScrapWeapon());
            }

            return weaponSet.ToList();
        }

        public List<GameItem> ScrapLethals() => ParseAnchors(GetSingleRowAnchors(29));

        public List<GameItem> ScrapTacticals() => ParseAnchors(GetSingleRowAnchors(31));
    }
}
