using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;
using System.Text;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    class WeaponTableScraper
    {
        private readonly IHtmlTableElement _tableElement;

        public WeaponTableScraper(IHtmlTableElement tableElement)
        {
            _tableElement = tableElement;
        }

        private List<GameItem> GetRowAnchorContents(int rowNumberToLastRow)
        {
            var sb = new StringBuilder()
                .Append($"tr:nth-last-child({rowNumberToLastRow})")
                .Append(" > ")
                .Append(Selectors.TableAnchors);

            var items = _tableElement.SelectAll<IHtmlAnchorElement>(sb.ToString()).Select(a => new GameItem(a.Text));

            var set = new Set<GameItem>();
            foreach (GameItem item in items)
                set.Add(item);

            return set.ToList();
        }

        public List<string> ScrapWeaponHrefs()
        {
            const string first19TableRowsSelector = "tr:nth-child(-n+19)"; // the first 19 table rows correspond to the game weapons

            var sb = new StringBuilder(first19TableRowsSelector)
                .Append(" > ")
                .Append(Selectors.TableAnchors);

            return _tableElement.SelectAll<IHtmlAnchorElement>(sb.ToString()).Select(a => a.Href).ToList();
        }

        public List<GameItem> ScrapLethals() => GetRowAnchorContents(7);

        public List<GameItem> ScrapTacticals() => GetRowAnchorContents(5);
    }
}
