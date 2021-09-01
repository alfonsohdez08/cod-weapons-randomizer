using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;
using System.Text;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    class WeaponTableScraper
    {
        private static readonly string AnchorSelector;

        private readonly IHtmlTableElement _tableElement;

        static WeaponTableScraper()
        {
            string attributeConditions = new SelectorAttributesBuilder().Class("navbox-list", AttributeSearchCriteria.Contains).Build();
            var sb = new StringBuilder($"{Html.Tags.TableDataCell}")
                .Append($"{attributeConditions}")
                .Append(' ')
                .Append(Html.Tags.Anchor);

            AnchorSelector = sb.ToString();
        }

        public WeaponTableScraper(IHtmlTableElement tableElement)
        {
            _tableElement = tableElement;
        }

        private List<IHtmlAnchorElement> GetRowAnchors(int rowNumberToLastRow)
        {
            var sb = new StringBuilder()
                .Append($"tr:nth-last-child({rowNumberToLastRow})")
                .Append(" > ")
                .Append(AnchorSelector);

            return _tableElement.SelectAll<IHtmlAnchorElement>(sb.ToString()).ToList();
        }

        private List<GameItem> GetGameItems(int rowNumberToLastRow)
        {
            List<IHtmlAnchorElement> items = GetRowAnchors(rowNumberToLastRow);

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
                .Append(AnchorSelector);

            return _tableElement.SelectAll<IHtmlAnchorElement>(sb.ToString()).Select(a => a.Href).ToList();
        }

        public List<GameItem> ScrapLethals() => GetGameItems(7);

        public List<GameItem> ScrapTacticals() => GetGameItems(5);
    }
}
