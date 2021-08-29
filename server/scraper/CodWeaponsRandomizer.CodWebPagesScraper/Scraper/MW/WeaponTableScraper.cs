using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponTableScraper : WebPageElementScraper<IHtmlTableElement, IEnumerable<string>>
    {
        public WeaponTableScraper(IHtmlTableElement tableElement) : base(tableElement)
        {
        }

        public override IEnumerable<string> Scrap()
        {
            var weaponHrefs = new List<string>();
            foreach (var weaponCategoryDataCell in GetWeaponCategoryDataCellElements())
                weaponHrefs.AddRange(GetWeaponHrefs(weaponCategoryDataCell));

            return weaponHrefs;
        }

        private static IEnumerable<string> GetWeaponHrefs(IHtmlTableDataCellElement weaponCategoryDataCell)
            => weaponCategoryDataCell.NextElementSibling.QuerySelectorAll<IHtmlAnchorElement>("a").Select(a => a.Href);

        private IEnumerable<IHtmlTableDataCellElement> GetWeaponCategoryDataCellElements()
        {
            foreach (var dataCell in HtmlElement.QuerySelectorAll<IHtmlTableDataCellElement>("td.navbox-group"))
            {
                var weaponCategoryAnchor = dataCell.QuerySelector<IHtmlAnchorElement>("a");
                if (weaponCategoryAnchor.Text == "Special")
                    yield break;

                yield return dataCell;
            }
        }
    }
}
