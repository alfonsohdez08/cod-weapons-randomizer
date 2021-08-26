using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class CodMwWeaponsScraper : WebPageScraper<IEnumerable<Weapon>>
    {
        public CodMwWeaponsScraper() : base()
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
        {
            foreach (IHtmlTableDataCellElement dataCellElement in tableElement.QuerySelectorAll<IHtmlTableDataCellElement>("td.navbox-group"))
            {
                IHtmlAnchorElement weaponCategoryAnchorElement = dataCellElement.QuerySelector<IHtmlAnchorElement>("a");
                if (weaponCategoryAnchorElement.Text == "Special")
                    yield break;

                yield return dataCellElement;
            }
        }

        private static IEnumerable<IHtmlAnchorElement> GetWeaponAnchors(IHtmlTableElement tableElement)
        {
            var weaponAnchors = new List<IHtmlAnchorElement>();
            foreach (IHtmlTableDataCellElement dataCellElement in GetWeaponTableDataCellElements(tableElement))
            {
                var anchors = dataCellElement.NextElementSibling.QuerySelectorAll<IHtmlAnchorElement>("a");
                weaponAnchors.AddRange(anchors);
            }

            return weaponAnchors;
        }

        private static Weapon GetWeaponDetails(IHtmlAnchorElement anchorElement) => new CodMwWeaponDetailsScraper(anchorElement.Href).Scrap();

        public override IEnumerable<Weapon> Scrap()
        {
            var weapons = new List<Weapon>();

            IHtmlTableElement weaponTableElement = FindWeaponTableElement();
            foreach (IHtmlAnchorElement anchorElement in GetWeaponAnchors(weaponTableElement))
                weapons.Add(GetWeaponDetails(anchorElement));

            return weapons;
        }
    }
}
