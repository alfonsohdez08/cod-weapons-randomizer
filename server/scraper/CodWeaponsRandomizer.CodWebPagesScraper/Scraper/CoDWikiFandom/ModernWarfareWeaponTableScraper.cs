using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class ModernWarfareWeaponTableScraper : WebPageElementScraper<IHtmlTableElement, IEnumerable<string>>
    {
        public ModernWarfareWeaponTableScraper(IHtmlTableElement tableElement) : base(tableElement)
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
            => weaponCategoryDataCell.NextElementSibling.QuerySelectorAll("a").Select(a => ((IHtmlAnchorElement)a).Href);

        private IEnumerable<IHtmlTableDataCellElement> GetWeaponCategoryDataCellElements()
        {
            foreach (var dataCell in HtmlElement.QuerySelectorAll("td.navbox-group"))
            {
                IHtmlAnchorElement weaponCategoryAnchor = (IHtmlAnchorElement)dataCell.QuerySelector("a");
                if (weaponCategoryAnchor.Text == "Special")
                    yield break;

                yield return (IHtmlTableDataCellElement)dataCell;
            }
        }
    }
}
