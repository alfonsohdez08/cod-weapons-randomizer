using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class GenericAnchorsScraper : WebPageComponentScraper<IHtmlTableDataCellElement, List<GameItem>>
    {
        private readonly Set<GameItem> _set;

        public GenericAnchorsScraper(IHtmlTableDataCellElement htmlElement) : base(htmlElement)
        {
            _set = new Set<GameItem>();
        }

        private static IEnumerable<string> StripTexts(IHtmlTableDataCellElement dataCellElement)
            => dataCellElement.SelectAll<IHtmlAnchorElement>(Html.Tags.Anchor).Select(a => a.Text);

        public override List<GameItem> Scrap()
        {
            foreach (string textContent in StripTexts((IHtmlTableDataCellElement)HtmlElement.NextElementSibling!))
                _set.Add(new GameItem(textContent));

            return _set.ToList();
        }
    }
}
