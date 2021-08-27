using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class ModernWarfareWeaponsHomePageScraper : WebPageScraper<IEnumerable<Weapon>>
    {
        private const string CodMwWikiPagePath = "https://callofduty.fandom.com/Call_of_Duty:_Modern_Warfare_(2019)";

        public ModernWarfareWeaponsHomePageScraper() : base(CodMwWikiPagePath)
        {
        }

        private IHtmlTableElement FindWeaponTableElement()
        {
            IHtmlSpanElement weaponSpanElement = FindWeaponSectionSpanElement();

            return weaponSpanElement.ParentElement.NextElementSibling.QuerySelector<IHtmlTableElement>("table");
        }

        private IHtmlSpanElement FindWeaponSectionSpanElement()
            => HtmlDocument.QuerySelector<IHtmlSpanElement>("#Weapons");

        private static IEnumerable<string> ScrapWeaponHrefs(IHtmlTableElement tableElement) => new ModernWarfareWeaponTableScraper(tableElement).Scrap();

        private static Weapon ScrapWeapon(string weaponHref) => new ModernWarfareWeaponDetailsPageScraper(weaponHref).Scrap();

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
