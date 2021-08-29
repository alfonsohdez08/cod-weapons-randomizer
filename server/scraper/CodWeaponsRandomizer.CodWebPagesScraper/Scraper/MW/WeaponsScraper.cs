using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponsScraper : HomePageScraper<IEnumerable<Weapon>>
    {
        private IHtmlTableElement FindWeaponTableElement()
        {
            IHtmlSpanElement weaponSpanElement = FindWeaponSectionSpanElement();

            return weaponSpanElement.ParentElement.NextElementSibling.QuerySelector<IHtmlTableElement>("table");
        }

        private IHtmlSpanElement FindWeaponSectionSpanElement()
            => HtmlDocument.QuerySelector<IHtmlSpanElement>("#Weapons");

        private static IEnumerable<string> ScrapWeaponHrefs(IHtmlTableElement tableElement) => new WeaponTableScraper(tableElement).Scrap();

        private static Weapon ScrapWeapon(string weaponHref) => new WeaponDetailsPageScraper(weaponHref).Scrap();

        public override IEnumerable<Weapon> Scrap()
        {  
            var weapons = new List<Weapon>();

            IHtmlTableElement weaponTableElement = FindWeaponTableElement();
            foreach (string weaponHref in ScrapWeaponHrefs(weaponTableElement))
                weapons.Add(ScrapWeapon(weaponHref));

            return weapons;
        }
    }
}
