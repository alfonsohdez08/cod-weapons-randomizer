using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class GenericAnchorsScraper : WebPageComponentScraper<IHtmlTableDataCellElement, IEnumerable<string>>
    {
        public GenericAnchorsScraper(IHtmlTableDataCellElement htmlElement) : base(htmlElement)
        {
        }

        private static IEnumerable<string> StripTexts(IHtmlTableDataCellElement dataCellElement)
            => dataCellElement.SelectAll<IHtmlAnchorElement>(Html.Tags.Anchor).Select(a => a.Text);

        public override IEnumerable<string> Scrap() => StripTexts((IHtmlTableDataCellElement)HtmlElement.NextElementSibling!);
    }
}
