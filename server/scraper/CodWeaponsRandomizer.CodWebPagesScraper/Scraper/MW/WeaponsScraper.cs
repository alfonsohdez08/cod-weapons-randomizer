using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponsScraper : WebPageComponentScraper<IHtmlTableElement, List<Weapon>>
    {
        private Set<Weapon>? _weaponSet;

        public WeaponsScraper(IHtmlTableElement tableElement) : base(tableElement)
        {
        }

        private List<string> ScrapWeaponHrefs() => new WeaponHrefsScraper(HtmlElement).Scrap();

        private static Weapon ScrapWeapon(string weaponWikiLink) => new WeaponPageScraper(weaponWikiLink).ScrapWeapon();

        public override List<Weapon> Scrap()
        {
            _weaponSet = new Set<Weapon>();
            foreach (string weaponHref in ScrapWeaponHrefs())
                _weaponSet.Add(ScrapWeapon(weaponHref));

            return _weaponSet.ToList();
        }
    }
}
