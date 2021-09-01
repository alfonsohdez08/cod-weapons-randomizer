using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    class WeaponsScraper : WebPageComponentScraper<IHtmlTableElement, List<Weapon>>
    {
        private Set<Weapon>? _weaponSet;

        private readonly WeaponTableScraper _weaponTableScraper;

        public WeaponsScraper(IHtmlTableElement tableElement) : base(tableElement)
        {
            _weaponTableScraper = new WeaponTableScraper(tableElement);
        }

        private static Weapon ScrapWeapon(string weaponWikiLink) => new WeaponPageScraper(weaponWikiLink).ScrapWeapon();

        public override List<Weapon> Scrap()
        {
            _weaponSet = new Set<Weapon>();
            foreach (string weaponHref in _weaponTableScraper.ScrapWeaponHrefs())
                _weaponSet.Add(ScrapWeapon(weaponHref));

            return _weaponSet.ToList();
        }
    }
}
