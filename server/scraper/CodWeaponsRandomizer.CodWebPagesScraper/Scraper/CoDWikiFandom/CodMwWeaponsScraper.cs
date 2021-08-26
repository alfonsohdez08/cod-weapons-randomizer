using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class CodMwWeaponsScraper : WebPageScraper<IEnumerable<Weapon>>
    {
        private CodMwWeaponsScraper() : base()
        {
        }

        private IHtmlTableElement FindWeaponTableElement()
        {
            IHtmlHeadingElement weaponsHeading = FindWeaponsSectionHeadingElement();

            return weaponsHeading.ParentElement.NextElementSibling.QuerySelector<IHtmlTableElement>("table");
        }

        private IHtmlHeadingElement FindWeaponsSectionHeadingElement()
            => HtmlDocument.QuerySelector<IHtmlHeadingElement>("#Weapons");

        private static IEnumerable<IHtmlTableDataCellElement> GetWeaponTableDataCellElements(IHtmlTableElement tableElement)
            => tableElement.QuerySelectorAll<IHtmlTableDataCellElement>("td.navbox-group");

        public override IEnumerable<Weapon> Scrap()
        {
            IHtmlTableElement weaponTableElement = FindWeaponTableElement();
            foreach (IHtmlTableDataCellElement dataCellElement in GetWeaponTableDataCellElements(weaponTableElement))
            {
                //WeaponCategory weaponCategory = WeaponCategory.Parse(dataCellElement.QuerySelector<IHtmlAnchorElement>("a"));

            }

            throw new NotImplementedException();
        }

        public static IEnumerable<Weapon> ScrapWeapons() => new CodMwWeaponsScraper().Scrap();
    }
}
