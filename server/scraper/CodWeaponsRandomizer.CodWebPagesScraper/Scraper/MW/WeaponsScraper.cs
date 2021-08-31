using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Data;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponsScraper : WebPageComponentScraper<IHtmlTableElement, IEnumerable<Weapon>>
    {
        public WeaponsScraper(IHtmlTableElement tableElement) : base(tableElement)
        {
        }

        private IEnumerable<string> ScrapWeaponWikiLinks() => new WeaponWikiLinksScraper(HtmlElement).Scrap();

        private static Weapon ScrapWeapon(string weaponWikiLink) => new WeaponWikiPageScraper(weaponWikiLink).ScrapWeapon();

        public override IEnumerable<Weapon> Scrap()
        {  
            var weapons = new List<Weapon>();

            foreach (string weaponWikiLink in ScrapWeaponWikiLinks())
                weapons.Add(ScrapWeapon(weaponWikiLink));

            return weapons;
        }
    }
}
