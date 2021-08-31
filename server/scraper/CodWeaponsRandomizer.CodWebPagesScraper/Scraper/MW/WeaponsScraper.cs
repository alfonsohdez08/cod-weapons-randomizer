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

        private IEnumerable<string> ScrapWeaponWikiLinks() => new WeaponWikiLinksScraper(HtmlElement).Scrap();

        private static Weapon ScrapWeapon(string weaponWikiLink) => new WeaponWikiPageScraper(weaponWikiLink).ScrapWeapon();

        public override List<Weapon> Scrap()
        {
            _weaponSet = new Set<Weapon>();
            foreach (string weaponWikiLink in ScrapWeaponWikiLinks())
                _weaponSet.Add(ScrapWeapon(weaponWikiLink));

            return _weaponSet.ToList();
        }
    }
}
