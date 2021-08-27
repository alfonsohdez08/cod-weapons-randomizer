using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class CodMwWeaponsScraper : WebPageScraper<IEnumerable<Weapon>>
    {
        private const string CodMwWikiPagePath = "/Call_of_Duty:_Modern_Warfare_(2019)";

        public CodMwWeaponsScraper() : base(CodMwWikiPagePath)
        {
        }

        private IHtmlTableElement FindWeaponTableElement()
        {
            IHtmlSpanElement weaponSpanElement = FindWeaponSectionSpanElement();

            return weaponSpanElement.ParentElement.NextElementSibling.QuerySelector<IHtmlTableElement>("table");
        }

        private IHtmlSpanElement FindWeaponSectionSpanElement()
            => HtmlDocument.QuerySelector<IHtmlSpanElement>("#Weapons");

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
