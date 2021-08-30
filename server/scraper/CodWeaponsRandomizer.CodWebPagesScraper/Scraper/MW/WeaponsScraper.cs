using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Data;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponsScraper : WikiHomePage<IEnumerable<Weapon>>
    {
        private IHtmlTableElement FindWeaponTableElement()
        {
            IHtmlSpanElement weaponSpanElement = FindWeaponSectionSpanElement();
            return weaponSpanElement!.ParentElement!.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
        }

        private IHtmlSpanElement FindWeaponSectionSpanElement() => HtmlDocument.SelectFirst<IHtmlSpanElement>("#Weapons");

        private static IEnumerable<string> ScrapWeaponHrefs(IHtmlTableElement tableElement) => new WeaponLinksScraper(tableElement).Scrap();

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
