using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;
using System.Text;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    abstract class TableScraper
    {
        private static readonly string AnchorSelector;

        private readonly IHtmlTableElement _tableElement;

        static TableScraper()
        {
            string attributeConditions = new SelectorAttributesBuilder().Class("navbox-list", AttributeSearchCriteria.Contains).Build();
            var sb = new StringBuilder($"{Html.Tags.TableDataCell}")
                .Append($"{attributeConditions}")
                .Append(' ')
                .Append(Html.Tags.Anchor);

            AnchorSelector = sb.ToString();
        }

        public TableScraper(IHtmlTableElement tableElement)
        {
            _tableElement = tableElement;
        }

        private static string ParseTableRowSelector(string rowSelector) => $"{rowSelector} > {AnchorSelector}";

        protected static List<GameItem> ParseAnchors(IEnumerable<IHtmlAnchorElement> anchors)
        {
            IEnumerable<GameItem> items = anchors.Select(a => new GameItem(a.Text));

            var set = new Set<GameItem>();
            set.AddRange(items);

            return set.ToList();
        }

        protected IEnumerable<IHtmlAnchorElement> TakeFirstRowsAnchors(int count)
        {
            string firstRowsSelector = $"tr:nth-child(-n+{count})";
            return _tableElement.SelectAll<IHtmlAnchorElement>(ParseTableRowSelector(firstRowsSelector));
        }

        protected IEnumerable<IHtmlAnchorElement> GetSingleRowAnchors(int rowNumber)
        {
            string rowSelector = $"tr:nth-child({rowNumber})";
            return _tableElement.SelectAll<IHtmlAnchorElement>(ParseTableRowSelector(rowSelector));
        }
    }
}
